using System;
using TUNING;
using UnityEngine;

// Token: 0x02000099 RID: 153
public class 高频电炉配置 : IBuildingConfig
{
	// Token: 0x06000259 RID: 601 RVA: 0x0008AA8C File Offset: 0x00088C8C
	public override BuildingDef CreateBuildingDef()
	{
		string id = "LiquidHeater";
		int width = 4;
		int height = 1;
		string anim = "boiler_kanim";
		int hitpoints = 30;
		float construction_time = 30f;
		float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
		string[] all_METALS = MATERIALS.ALL_METALS;
		float melting_point = 3200f;
		BuildLocationRule build_location_rule = BuildLocationRule.Anywhere;
		EffectorValues none = NOISE_POLLUTION.NONE;
		BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, all_METALS, melting_point, build_location_rule, BUILDINGS.DECOR.PENALTY.TIER1, none, 0.2f);
		buildingDef.RequiresPowerInput = true;
		buildingDef.Floodable = false;
		buildingDef.EnergyConsumptionWhenActive = 960f;
		buildingDef.ViewMode = OverlayModes.Power.ID;
		buildingDef.AudioCategory = "SolidMetal";
		buildingDef.OverheatTemperature = 9999f;
		buildingDef.PowerInputOffset = new CellOffset(1, 0);
		buildingDef.InputConduitType = ConduitType.Solid;
		buildingDef.OutputConduitType = ConduitType.Liquid;
		buildingDef.UtilityInputOffset = new CellOffset(0, 0);
		buildingDef.UtilityOutputOffset = new CellOffset(3, 0);
		buildingDef.PermittedRotations = PermittedRotations.R360;
		buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(1, 0));
		return buildingDef;
	}

	// Token: 0x0600025A RID: 602 RVA: 0x0008AB44 File Offset: 0x00088D44
	public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
	{
		go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery, false);
		高频电炉 电炉= go.AddOrGet<高频电炉>();
		go.AddOrGet<SolidConduitOutbox>();
		go.AddOrGet<SolidConduitConsumer>();

		BuildingTemplates.CreateComplexFabricatorStorage(go, 电炉);

		ConduitDispenser conduitDispenser = go.AddOrGet<ConduitDispenser>();
		conduitDispenser.storage = 电炉.outStorage;
		conduitDispenser.conduitType = ConduitType.Liquid;
		conduitDispenser.elementFilter = null;
		conduitDispenser.alwaysDispense = true;


		ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
		elementConverter.consumedElements = new ElementConverter.ConsumedElement[]{new ElementConverter.ConsumedElement(new Tag("IronOre"), 100f, true)};
		elementConverter.outputElements = new ElementConverter.OutputElement[]{new ElementConverter.OutputElement(100f, SimHashes.MoltenIron, 1500f, false, false, 3, 1, 1f, byte.MaxValue, 0, true),};
		
		
		Prioritizable.AddRef(go);
	}

	// Token: 0x0600025B RID: 603 RVA: 0x000029F6 File Offset: 0x00000BF6
	public override void DoPostConfigureComplete(GameObject go)
	{
		go.AddOrGet<LogicOperationalController>();
		go.AddOrGetDef<PoweredActiveController.Def>();
	}

	// Token: 0x0400016C RID: 364
	public const string ID = "Electrolyzer";

	// Token: 0x0400016D RID: 365
	public const float WATER2OXYGEN_RATIO = 0.888f;

	// Token: 0x0400016E RID: 366
	public const float OXYGEN_TEMPERATURE = 343.15f;
}
