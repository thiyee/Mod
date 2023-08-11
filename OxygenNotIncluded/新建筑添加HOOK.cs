using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Klei.AI;
using KMod;
using KSerialization;
using ProcGenGame;
using TUNING;
using UnityEngine;
using static GeyserConfigurator;

namespace OxygenNotIncluded{

    [HarmonyPatch(typeof(GeneratedBuildings),"LoadGeneratedBuildings")]
    class 添加建筑{

        public static void Prefix() {
            Strings.Add(new string[] { "STRINGS.BUILDINGS.PREFABS.方块墙.NAME", "方块墙" });
            Strings.Add(new string[] { "STRINGS.BUILDINGS.PREFABS.方块墙.EFFECT", "方块墙" });
            Strings.Add(new string[] { "STRINGS.BUILDINGS.PREFABS.方块墙.DESC", "建造一个自然土块" });

            Strings.Add(new string[] { "STRINGS.BUILDINGS.PREFABS.气泵-气吞山河.NAME", "气泵-气吞山河" });
            Strings.Add(new string[] { "STRINGS.BUILDINGS.PREFABS.气泵-气吞山河.EFFECT", "气泵-气吞山河" });
            Strings.Add(new string[] { "STRINGS.BUILDINGS.PREFABS.气泵-气吞山河.DESC", "大一统建筑，造价昂贵" });

            ModUtil.AddBuildingToPlanScreen("Base", "方块墙");
            ModUtil.AddBuildingToPlanScreen("HVAC", "气泵-气吞山河");
        }

    }
}
