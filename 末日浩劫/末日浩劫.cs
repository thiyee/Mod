using Database;
using HarmonyLib;
using Klei.AI;
using Klei.CustomSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 末日浩劫
{
	//[HarmonyPatch(typeof(MeteorShowerEvent), MethodType.Constructor)]
	//public class 末日浩劫
	//{
	//	public static void Prefix(ref float duration)
	//	{
	//
	//		SettingLevel currentQualitySetting = CustomGameSettings.Instance.GetCurrentQualitySetting(CustomGameSettingConfigs.MeteorShowers);
	//		if (currentQualitySetting != null&& currentQualitySetting.id== "Doomed") {
	//			duration = duration;
	//
	//		}
	//			
	//	}
	//}
	/*[HarmonyPatch(typeof(MeteorShowerSeason), MethodType.Constructor, new Type[] { typeof(string), typeof(GameplaySeason.Type), typeof(string), typeof(float), typeof(bool), typeof(float), typeof(bool), typeof(int), typeof(float), typeof(float), typeof(int), typeof(bool), typeof(float) })]
	public class 流行抵达时间
	{
		public static void Prefix(string id, GameplaySeason.Type type, string dlcId, float period, bool synchronizedToPeriod, float randomizedEventStartTime, bool startActive, int finishAfterNumEvents, float minCycle, float maxCycle, int numEventsToStartEachPeriod, bool affectedByDifficultySettings, float clusterTravelDuration)
		{

			SettingLevel currentQualitySetting = CustomGameSettings.Instance.GetCurrentQualitySetting(CustomGameSettingConfigs.MeteorShowers);
			if (currentQualitySetting != null && currentQualitySetting.id == "Doomed")
			{
				clusterTravelDuration =600;

			}

		}
	}*/
	[HarmonyPatch(typeof(GameplaySeasons), "Expansion1Seasons")]
	public class 流行抵达时间
	{
		public static void Postfix(ref GameplaySeasons __instance)
		{

			((MeteorShowerSeason)__instance.RegolithMoonMeteorShowers ).clusterTravelDuration /=10;
			((MeteorShowerSeason)__instance.TemporalTearMeteorShowers ).clusterTravelDuration /=10;
			((MeteorShowerSeason)__instance.GassyMooteorShowers ).clusterTravelDuration /=10;
			((MeteorShowerSeason)__instance.SpacedOutStyleStartMeteorShowers ).clusterTravelDuration /=10;
			((MeteorShowerSeason)__instance.SpacedOutStyleRocketMeteorShowers ).clusterTravelDuration /=10;
			((MeteorShowerSeason)__instance.SpacedOutStyleWarpMeteorShowers ).clusterTravelDuration /=10;
			((MeteorShowerSeason)__instance.ClassicStyleStartMeteorShowers ).clusterTravelDuration /=10;
			((MeteorShowerSeason)__instance.ClassicStyleWarpMeteorShowers ).clusterTravelDuration /=10;
			((MeteorShowerSeason)__instance.TundraMoonletMeteorShowers ).clusterTravelDuration /=10;
			((MeteorShowerSeason)__instance.MarshyMoonletMeteorShowers ).clusterTravelDuration /=10;
			((MeteorShowerSeason)__instance.NiobiumMoonletMeteorShowers ).clusterTravelDuration /=10;
			((MeteorShowerSeason)__instance.WaterMoonletMeteorShowers ).clusterTravelDuration /=10;
			((MeteorShowerSeason)__instance.MiniMetallicSwampyMeteorShowers ).clusterTravelDuration /=10;
			((MeteorShowerSeason)__instance.MiniForestFrozenMeteorShowers ).clusterTravelDuration /=10;
			((MeteorShowerSeason)__instance.MiniBadlandsMeteorShowers ).clusterTravelDuration /=10;
			((MeteorShowerSeason)__instance.MiniFlippedMeteorShowers ).clusterTravelDuration /=10;
			((MeteorShowerSeason)__instance.MiniRadioactiveOceanMeteorShowers ).clusterTravelDuration /=10;

			((MeteorShowerSeason)__instance.RegolithMoonMeteorShowers).period = 3;
			((MeteorShowerSeason)__instance.TemporalTearMeteorShowers).period =3;
			((MeteorShowerSeason)__instance.GassyMooteorShowers).period =3;
			((MeteorShowerSeason)__instance.SpacedOutStyleStartMeteorShowers).period =3;
			((MeteorShowerSeason)__instance.SpacedOutStyleRocketMeteorShowers).period =3;
			((MeteorShowerSeason)__instance.SpacedOutStyleWarpMeteorShowers).period =3;
			((MeteorShowerSeason)__instance.ClassicStyleStartMeteorShowers).period =3;
			((MeteorShowerSeason)__instance.ClassicStyleWarpMeteorShowers).period =3;
			((MeteorShowerSeason)__instance.TundraMoonletMeteorShowers).period =3;
			((MeteorShowerSeason)__instance.MarshyMoonletMeteorShowers).period =3;
			((MeteorShowerSeason)__instance.NiobiumMoonletMeteorShowers).period =3;
			((MeteorShowerSeason)__instance.WaterMoonletMeteorShowers).period =3;
			((MeteorShowerSeason)__instance.MiniMetallicSwampyMeteorShowers).period =3;
			((MeteorShowerSeason)__instance.MiniForestFrozenMeteorShowers).period =3;
			((MeteorShowerSeason)__instance.MiniBadlandsMeteorShowers).period =3;
			((MeteorShowerSeason)__instance.MiniFlippedMeteorShowers).period =3;
			((MeteorShowerSeason)__instance.MiniRadioactiveOceanMeteorShowers).period =3;


			//SettingLevel currentQualitySetting = CustomGameSettings.Instance.GetCurrentQualitySetting(CustomGameSettingConfigs.MeteorShowers);
			//if (currentQualitySetting != null && currentQualitySetting.id == "Doomed")
			//{
			//	___clusterTravelDuration = 600;
			//
			//}

		}
	}
}
