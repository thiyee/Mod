using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Klei.AI;
using KMod;
using TUNING;
using UnityEngine;
using static GeyserConfigurator;

namespace OxygenNotIncluded{
	public class Patchs {
		
		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
		public class 无限拖把 : UserMod2 {
			// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
			public override void OnLoad(Harmony harmony)
			{
				MopTool.maxMopAmt = float.PositiveInfinity;     //拖把无限制
				base.OnLoad(harmony);
			}
		}
		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
		[HarmonyPatch(typeof(EntityTemplates), "CreateAndRegisterBaggedCreature")]
		public class 九天揽月
		{
			// Token: 0x06000007 RID: 7 RVA: 0x000020B0 File Offset: 0x000002B0
			public static void Prefix(ref bool allow_mark_for_capture)
			{

				allow_mark_for_capture = true;
			}
		}
		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
		[HarmonyPatch(typeof(EntityTemplates), "ExtendEntityToFertileCreature")]
		public class 下海捞鱼
		{
			// Token: 0x06000007 RID: 7 RVA: 0x000020B0 File Offset: 0x000002B0
			public static void Prefix(ref bool add_fixed_capturable_monitor)
			{
				add_fixed_capturable_monitor = true;
			}
		}
		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
		[HarmonyPatch(typeof(EntityTemplates), "ExtendEntityToBasicCreature")]
		public class 动物体质增强
		{
			// Token: 0x06000007 RID: 7 RVA: 0x000020B0 File Offset: 0x000002B0
			public static void Prefix(ref float warningLowTemperature, ref float warningHighTemperature, ref float lethalLowTemperature, ref float lethalHighTemperature)
			{
				if (warningLowTemperature > 150f) warningLowTemperature -= 100f;
				if (warningHighTemperature < 303.15f) warningLowTemperature = 303.15f;
				if (lethalLowTemperature > 150f) lethalLowTemperature -= 100f;
				if (lethalHighTemperature < 275.15f + 55f) lethalHighTemperature = 275.15f+55f;
			}
		}
		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
		[HarmonyPatch(typeof(BaseBeeHiveConfig), "CreatePrefab")]
		public class 辐射蜂巢改造
		{
			// Token: 0x06000007 RID: 7 RVA: 0x000020B0 File Offset: 0x000002B0
			public static void Postfix(ref GameObject __result){
				__result.AddOrGet<TemperatureVulnerable>().Configure(273.15f-90f, 273.15f - 90f, 273.15f + 90f, 273.15f + 90f);
			}
		}


		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

		[HarmonyPatch(typeof(MassageTableConfig), "ConfigureBuildingTemplate")]
		public class 按摩床恢复速度
		{
			// Token: 0x06000007 RID: 7 RVA: 0x000020B0 File Offset: 0x000002B0
			public static void Postfix(GameObject go)
			{
				MassageTable massageTable = go.AddOrGet<MassageTable>();
				massageTable.stressModificationValue *= 10f;                //按摩床效率*10
				massageTable.roomStressModificationValue *= 10f;                //按摩床效率*10
			}
		}
		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

		[HarmonyPatch(typeof(RefrigeratorConfig), "DoPostConfigureComplete")]
		public class 冰箱储存容量
		{
			// Token: 0x06000007 RID: 7 RVA: 0x000020B0 File Offset: 0x000002B0
			public static void Postfix(GameObject go)
			{
				Storage storage = go.AddOrGet<Storage>();
				storage.capacityKg *= 1000f;
			}
		}
		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
		[HarmonyPatch(typeof(RefrigeratorController.Def), MethodType.Constructor)]
		public class 冰箱储存温度
		{
			// Token: 0x0600000F RID: 15 RVA: 0x0000218B File Offset: 0x0000038B
			private static void Postfix(ref float ___simulatedInternalTemperature)
			{
				___simulatedInternalTemperature = 253.15f;
			}
		}
		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
		[HarmonyPatch(typeof(ElectrolyzerConfig), "ConfigureBuildingTemplate")]
		public class 永不串气电解器
		{
			// Token: 0x06000007 RID: 7 RVA: 0x000020B0 File Offset: 0x000002B0
			public static void Postfix(GameObject go)
			{
				Electrolyzer electrolyzer = go.AddOrGet<Electrolyzer>();
				electrolyzer.maxMass *= 100f;
				ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
				conduitConsumer.consumptionRate *= 100f;
				Storage storage = go.AddOrGet<Storage>();
				storage.capacityKg *= 200f;
				ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
				elementConverter.consumedElements[0].MassConsumptionRate *= 100;
				elementConverter.outputElements[0].massGenerationRate *= 100;
				elementConverter.outputElements[0].outputElementOffset.y -= 2;
				elementConverter.outputElements[1].massGenerationRate *= 100;

			}
		}
		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
		[HarmonyPatch(typeof(ClusterTelescope.Def), MethodType.Constructor)]
		public class 望远镜范围
		{
			// Token: 0x0600000F RID: 15 RVA: 0x0000218B File Offset: 0x0000038B
			private static void Postfix(ref ClusterTelescope.Def __instance)
			{

				__instance.analyzeClusterRadius = 15;
			}
		}

