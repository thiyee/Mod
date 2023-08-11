using ProcGen;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcGenGame;
using static ProcGen.SubWorld;

namespace 虚空入侵
{
	[HarmonyPatch(typeof(WorldGen), "RenderOffline")]
	public class 虚空入侵
    {
		static bool isinit = false;

		private static void Prefix(ref WorldGen __instance){
            if (!isinit && __instance.isStartingWorld)
                SetRandomFifthNodesToSpace(ref __instance);
        }

        public static void SetRandomFifthNodesToSpace(ref WorldGen __instance)
        {
            // 获取 __instance.data.overworldCells 的引用
            List<TerrainCell> overworldCells = __instance.data.overworldCells;

            // 计算需要更改的节点数量
            int numNodesToChange = overworldCells.Count / 5;

            // 创建一个随机数生成器
            Random random = new Random();

            // 获取第0个节点的 zoneType
            ZoneType firstNodeZoneType = SettingsCache.GetCachedSubWorld(overworldCells[0].node.type).zoneType;

            // 创建一个 HashSet 用于存储已经被选中的索引，以避免重复选择
            HashSet<int> chosenIndices = new HashSet<int>();

            // 设置节点之间的最小间隔，以尽量分散选择的节点
            int minSeparation = overworldCells.Count / (numNodesToChange * 2);

            // 更改五分之一的节点类型
            for (int i = 0; i < numNodesToChange; i++)
            {
                int randomIndex;
                ZoneType currentNodeZoneType;
                bool isSeparated;

                // 在未被选择的索引中生成一个随机索引
                do
                {
                    randomIndex = random.Next(1, overworldCells.Count);
                    currentNodeZoneType = SettingsCache.GetCachedSubWorld(overworldCells[randomIndex].node.type).zoneType;
                    isSeparated = true;

                    // 检查新选择的索引是否与已选择的索引之间有足够的间隔
                    foreach (int chosenIndex in chosenIndices)
                    {
                        if (Math.Abs(chosenIndex - randomIndex) < minSeparation)
                        {
                            isSeparated = false;
                            break;
                        }
                    }
                } while (chosenIndices.Contains(randomIndex) || currentNodeZoneType == ZoneType.Space || currentNodeZoneType == firstNodeZoneType || !isSeparated);

                // 将随机索引添加到 chosenIndices 集合中
                chosenIndices.Add(randomIndex);

                // 设置选定节点的类型为 "subworlds/space/Space"
                overworldCells[randomIndex].node.SetType("subworlds/space/Space");
            }
        }
    }
}
