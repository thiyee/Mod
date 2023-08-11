using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GeyserConfigurator;

namespace 修改泉属性
{
	[HarmonyPatch(typeof(GeyserConfigurator.GeyserType), MethodType.Constructor, new Type[] { typeof(string), typeof(SimHashes), typeof(GeyserShape), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float), typeof(string) })]
	class 修改泉属性
	{
		public static void Prefix(ref string id, ref SimHashes element, ref GeyserShape shape, ref float temperature, ref float minRatePerCycle, ref float maxRatePerCycle, ref float maxPressure, ref float minIterationLength, ref float maxIterationLength, ref float minIterationPercent, ref float maxIterationPercent, ref float minYearLength, ref float maxYearLength, ref float minYearPercent, ref float maxYearPercent, ref float geyserTemperature, ref string DlcID)
		{
			if (minIterationLength > 1000)
			{
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
			if (maxPressure < 500 && ElementLoader.FindElementByHash(element).IsLiquid)
			{
				maxPressure = 500f;
			}
		}
	}
}