		[HarmonyPatch(typeof(GeyserGenericConfig), "GenerateConfigs")]
		public class 增加新的泉
		{
			// Token: 0x0600000F RID: 15 RVA: 0x00002B38 File Offset: 0x00000D38
			private static void Postfix(ref List<GeyserGenericConfig.GeyserPrefabParams> __result) {
				Strings.Add(new string[] { "STRINGS.CREATURES.SPECIES.GEYSER." + "MOLTEN_URANIUM" + ".NAME", "铀火山" });
				Strings.Add(new string[] { "STRINGS.CREATURES.SPECIES.GEYSER." + "MOLTEN_URANIUM" + ".DESC", "一座大型火山,定期喷发出熔融铀" });
				Strings.Add(new string[] { "STRINGS.CREATURES.SPECIES.GEYSER." + "MOLTEN_STEEL" + ".NAME", "钢火山" });
				Strings.Add(new string[] { "STRINGS.CREATURES.SPECIES.GEYSER." + "MOLTEN_STEEL" + ".DESC", "一座大型火山,定期喷发出熔融钢" });
				Strings.Add(new string[] { "STRINGS.CREATURES.SPECIES.GEYSER." + "MOLTEN_GLASS" + ".NAME", "玻璃火山" });
				Strings.Add(new string[] { "STRINGS.CREATURES.SPECIES.GEYSER." + "MOLTEN_GLASS" + ".DESC", "一座大型火山,定期喷发出熔融玻璃" });
				Strings.Add(new string[] { "STRINGS.CREATURES.SPECIES.GEYSER." + "SUPER_COOLANT" + ".NAME", "超冷泉" });
				Strings.Add(new string[] { "STRINGS.CREATURES.SPECIES.GEYSER." + "SUPER_COOLANT" + ".DESC", "一座大型泉,定期喷发出超级冷却剂" });
				Strings.Add(new string[] { "STRINGS.CREATURES.SPECIES.GEYSER." + "PETROLEUM" + ".NAME", "石油泉" });
				Strings.Add(new string[] { "STRINGS.CREATURES.SPECIES.GEYSER." + "PETROLEUM" + ".DESC", "一座大型泉,定期喷发出石油" });
				Strings.Add(new string[] { "STRINGS.CREATURES.SPECIES.GEYSER." + "LIQUIDPHOSPHORUS" + ".NAME", "液磷泉" });
				Strings.Add(new string[] { "STRINGS.CREATURES.SPECIES.GEYSER." + "LIQUIDPHOSPHORUS" + ".DESC", "一座大型泉,定期喷发出液态磷" });
				Strings.Add(new string[] { "STRINGS.CREATURES.SPECIES.GEYSER." + "MOLTEN_CARBON" + ".NAME", "碳火山" });
				Strings.Add(new string[] { "STRINGS.CREATURES.SPECIES.GEYSER." + "MOLTEN_CARBON" + ".DESC", "一座大型火山,定期喷发出熔融碳" });
				Strings.Add(new string[] { "STRINGS.CREATURES.SPECIES.GEYSER." + "MOLTEN_SUCROSE" + ".NAME", "蔗糖泉" });
				Strings.Add(new string[] { "STRINGS.CREATURES.SPECIES.GEYSER." + "MOLTEN_SUCROSE" + ".DESC", "一座大型泉,定期喷发出熔融蔗糖" });
				for (int i = 0; i < 5; i++)
				{
					__result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_niobium_kanim", 3, 3, new GeyserConfigurator.GeyserType("molten_niobium", SimHashes.MoltenNiobium, GeyserConfigurator.GeyserShape.Molten, 2900f, 1000f, 2500f, 500f, 480f, 1080f, 0.016666668f, 0.1f, 15000f, 135000f, 0.4f, 0.8f, 372.15f, ""), true));
					__result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_gold_kanim", 3, 3, new GeyserConfigurator.GeyserType("molten_uranium", SimHashes.MoltenUranium, GeyserConfigurator.GeyserShape.Molten, 1000.15f, 800f, 1600f, 500f, 480f, 1080f, 0.016666668f, 0.1f, 15000f, 135000f, 0.4f, 0.8f, 372.15f, ""), true));
					__result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_iron_kanim", 3, 3, new GeyserConfigurator.GeyserType("molten_steel", SimHashes.MoltenSteel, GeyserConfigurator.GeyserShape.Molten, 2800f, 800f, 2000f, 500f, 480f, 1080f, 0.016666668f, 0.1f, 15000f, 135000f, 0.4f, 0.8f, 372.15f, ""), true));
					__result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_iron_kanim", 3, 3, new GeyserConfigurator.GeyserType("molten_glass", SimHashes.MoltenGlass, GeyserConfigurator.GeyserShape.Molten, 1800.15f, 800f, 1600f, 500f, 480f, 1080f, 0.016666668f, 0.1f, 15000f, 135000f, 0.4f, 0.8f, 372.15f, ""), true));
					__result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_water_hot_kanim", 4, 2, new GeyserConfigurator.GeyserType("super_coolant", SimHashes.SuperCoolant, GeyserConfigurator.GeyserShape.Liquid, 368.15f, 2000f, 4000f, 500f, 60f, 1140f, 0.1f, 0.9f, 15000f, 135000f, 0.4f, 0.8f, 372.15f, ""), true));
					__result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_oil_kanim", 4, 2, new GeyserConfigurator.GeyserType("Petroleum", SimHashes.Petroleum, GeyserConfigurator.GeyserShape.Liquid, 600f, 1000f, 2000f, 500f, 600f, 600f, 1f, 1f, 100f, 500f, 0.4f, 0.8f, 372.15f, ""), true));
					__result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_oil_kanim", 4, 2, new GeyserConfigurator.GeyserType("LiquidPhosphorus", SimHashes.LiquidPhosphorus, GeyserConfigurator.GeyserShape.Liquid, 450.15f, 1000f, 2000f, 500f, 600f, 600f, 1f, 1f, 100f, 500f, 0.4f, 0.8f, 372.15f, ""), true));
					__result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_iron_kanim", 3, 3, new GeyserConfigurator.GeyserType("molten_carbon", SimHashes.MoltenCarbon, GeyserConfigurator.GeyserShape.Molten, 4800.15f, 800f, 1600f, 500f, 480f, 1080f, 0.016666668f, 0.1f, 15000f, 135000f, 0.4f, 0.8f, 372.15f, ""), true));
					__result.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_water_filthy_kanim", 3, 3, new GeyserConfigurator.GeyserType("molten_sucrose", SimHashes.MoltenSucrose, GeyserConfigurator.GeyserShape.Molten, 458.15f, 800f, 1600f, 500f, 480f, 1080f, 0.016666668f, 0.1f, 15000f, 135000f, 0.4f, 0.8f, 372.15f, ""), true));
				}

			}
		}

		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
		[HarmonyPatch(typeof(GeyserConfigurator.GeyserType), MethodType.Constructor, new Type[] { typeof(string), typeof(SimHashes), typeof(GeyserShape), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float), typeof(string) })]
		class 修改泉属性 {
			public static void Prefix(ref string id, ref SimHashes element, ref GeyserShape shape, ref float temperature, ref float minRatePerCycle, ref float maxRatePerCycle, ref float maxPressure, ref float minIterationLength, ref float maxIterationLength, ref float minIterationPercent, ref float maxIterationPercent, ref float minYearLength, ref float maxYearLength, ref float minYearPercent, ref float maxYearPercent, ref float geyserTemperature, ref string DlcID)
			{
				if (minIterationLength > 1000) {
					minIterationLength = 480f;
					maxIterationLength = 1080f;
				}
				
				minRatePerCycle *= 3f;
				maxRatePerCycle *= 3f;
				minIterationPercent = 0.4f;
				maxIterationPercent = 0.5f;
				minYearLength *= 0.1f;
				maxYearLength *= 0.1f;
				minYearPercent = 0.4f;
				maxYearPercent = 0.5f;
				if (maxPressure < 500&& ElementLoader.FindElementByHash(element).IsLiquid){
					maxPressure = 500f;
				}
			}
		}
		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
		[HarmonyPatch(typeof(CeilingLightConfig), "CreateBuildingDef")]
		public class 冷光吸顶灯
		{
			// Token: 0x06000007 RID: 7 RVA: 0x000020B0 File Offset: 0x000002B0
			static void Postfix(CeilingLightConfig __instance, ref BuildingDef __result) {
				__result.EnergyConsumptionWhenActive = 0;
				__result.SelfHeatKilowattsWhenActive = 0;
			}
		}
		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

