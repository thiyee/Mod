using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 精准采集
{
	[HarmonyPatch(typeof(WorldDamage), "OnDigComplete")]
	public class 挖掘不损失质量
	{
		private static void Prefix(ref float mass)
		{
			mass *= 2;
		}
	}
}
