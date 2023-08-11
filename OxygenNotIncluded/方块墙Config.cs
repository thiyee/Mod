﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

// Token: 0x020000B9 RID: 185
public class ExteriorWallConfig : IBuildingConfig
{
	// Token: 0x060002EB RID: 747 RVA: 0x0008C60C File Offset: 0x0008A80C
	public override BuildingDef CreateBuildingDef()
	{
		string id = "方块墙";
		int width = 1;
		int height = 1;
		string anim = "walls_kanim";
		int hitpoints =1;
		float construction_time = 3f;
		float[] tier = new float[] { 1000f};
		string[] raw_MINERALS = MATERIALS.ANY_BUILDABLE;
		float melting_point = 1600f;
		BuildLocationRule build_location_rule = BuildLocationRule.NotInTiles;
		EffectorValues none = NOISE_POLLUTION.NONE;
		BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, raw_MINERALS, melting_point, build_location_rule, new EffectorValues
		{
			amount = 10,
			radius = 0
		}, none, 0.2f);
		buildingDef.Entombable = false;
		buildingDef.Floodable = false;
		buildingDef.Overheatable = false;
		buildingDef.AudioCategory = "Metal";
		buildingDef.AudioSize = "small";
		buildingDef.BaseTimeUntilRepair = -1f;
		buildingDef.DefaultAnimState = "off";
		buildingDef.ObjectLayer = ObjectLayer.Backwall;
		buildingDef.SceneLayer = Grid.SceneLayer.Backwall;
		buildingDef.ReplacementLayer = ObjectLayer.ReplacementBackwall;
		buildingDef.Mass = new float[] { 666.66666666f }; ;
		buildingDef.ReplacementCandidateLayers = new List<ObjectLayer>
		{
			ObjectLayer.FoundationTile,
			ObjectLayer.Backwall
		};
		buildingDef.ReplacementTags = new List<Tag>
		{
			GameTags.FloorTiles,
			GameTags.Backwall
		};
		return buildingDef;
	}

	// Token: 0x060002EC RID: 748 RVA: 0x00003769 File Offset: 0x00001969
	public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
	{
		GeneratedBuildings.MakeBuildingAlwaysOperational(go);
		go.AddOrGet<AnimTileable>().objectLayer = ObjectLayer.Backwall;
		go.AddComponent<ZoneTile>();
		BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
	}

	// Token: 0x060002ED RID: 749 RVA: 0x00003799 File Offset: 0x00001999
	public override void DoPostConfigureComplete(GameObject go)
	{
		go.GetComponent<KPrefabID>().AddTag(GameTags.Backwall, false);
		GeneratedBuildings.RemoveLoopingSounds(go);
	}

	[HarmonyPatch(typeof(BuildingComplete), "OnSpawn")]
	public static class 方块墙建造Patch{
		public static void Postfix(BuildingComplete __instance){
			GameObject gameObject = __instance.gameObject;
			if (__instance.Def.PrefabID == "方块墙")
			{
				Vector3 position = gameObject.transform.position;
				PrimaryElement component = gameObject.GetComponent<PrimaryElement>();
				float temperature = component.Temperature;
				float blockMass = __instance.Def.Mass[0];
				int num = Grid.PosToCell(position);
				
				TracesExtesions.DeleteObject(gameObject);
				SimMessages.ReplaceAndDisplaceElement(num, component.ElementID, null, blockMass*2, temperature, byte.MaxValue, 0, -1);
			}
		}
	
	}
		public const string ID = "方块墙";
}