		[HarmonyPatch(typeof(Klei.AI.AttributeModifier), MethodType.Constructor, new Type[] { typeof(string), typeof(float), typeof(string), typeof(bool), typeof(bool), typeof(bool) })]
		public class 效果修改
		{
			// Token: 0x06000007 RID: 7 RVA: 0x000020B0 File Offset: 0x000002B0
			private static void Prefix(string attribute_id, ref float value, ref string description, ref bool is_multiplier, ref bool uiOnly, ref bool is_readonly)
			{
				if (attribute_id == Db.Get().Amounts.Wildness.deltaAttribute.Id) {
					if (value < 0) value = -1;//驯化更快
				}
				if (attribute_id == Db.Get().Amounts.Maturity.deltaAttribute.Id)
				{
					if (value > 0) value *= 2;//植物生长更快
				}
				if (attribute_id == Db.Get().CritterAttributes.Happiness.Id)
				{
					if (value < 0) value = 0;//防止拥挤影响
					if (value > 0) value *= 10;
				}
			}
		}
		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
		[HarmonyPatch(typeof(PlantableCellQuery), MethodType.Constructor)]
		public class 树鼠种植密度修改
		{
			// Token: 0x0600000F RID: 15 RVA: 0x0000218B File Offset: 0x0000038B
			private static void Postfix(ref int ___plantDetectionRadius, ref int ___maxPlantsInRadius)
			{
				___plantDetectionRadius = 100;
				___maxPlantsInRadius = 10000;
			}
		}
		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
		[HarmonyPatch(typeof(SeedPlantingMonitor.Def), MethodType.Constructor)]
		public class 树鼠种植速度修改
		{
			// Token: 0x0600000F RID: 15 RVA: 0x0000218B File Offset: 0x0000038B
			private static void Postfix(ref float ___searchMinInterval, ref float ___searchMaxInterval)
			{
				___searchMinInterval = 3;
				___searchMaxInterval = 6;
			}
		}
		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

