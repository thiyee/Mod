using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 自动收获
{
	[HarmonyPatch(typeof(EntityTemplates), "ExtendEntityToBasicPlant")]
	public class 自动收获
	{
		private static void Prefix(ref GameObject template, ref float max_age, string crop_id, ref bool can_tinker, ref float temperature_lethal_low, ref float temperature_warning_low, ref float temperature_warning_high, ref float temperature_lethal_high, ref bool pressure_sensitive)
		{

			max_age = 3;//植物自动掉落

		}
	}
}
