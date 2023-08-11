using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxygenNotIncluded
{
    class 建筑栏{
		/*
         public class BUILDCATEGORIES
		{
			// Token: 0x0200252F RID: 9519
			public static class BASE
			{
				// Token: 0x0400A368 RID: 41832
				public static LocString NAME = UI.FormatAsLink("Base", "BUILDCATEGORYBASE");

				// Token: 0x0400A369 RID: 41833
				public static LocString TOOLTIP = "Maintain the colony's infrastructure with these homebase basics. {Hotkey}";
			}

			// Token: 0x02002530 RID: 9520
			public static class CONVEYANCE
			{
				// Token: 0x0400A36A RID: 41834
				public static LocString NAME = UI.FormatAsLink("Shipping", "BUILDCATEGORYCONVEYANCE");

				// Token: 0x0400A36B RID: 41835
				public static LocString TOOLTIP = "Transport ore and solid materials around my base. {Hotkey}";
			}

			// Token: 0x02002531 RID: 9521
			public static class OXYGEN
			{
				// Token: 0x0400A36C RID: 41836
				public static LocString NAME = UI.FormatAsLink("Oxygen", "BUILDCATEGORYOXYGEN");

				// Token: 0x0400A36D RID: 41837
				public static LocString TOOLTIP = "Everything I need to keep the colony breathing. {Hotkey}";
			}

			// Token: 0x02002532 RID: 9522
			public static class POWER
			{
				// Token: 0x0400A36E RID: 41838
				public static LocString NAME = UI.FormatAsLink("Power", "BUILDCATEGORYPOWER");

				// Token: 0x0400A36F RID: 41839
				public static LocString TOOLTIP = "Need to power the colony? Here's how to do it! {Hotkey}";
			}

			// Token: 0x02002533 RID: 9523
			public static class FOOD
			{
				// Token: 0x0400A370 RID: 41840
				public static LocString NAME = UI.FormatAsLink("Food", "BUILDCATEGORYFOOD");

				// Token: 0x0400A371 RID: 41841
				public static LocString TOOLTIP = "Keep my Duplicants' spirits high and their bellies full. {Hotkey}";
			}

			// Token: 0x02002534 RID: 9524
			public static class UTILITIES
			{
				// Token: 0x0400A372 RID: 41842
				public static LocString NAME = UI.FormatAsLink("Utilities", "BUILDCATEGORYUTILITIES");

				// Token: 0x0400A373 RID: 41843
				public static LocString TOOLTIP = "Heat up and cool down. {Hotkey}";
			}

			// Token: 0x02002535 RID: 9525
			public static class PLUMBING
			{
				// Token: 0x0400A374 RID: 41844
				public static LocString NAME = UI.FormatAsLink("Plumbing", "BUILDCATEGORYPLUMBING");

				// Token: 0x0400A375 RID: 41845
				public static LocString TOOLTIP = "Get the colony's water running and its sewage flowing. {Hotkey}";
			}

			// Token: 0x02002536 RID: 9526
			public static class HVAC
			{
				// Token: 0x0400A376 RID: 41846
				public static LocString NAME = UI.FormatAsLink("Ventilation", "BUILDCATEGORYHVAC");

				// Token: 0x0400A377 RID: 41847
				public static LocString TOOLTIP = "Control the flow of gas in the base. {Hotkey}";
			}

			// Token: 0x02002537 RID: 9527
			public static class REFINING
			{
				// Token: 0x0400A378 RID: 41848
				public static LocString NAME = UI.FormatAsLink("Refinement", "BUILDCATEGORYREFINING");

				// Token: 0x0400A379 RID: 41849
				public static LocString TOOLTIP = "Use the resources I want, filter the ones I don't. {Hotkey}";
			}

			// Token: 0x02002538 RID: 9528
			public static class ROCKETRY
			{
				// Token: 0x0400A37A RID: 41850
				public static LocString NAME = UI.FormatAsLink("Rocketry", "BUILDCATEGORYROCKETRY");

				// Token: 0x0400A37B RID: 41851
				public static LocString TOOLTIP = "With rockets, the sky's no longer the limit! {Hotkey}";
			}

			// Token: 0x02002539 RID: 9529
			public static class MEDICAL
			{
				// Token: 0x0400A37C RID: 41852
				public static LocString NAME = UI.FormatAsLink("Medicine", "BUILDCATEGORYMEDICAL");

				// Token: 0x0400A37D RID: 41853
				public static LocString TOOLTIP = "A cure for everything but the common cold. {Hotkey}";
			}

			// Token: 0x0200253A RID: 9530
			public static class FURNITURE
			{
				// Token: 0x0400A37E RID: 41854
				public static LocString NAME = UI.FormatAsLink("Furniture", "BUILDCATEGORYFURNITURE");

				// Token: 0x0400A37F RID: 41855
				public static LocString TOOLTIP = "Amenities to keep my Duplicants happy, comfy and efficient. {Hotkey}";
			}

			// Token: 0x0200253B RID: 9531
			public static class EQUIPMENT
			{
				// Token: 0x0400A380 RID: 41856
				public static LocString NAME = UI.FormatAsLink("Stations", "BUILDCATEGORYEQUIPMENT");

				// Token: 0x0400A381 RID: 41857
				public static LocString TOOLTIP = "Unlock new technologies through the power of science! {Hotkey}";
			}

			// Token: 0x0200253C RID: 9532
			public static class MISC
			{
				// Token: 0x0400A382 RID: 41858
				public static LocString NAME = UI.FormatAsLink("Decor", "BUILDCATEGORYMISC");

				// Token: 0x0400A383 RID: 41859
				public static LocString TOOLTIP = "Spruce up my colony with some lovely interior decorating. {Hotkey}";
			}

			// Token: 0x0200253D RID: 9533
			public static class AUTOMATION
			{
				// Token: 0x0400A384 RID: 41860
				public static LocString NAME = UI.FormatAsLink("Automation", "BUILDCATEGORYAUTOMATION");

				// Token: 0x0400A385 RID: 41861
				public static LocString TOOLTIP = "Automate my base with a wide range of sensors. {Hotkey}";
			}

			// Token: 0x0200253E RID: 9534
			public static class HEP
			{
				// Token: 0x0400A386 RID: 41862
				public static LocString NAME = UI.FormatAsLink("Radiation", "BUILDCATEGORYHEP");

				// Token: 0x0400A387 RID: 41863
				public static LocString TOOLTIP = "Here's where things get rad. {Hotkey}";
			}
		}
         */
	}
}
