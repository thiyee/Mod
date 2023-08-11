using STRINGS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class 高频电炉 : ComplexFabricator
{
	public bool 是否存在可融化固态物质()
	{

		List<GameObject> objs = this.inStorage.GetItems();
		if (objs.Count > 0)
		{
			foreach (GameObject item in objs)
			{
				Element element = item.GetComponent<Element>();
				if (element.IsSolid && element.highTempTransitionTarget != 0){
					
					ElementConverter elementConverter= smi.master.GetComponent<ElementConverter>();
					elementConverter.consumedElements[0].Tag = element.tag;
					elementConverter.outputElements[0].elementHash = element.highTempTransitionTarget;
					return true;
				}
			}
		}
		return false;
	}

	public void UpdateMeter() { }
	public class StatesInstance : GameStateMachine<高频电炉.States, 高频电炉.StatesInstance, 高频电炉, object>.GameInstance{
		public StatesInstance(高频电炉 master) : base(master){}
	}

	[MyCmpReq]
	private Operational operational;
	public class States : GameStateMachine<高频电炉.States, 高频电炉.StatesInstance, 高频电炉>
	{
		// Token: 0x060035D4 RID: 13780 RVA: 0x0014951C File Offset: 0x0014771C
		public override void InitializeStates(out StateMachine.BaseState default_state)
		{
			default_state = this.disabled;
			this.root.EventTransition(GameHashes.OperationalChanged, this.disabled, (高频电炉.StatesInstance smi) => !smi.master.operational.IsOperational).EventHandler(GameHashes.OnStorageChange, delegate (高频电炉.StatesInstance smi)
			{
				smi.master.UpdateMeter();
			});
			this.disabled.EventTransition(GameHashes.OperationalChanged, this.waiting, (高频电炉.StatesInstance smi) => smi.master.operational.IsOperational);

			this.waiting.Enter("Waiting", delegate (高频电炉.StatesInstance smi)
			{
				smi.master.operational.SetActive(false, false);
			}).EventTransition(GameHashes.OnStorageChange, this.converting, (高频电炉.StatesInstance smi) => smi.master.是否存在可融化固态物质());

			this.converting.Enter("Ready", delegate (高频电炉.StatesInstance smi)
			{
				smi.master.operational.SetActive(true, false);
			}).Transition(this.waiting, (高频电炉.StatesInstance smi) => !smi.master.是否存在可融化固态物质(), UpdateRate.SIM_200ms);


		}

		// Token: 0x040024C7 RID: 9415
		public GameStateMachine<高频电炉.States, 高频电炉.StatesInstance, 高频电炉, object>.State root;
		public GameStateMachine<高频电炉.States, 高频电炉.StatesInstance, 高频电炉, object>.State waiting;
		public GameStateMachine<高频电炉.States, 高频电炉.StatesInstance, 高频电炉, object>.State converting;
		public GameStateMachine<高频电炉.States, 高频电炉.StatesInstance, 高频电炉, object>.State disabled;





	}
}