		[HarmonyPatch(typeof(OvercrowdingMonitor), "IsConfined")]
		public class 动物防止封闭
		{
			private static void Postfix(ref bool __result)
			{
				__result = false;
			}
		}
		[HarmonyPatch(typeof(OvercrowdingMonitor), "IsOvercrowded")]
		public class 动物防止拥挤
		{
			private static void Postfix(ref bool __result)
			{
				__result = false;
			}
		}
		[HarmonyPatch(typeof(OvercrowdingMonitor), "IsFutureOvercrowded")]
		public class 动物防止蛋拥挤
		{
			private static void Postfix(ref bool __result)
			{
				__result = false;
			}
		}
		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
		[HarmonyPatch(typeof(EntityTemplates), "ExtendEntityToBasicPlant")]
		public class 自动收获
		{
			static bool init = false;
			private static void Prefix(ref GameObject template, ref float max_age, string crop_id, ref bool can_tinker, ref float temperature_lethal_low, ref float temperature_warning_low, ref float temperature_warning_high, ref float temperature_lethal_high, ref bool pressure_sensitive)
			{
				if (!init)
				{
					init = !init;
					Crop.CropVal[] crops = new Crop.CropVal[] {
					CROPS.CROP_TYPES.Find(i => i.cropId == "ColdWheatSeed") ,
					CROPS.CROP_TYPES.Find(i => i.cropId == "PlantMeat"),
					CROPS.CROP_TYPES.Find(i => i.cropId == "BeanPlantSeed"),
					CROPS.CROP_TYPES.Find(i => i.cropId == "Lettuce"),
					CROPS.CROP_TYPES.Find(i => i.cropId == "SpiceNut"),
					};


					for (int i = 0; i < crops.Count(); i++)
					{
						CROPS.CROP_TYPES.RemoveAll(t => t.cropId == crops[i].cropId);
						crops[i].cropDuration /= 4;
						crops[i].numProduced /= 2;
						CROPS.CROP_TYPES.Add(crops[i]);
					}
				}
				
				max_age = 3;//植物自动掉落
				can_tinker = true;//所有植物可被照料
				if (temperature_lethal_low > 101f) temperature_lethal_low -= 100f;
				if (temperature_warning_low > 101f) temperature_warning_low -= 100f;
				temperature_warning_high += 100f;
				temperature_lethal_high += 100f;
				pressure_sensitive = false;

			}
		}
		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
		//[HarmonyPatch(typeof(EntityTemplates), "ExtendEntityToBasicPlant")]
		//public class 植物生长周期
		//{
		//	static bool init = false;
		//	public static void Prefix(ref GameObject template)
		//	{
		//		if (!init)
		//		{
		//			init = !init;
		//			Crop.CropVal[] crops = new Crop.CropVal[] {
		//			CROPS.CROP_TYPES.Find(i => i.cropId == "ColdWheatSeed") ,
		//			CROPS.CROP_TYPES.Find(i => i.cropId == "PlantMeat"),
		//			CROPS.CROP_TYPES.Find(i => i.cropId == "BeanPlantSeed"),
		//			CROPS.CROP_TYPES.Find(i => i.cropId == "Lettuce") };
		//
		//			for (int i = 0; i < crops.Count(); i++)
		//			{
		//				CROPS.CROP_TYPES.RemoveAll(t => t.cropId == crops[i].cropId);
		//				crops[i].cropDuration /= 4;
		//				crops[i].numProduced /= 2;
		//				CROPS.CROP_TYPES.Add(crops[i]);
		//			}
		//		}
		//	}
		//}
		////|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

