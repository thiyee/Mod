using HarmonyLib;
using KMod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 无限拖把
{
	public class 无限拖把 : UserMod2
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public override void OnLoad(Harmony harmony)
		{
			MopTool.maxMopAmt = float.PositiveInfinity;     //拖把无限制
			base.OnLoad(harmony);
		}
	}
}