		[HarmonyPatch(typeof(Database.AttributeConverters), "Create")]
		public class 小人全局属性
		{
			private static void Prefix(ref float multiplier, ref float base_value) {
				base_value = 3f;
				multiplier *= 10f;
			}
		}
		[HarmonyPatch(typeof(Weapon), "Configure")]
		public class 小人全局武器初始化
		{
			private static void Prefix(ref float base_damage_min, ref float base_damage_max ,ref int maxHits)
			{
				base_damage_min *= 10; 
				base_damage_max *= 10;
				maxHits = 10;
			}
		}

		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
		[HarmonyPatch(typeof(MinionStartingStats), "GenerateTraits")]
		public class 小人获得更多特质
		{
			private static void Postfix(ref MinionStartingStats __instance) {
				using (List<DUPLICANTSTATS.TraitVal>.Enumerator enumerator = DUPLICANTSTATS.BADTRAITS.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						DUPLICANTSTATS.TraitVal traitVal1 = enumerator.Current;
						Trait item = __instance.Traits.Find((Trait entry) => entry.Id == traitVal1.id);
						if (!item.IsNullOrDestroyed()) __instance.Traits.Remove(item);
					}
				}
				foreach (DUPLICANTSTATS.TraitVal traitVal2 in DUPLICANTSTATS.GOODTRAITS)
				{
					Trait item2 = Db.Get().traits.TryGet(traitVal2.id);
					if (traitVal2.id != "GlowStick"&& traitVal2.id != "Uncultured")
					{
						if (!item2.IsNullOrDestroyed())
							__instance.Traits.Add(item2);
					}

				}
				foreach (DUPLICANTSTATS.TraitVal traitVal3 in DUPLICANTSTATS.GENESHUFFLERTRAITS)
				{
					Trait item3 = Db.Get().traits.TryGet(traitVal3.id);
					if (!item3.IsNullOrDestroyed())
						__instance.Traits.Add(item3);
				}
				foreach (DUPLICANTSTATS.TraitVal traitVal4 in DUPLICANTSTATS.JOYTRAITS)
				{
					Trait item4 = Db.Get().traits.TryGet(traitVal4.id);
					if (!item4.IsNullOrDestroyed())
						__instance.Traits.Add(item4);
				}
			}
		}
		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

		[HarmonyPatch(typeof(ElementLoader), "CopyEntryToElement")]
		public class 物质大一统
		{
			private static void Prefix(ref ElementLoader.ElementEntry entry, ref Element elem) {

				if (entry.thermalConductivity > 0f) entry.thermalConductivity *= 100;
				if (entry.defaultMass < 500 && entry.defaultMass > 1f) entry.defaultMass = 500;
				if (entry.elementId == "Niobium") entry.highTemp += 3000;
				if (entry.elementId == "Ceramic") entry.highTemp += 5000;
				if (entry.elementId == "TempConductorSolid") entry.highTemp += 3000;
				if (entry.elementId == "SuperInsulator") entry.thermalConductivity = 0;
				if (entry.elementId == "MoltenUranium") entry.lowTempTransitionTarget = "EnrichedUranium";

			}
		}
		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
		
		[HarmonyPatch(typeof(Immigration), "Sim200ms")]
		public class 打印舱周期
		{
			private static void Prefix(ref float dt)
			{
				dt *= 9;
			}
		}
		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
		[HarmonyPatch(typeof(CarePackageInfo), MethodType.Constructor, new Type[] { typeof(string), typeof(float), typeof(Func<bool>) })]
		public class 打印舱无需发现物品
		{
			private static void Prefix(ref string ID, ref float amount, ref Func<bool> requirement)
			{
				requirement = null;
			}
		}
		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
		[HarmonyPatch(typeof(HeadquartersConfig), "ConfigureBuildingTemplate")]
		public class 打印舱添加新的物品
		{
			private static void Postfix(ref GameObject go)
			{

				go.AddOrGet<DropAllWorkable>();
				go.AddOrGet<BuildingComplete>().isManuallyOperated = false;
				ComplexFabricator complexFabricator = go.AddOrGet<ComplexFabricator>();
				complexFabricator.sideScreenStyle = ComplexFabricatorSideScreen.StyleSetting.ListQueueHybrid;
				complexFabricator.duplicantOperated = true;
				go.AddOrGet<FabricatorIngredientStatusManager>();
				go.AddOrGet<CopyBuildingSettings>();
				ComplexFabricatorWorkable complexFabricatorWorkable = go.AddOrGet<ComplexFabricatorWorkable>();
				BuildingTemplates.CreateComplexFabricatorStorage(go, complexFabricator);
				complexFabricatorWorkable.overrideAnims = new KAnimFile[]{Assets.GetAnim("anim_interacts_rockrefinery_kanim")};
				complexFabricatorWorkable.workingPstComplete = new HashedString[]{"working_pst_complete"};

				Tag[] tags = new Tag[]{
					"BasicFabricMaterialPlantSeed".ToTag(),		  //"顶针芦苇种子",
					"BasicSingleHarvestPlantSeed".ToTag(),		  //"米虱木种子",
					"BeanPlantSeed".ToTag(),					  //"小吃豆",
					"BulbPlantSeed".ToTag(),					  //"同伴芽种子",
					"CactusPlantSeed".ToTag(),					  //"雀跃掌种子",
					"ColdBreatherSeed".ToTag(),					  //"冰息萝卜种子",
					"ColdWheatSeed".ToTag(),					  //"冰霜麦粒",
					"CritterTrapPlantSeed".ToTag(),				  //"土星动物捕捉草种子",
					"CylindricaSeed".ToTag(),					  //"极乐刺种子",
					"EvilFlowerSeed".ToTag(),					  //"孢子兰种子",
					"FilterPlantSeed".ToTag(),					  //"仙水掌种子",
					"ForestTreeSeed".ToTag(),					  //"乔木橡实",
					"GasGrassSeed".ToTag(),						  //"释气草种子",
					"LeafyPlantSeed".ToTag(),					  //"欢乐叶种子",
					"MushroomSeed".ToTag(),						  //"真菌孢子",
					"OxyfernSeed".ToTag(),						  //"氧齿蕨种子",
					"PrickleFlowerSeed".ToTag(),				  //"毛刺花种子",
					"PrickleGrassSeed".ToTag(),					  //"诱人荆棘种子",
					"SaltPlantSeed".ToTag(),					  //"沙盐藤种子",
					"SeaLettuceSeed".ToTag(),					  //"水草种子",
					"SpiceVineSeed".ToTag(),					  //"火椒种子",
					"SwampHarvestPlantSeed".ToTag(),			  //"沼浆笼种子",
					"SwampLilySeed".ToTag(),					  //"芳香百合种子",
					"ToePlantSeed".ToTag(),						  //"安止宁种子",
					"WineCupsSeed".ToTag(),						  //"醇锦菇种子",
					"WormPlantSeed".ToTag(),                      //"虫果种子"
					"Hatch".ToTag(),							  //哈奇
					"LightBug".ToTag(),							  //发光虫
					"OilFloater".ToTag(),						  //浮游生物
					"Drecko".ToTag(),							  //
					"Glom".ToTag(),								  //
					"Puft".ToTag(),								  //
					"Pacu".ToTag(),								  //帕库鱼
					"Moo".ToTag(),								  //
					"Mole".ToTag(),								  //
					"Squirrel".ToTag(),							  //
					"Crab".ToTag(),								  //
					"Staterpillar".ToTag(),						  //
					"BeeBaby".ToTag(),							  //
					"DivergentBeetle".ToTag()					  //
				};
				String[] strings = new String[] {
				"顶针芦苇种子",
				"米虱木种子",
				"小吃豆",
				"同伴芽种子",
				"雀跃掌种子",
				"冰息萝卜种子",
				"冰霜麦粒",
				"土星动物捕捉草种子",
				"极乐刺种子",
				"孢子兰种子",
				"仙水掌种子",
				"乔木橡实",
				"释气草种子",
				"欢乐叶种子",
				"真菌孢子",
				"氧齿蕨种子",
				"毛刺花种子",
				"诱人荆棘种子",
				"沙盐藤种子",
				"水草种子",
				"火椒种子",
				"沼浆笼种子",
				"芳香百合种子",
				"安止宁种子",
				"醇锦菇种子",
				"虫果种子"
				};
				int i = 0;
				foreach (Tag tag in tags){
					Element element = ElementLoader.FindElementByHash((SimHashes)SimHashes.Niobium);
					ComplexRecipe.RecipeElement[] array1 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement(element.tag, 1000f) };
					ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement(tag, 1f) };
					string obsolete_id = ComplexRecipeManager.MakeObsoleteRecipeID("Headquarters", array1[0].material);
					string text = ComplexRecipeManager.MakeRecipeID("Headquarters", array1, array2);
					ComplexRecipe complexRecipe = new ComplexRecipe(text, array1, array2);
					complexRecipe.time = 1f;
					if(i< strings.Count()) complexRecipe.description = string.Format("兑换 {0}", strings[i]);
					else complexRecipe.description = string.Format("兑换 {0}", tag.Name);
					complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;
					complexRecipe.fabricators = new List<Tag> { TagManager.Create("Headquarters") };
					ComplexRecipeManager.Get().AddObsoleteIDMapping(obsolete_id, text);
					i++;
				}

			}
		}
		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

		[HarmonyPatch(typeof(HydrogenEngineClusterConfig), "CreateBuildingDef")]
		public class 液氢引擎改造1
		{
			private static void Postfix(ref BuildingDef __result)
			{
				__result.UtilityInputOffset = new CellOffset(2, 3);
				__result.InputConduitType = ConduitType.Liquid;
			}
		}
		[HarmonyPatch(typeof(HydrogenEngineClusterConfig), "DoPostConfigureComplete")]
		public class 液氢引擎改造2
		{
			private static void Postfix(ref GameObject go)
			{
				Storage storage = go.AddOrGet<Storage>();
				storage.capacityKg = 10f * TUNING.BUILDINGS.ROCKETRY_MASS_KG.FUEL_TANK_WET_MASS[0];
				storage.SetDefaultStoredItemModifiers(new List<Storage.StoredItemModifier>
				{
					Storage.StoredItemModifier.Hide,
					Storage.StoredItemModifier.Seal,
					Storage.StoredItemModifier.Insulate
				});
				FuelTank fuelTank = go.AddOrGet<FuelTank>();
				fuelTank.consumeFuelOnLand = !DlcManager.FeatureClusterSpaceEnabled();
				fuelTank.storage = storage;
				fuelTank.FuelType = ElementLoader.FindElementByHash(SimHashes.LiquidHydrogen).tag;
				fuelTank.physicalFuelCapacity = storage.capacityKg;
				go.AddOrGet<CopyBuildingSettings>();
				ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
				conduitConsumer.conduitType = ConduitType.Liquid;
				conduitConsumer.consumptionRate = 1000f;
				conduitConsumer.capacityTag = fuelTank.FuelType;
				conduitConsumer.capacityKG = storage.capacityKg;
				conduitConsumer.forceAlwaysSatisfied = true;
				conduitConsumer.wrongElementResult = ConduitConsumer.WrongElementResult.Dump;
			}
		}
		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

		[HarmonyPatch(typeof(HeadquartersConfig), "CreateBuildingDef")]
		public class 遗弃者基地1
		{
			private static void Postfix(ref BuildingDef __result)
			{
				__result.GeneratorWattageRating = 1000f;
				__result.GeneratorBaseCapacity = 20000f;
				__result.RequiresPowerOutput = true;
				__result.PowerOutputOffset = new CellOffset(0, 0);
				__result.ViewMode = OverlayModes.Power.ID;
			}
		}
		[HarmonyPatch(typeof(HeadquartersConfig), "ConfigureBuildingTemplate")]
		public class 遗弃者基地2
		{
			private static void Postfix(ref GameObject go, ref Tag prefab_tag)
			{
				CellOffset cellOffset = new CellOffset(0, 1);
				ElementEmitter elementEmitter = go.AddOrGet<ElementEmitter>();
				elementEmitter.outputElement = new ElementConverter.OutputElement(0.5f, SimHashes.Oxygen, 303.15f, false, false, (float)cellOffset.x, (float)cellOffset.y, 1f, byte.MaxValue, 0, true);
				elementEmitter.emissionFrequency = 1f;
				elementEmitter.maxPressure = 2.5f;
				DevGenerator devGenerator = go.AddOrGet<DevGenerator>();
				devGenerator.powerDistributionOrder = 9;
				devGenerator.wattageRating = 1000f;
			}
		}
		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

		[HarmonyPatch(typeof(Storage), MethodType.Constructor)]
		public class 更大储存箱
		{
			private static void Postfix(ref float ___capacityKg)
			{
				___capacityKg = 2000000f;
			}
		}

		[HarmonyPatch(typeof(LiquidReservoirConfig), "ConfigureBuildingTemplate")]
		public class 储液库修改
		{
			private static void Postfix(ref GameObject go, ref Tag prefab_tag)
			{
				Storage storage = go.AddOrGet<Storage>();
				storage.capacityKg = 1000000f;
				storage.allowItemRemoval = true;
				storage.storageFullMargin = STORAGE.STORAGE_LOCKER_FILLED_MARGIN;
				storage.fetchCategory = Storage.FetchCategory.GeneralStorage;
				ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
				conduitConsumer.capacityKG = storage.capacityKg;
				go.AddOrGet<CopyBuildingSettings>().copyGroupTag = GameTags.StorageLocker;
				go.AddOrGet<StorageLocker>();
				go.AddOrGet<UserNameable>();
				go.AddOrGetDef<RocketUsageRestriction.Def>();
			}
		}

		[HarmonyPatch(typeof(GasReservoirConfig), "ConfigureBuildingTemplate")]
		public class 储气库修改
		{
			private static void Postfix(ref GameObject go, ref Tag prefab_tag)
			{
				Storage storage = go.AddOrGet<Storage>();
				storage.capacityKg = 1000000f;
				storage.allowItemRemoval = true;
				storage.storageFullMargin = STORAGE.STORAGE_LOCKER_FILLED_MARGIN;
				storage.fetchCategory = Storage.FetchCategory.GeneralStorage;
				ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
				conduitConsumer.capacityKG = storage.capacityKg;
				go.AddOrGet<CopyBuildingSettings>().copyGroupTag = GameTags.StorageLocker;
				go.AddOrGet<StorageLocker>();
				go.AddOrGet<UserNameable>();
				go.AddOrGetDef<RocketUsageRestriction.Def>();
			}
		}

		//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
		[HarmonyPatch(typeof(LiquidHeaterConfig), "CreateBuildingDef")]
		public class 液体加热器效率
		{
			private static void Postfix(ref BuildingDef __result) {
				__result.Overheatable = false;
				__result.ExhaustKilowattsWhenActive *= 10;
			}
		}
		[HarmonyPatch(typeof(LiquidHeaterConfig), "ConfigureBuildingTemplate")]
		public class 液体加热器目标温度
		{
			private static void Postfix(ref GameObject go, Tag prefab_tag)
			{
				SpaceHeater spaceHeater = go.AddOrGet<SpaceHeater>();
				spaceHeater.targetTemperature = 9999f;
			}
		}

		[HarmonyPatch(typeof(SpaceHeaterConfig), "CreateBuildingDef")]
		public class 空间加热器
		{
			private static void Postfix(ref BuildingDef __result)
			{
				__result.Overheatable = false;
				__result.ExhaustKilowattsWhenActive *= 10;
			}
		}
		[HarmonyPatch(typeof(SpaceHeaterConfig), "ConfigureBuildingTemplate")]
		public class 空间加热器目标温度
		{
			private static void Postfix(ref GameObject go, Tag prefab_tag)
			{
				SpaceHeater spaceHeater = go.AddOrGet<SpaceHeater>();
				spaceHeater.targetTemperature = 9999f;
			}
		}

		[HarmonyPatch(typeof(InsulatedLiquidConduitConfig), "CreateBuildingDef")]
		public class 绝热液体管道
		{
			private static void Postfix(ref BuildingDef __result)
			{
				__result.ThermalConductivity = 0f;
			}
		}

		[HarmonyPatch(typeof(InsulatedGasConduitConfig), "CreateBuildingDef")]
		public class 绝热气体管道
		{
			private static void Postfix(ref BuildingDef __result)
			{
				__result.ThermalConductivity = 0f;
			}
		}

		[HarmonyPatch(typeof(InsulationTileConfig), "CreateBuildingDef")]
		public class 绝热砖
		{
			private static void Postfix(ref BuildingDef __result)
			{
				__result.ThermalConductivity = 0f;
			}
		}

		[HarmonyPatch(typeof(SpeedControlScreen), "OnChanged")]
		public class 无极变速
		{
			private static void Postfix(ref SpeedControlScreen __instance)
			{

				if (__instance.IsPaused)
				{
					Time.timeScale = 0f;
					return;
				}
				if (__instance.GetSpeed() == 0)
				{
					Time.timeScale = __instance.normalSpeed;
					return;
				}
				if (__instance.GetSpeed() == 1)
				{
					Time.timeScale = __instance.fastSpeed * 2;
					return;
				}
				if (__instance.GetSpeed() == 2)
				{
					Time.timeScale = __instance.ultraSpeed * 4;
				}
			}
		}

		[HarmonyPatch(typeof(EthanolDistilleryConfig), "ConfigureBuildingTemplate")]
		public class 乙醇蒸馏器效率
		{
			private static void Postfix(ref GameObject go, ref Tag prefab_tag)
			{
				ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
				elementConverter.consumedElements[0].MassConsumptionRate *= 10;
				elementConverter.outputElements[0].massGenerationRate *= 10;
				elementConverter.outputElements[1].massGenerationRate *= 10;
				elementConverter.outputElements[2].massGenerationRate *= 10;
			}
		}

		[HarmonyPatch(typeof(ConduitFlow), MethodType.Constructor, new Type[] { typeof(ConduitType), typeof(int), typeof(IUtilityNetworkMgr), typeof(float), typeof(float) })]
		public class 更粗管道
		{
			private static void Prefix(ref ConduitType conduit_type, ref int num_cells, ref IUtilityNetworkMgr network_mgr, ref float max_conduit_mass, ref float initial_elapsed_time){
				max_conduit_mass *= 10;
			}
		}

		[HarmonyPatch(typeof(PrimaryElement), MethodType.Constructor)]
		public class 更大团物质
		{
			private static void Prefix(ref float ___MAX_MASS)
			{
				___MAX_MASS = 1000000f;
			}
		}


		[HarmonyPatch(typeof(GlassForgeConfig), "ConfigureBuildingTemplate")]
		public class 高频电炉
		{
			private static void Postfix(ref GameObject go){
				go.AddOrGet<GlassForge>().duplicantOperated = false;

				foreach (int hash in Enum.GetValues(typeof(SimHashes))){
					Element element= ElementLoader.FindElementByHash((SimHashes)hash);
                    if ((SimHashes)hash !=SimHashes.Sand&& element.IsSolid && element.highTempTransitionTarget != 0){
						Element elementhigh = ElementLoader.FindElementByHash(element.highTempTransitionTarget);
						if (elementhigh.IsLiquid)
						{
							ComplexRecipe.RecipeElement[] Array1 = new ComplexRecipe.RecipeElement[]{
						new ComplexRecipe.RecipeElement(element.tag, 100f)};
							ComplexRecipe.RecipeElement[] Array2 = new ComplexRecipe.RecipeElement[]{
						new ComplexRecipe.RecipeElement(elementhigh.tag, 100f, ComplexRecipe.RecipeElement.TemperatureOperation.Melted, false)};

							string obsolete_id = ComplexRecipeManager.MakeObsoleteRecipeID("GlassForge", Array1[0].material);
							string text = ComplexRecipeManager.MakeRecipeID("GlassForge", Array1, Array2);
							ComplexRecipe complexRecipe = new ComplexRecipe(text, Array1, Array2);
							complexRecipe.time = 5f;
							complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
							complexRecipe.description = string.Format(STRINGS.BUILDINGS.PREFABS.GLASSFORGE.RECIPE_DESCRIPTION, ElementLoader.GetElement(Array2[0].material).name, ElementLoader.GetElement(Array1[0].material).name);
							complexRecipe.fabricators = new List<Tag> { TagManager.Create("GlassForge") };
							ComplexRecipeManager.Get().AddObsoleteIDMapping(obsolete_id, text);
						}
					}
					else Console.Out.WriteLine("Get Eelement Faild\n");
				}
			}
		}


		[HarmonyPatch(typeof(SteamTurbineConfig2), "DoPostConfigureComplete")]
		public class 蒸汽机吸取速度
		{
			private static void Postfix(ref GameObject go)
			{
				SteamTurbine steamTurbine = go.AddOrGet<SteamTurbine>();
				steamTurbine.pumpKGRate *=10f;
				steamTurbine.wasteHeatToTurbinePercent *= 0.1f;
			}
		}
		[HarmonyPatch(typeof(SteamTurbine), MethodType.Constructor)]
		public class 蒸汽机吸取最小温度
		{
			private static void Postfix(ref float ___minActiveTemperature,ref float ___idealSourceElementTemperature,ref float ___maxBuildingTemperature)
			{
				___minActiveTemperature = 370.15f;
				___idealSourceElementTemperature = 373.15f;
				___maxBuildingTemperature = 473.15f;
			}
		}

		[HarmonyPatch(typeof(AirConditioner), "UpdateState")]
		public class 液冷机最低温度
		{
			// Token: 0x06000068 RID: 104 RVA: 0x00003A3C File Offset: 0x00001C3C
			private static void Prefix(ref AirConditioner __instance)
			{
				List<GameObject> items = __instance.GetComponent<Storage>().items;
				for (int i = 0; i < items.Count; i++)
				{
					PrimaryElement component = items[i].GetComponent<PrimaryElement>();
					bool flag = component.Mass > 0f && (!__instance.isLiquidConditioner || !component.Element.IsGas) && (__instance.isLiquidConditioner || !component.Element.IsLiquid);
					if (flag)
					{
						bool flag2 = component.Temperature < component.Element.lowTemp + 2f;
						if (flag2)
						{
							__instance.temperatureDelta = 0f;
							
						}
						else
						{
							bool flag3 = component.Temperature < component.Element.lowTemp + 12f;
							bool flag4 = component.Temperature < component.Element.lowTemp + 24f;
							if (flag3)
							{
								__instance.temperatureDelta = -2f;
							}
							else if(flag4)
							{
								__instance.temperatureDelta = -14f;
                            }
                            else
                            {
								__instance.temperatureDelta = -28f;
							}
						}
						break;
					}
				}
			}
		}

		[HarmonyPatch(typeof(WireRefinedHighWattageConfig), "CreateBuildingDef")]
		public class 高负荷导线穿墙{
			private static void Postfix(ref BuildingDef __result){
				__result.BuildLocationRule= BuildLocationRule.Anywhere;
			}
		}
		[HarmonyPatch(typeof(WireHighWattageConfig), "CreateBuildingDef")]
		public class 高负荷电线穿墙{
			private static void Postfix(ref BuildingDef __result){
				__result.BuildLocationRule = BuildLocationRule.Anywhere;
			}
		}

		[HarmonyPatch(typeof(NuclearResearchCenterConfig), "CreateBuildingDef")]
		public class 材料研究终端可旋转
		{
			private static void Postfix(ref BuildingDef __result)
			{
				__result.PermittedRotations = PermittedRotations.FlipH;
			}
		}

		[HarmonyPatch(typeof(WorldDamage), "OnDigComplete")]
		public class 挖掘不损失质量
		{
			private static void Prefix(ref float mass)
			{
				mass *= 2;
			}
		}

	}
}
