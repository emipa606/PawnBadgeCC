using RR_PawnBadge;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;

namespace PawnBadgeCC
{
    [StaticConstructorOnStartup]
    internal class PawnBadgeCCMod : Verse.Mod
    {
        /// <summary>
        /// Cunstructor
        /// </summary>
        /// <param name="content"></param>
        public PawnBadgeCCMod(ModContentPack content) : base(content)
        {
            instance = this;
        }

        /// <summary>
        /// The instance-settings for the mod
        /// </summary>
        internal PawnBadgeCCSettings Settings
        {
            get
            {
                if (settings == null)
                {
                    settings = GetSettings<PawnBadgeCCSettings>();
                }
                return settings;
            }
            set
            {
                settings = value;
            }
        }

        /// <summary>
        /// The title for the mod-settings
        /// </summary>
        /// <returns></returns>
        public override string SettingsCategory()
        {
            return "PawnBadge - C&C";
        }

        /// <summary>
        /// The settings-window
        /// For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
        /// </summary>
        /// <param name="rect"></param>
        public override void DoSettingsWindowContents(Rect rect)
        {
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(rect);
            listing_Standard.Label("Enabled pawn-badges", -1, "Selected rows will show up in game");
            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("GDI", ref Settings.GDI, "GDI badges");
            //listing_Standard.CheckboxLabeled("GDI borderless", ref Settings.GDIClean, "GDI badges, without border");
            listing_Standard.CheckboxLabeled("NOD", ref Settings.NOD, "NOD badges");
            //listing_Standard.CheckboxLabeled("NOD borderless", ref Settings.NODClean, "NOD badges, without border");
            listing_Standard.End();
            Settings.Write();
            instance.UpdateBadges();
        }

        public void UpdateBadges()
        {
            SetBadgeSetVisibility(GDI, Settings.GDI, false);
            //SetBadgeSetVisibility(GDI, Settings.GDIClean, true);
            SetBadgeSetVisibility(NOD, Settings.NOD, false);
            //SetBadgeSetVisibility(NOD, Settings.NODClean, true);
        }

        private void SetBadgeSetVisibility(List<BadgeDef> badgeSet, bool visible, bool transparent)
        {
            var workingSet = new List<BadgeDef>();
            foreach (BadgeDef badgeDef in badgeSet)
            {
                if (transparent)
                {
                    workingSet.Add(new BadgeDef
                    {
                        icon = badgeDef.icon.Replace("/", "Transparent/"),
                        defName = badgeDef.defName + "Trans",
                        label = badgeDef.label,
                        description = badgeDef.description
                    });
                }
                else
                {
                    workingSet.Add(badgeDef);
                }
            }
            var currentDefs = (from dd in DefDatabase<BadgeDef>.AllDefsListForReading where dd.icon == workingSet[0].icon select dd).ToList();
            //Log.Message("current: " + string.Join(",", DefDatabase<BadgeDef>.AllDefsListForReading));
            //Log.Message("new: " + string.Join(",", workingSet));
            bool exist = currentDefs.Count > 0;

            if (visible && !exist)
            {
                Log.Message("Pawn Badge CC: Adding Badge-set to database, emblem: " + workingSet[0].icon);
                DefDatabase<BadgeDef>.Add(workingSet);
                return;
            }
            if (!visible && exist)
            {
                Log.Message("Pawn Badge CC: Removing Badge-set from database, emblem: " + workingSet[0].icon);
                foreach (BadgeDef badgeDef in (from dr in DefDatabase<BadgeDef>.AllDefsListForReading where dr.defName.StartsWith(workingSet[0].defName.Substring(0, 3)) && dr.defName.EndsWith("Trans") == transparent select dr).ToList())
                {
                    GenGeneric.InvokeStaticMethodOnGenericType(typeof(DefDatabase<>), typeof(BadgeDef), "Remove", new object[] { badgeDef });
                }
            }
        }

        private List<BadgeDef> GDI = new List<BadgeDef> { new BadgeDef { defName = "GDIEM", label = "GDI Emblem", description = "Global Defense Initiative Emblem", icon = "GDI/GDIEmblem" },
            new BadgeDef { defName = "GDIRank1", label = "GDI Recruit", description = "Global Defense Initiative Recruit", icon = "GDI/GDI1_Recruit" },
            new BadgeDef { defName = "GDIRank2", label = "GDI Private", description = "Global Defense Initiative Private", icon = "GDI/GDI2_Private" },
            new BadgeDef { defName = "GDIRank3", label = "GDI Lance Corporal", description = "Global Defense Initiative Lance Corporal", icon = "GDI/GDI3_LanceCorporal" },
            new BadgeDef { defName = "GDIRank4", label = "GDI Corporal", description = "Global Defense Initiative Corporal", icon = "GDI/GDI4_Corporal" },
            new BadgeDef { defName = "GDIRank5", label = "GDI Sergeant", description = "Global Defense Initiative Sergeant", icon = "GDI/GDI5_Sergeant" },
            new BadgeDef { defName = "GDIRank6", label = "GDI Staff Sergeant", description = "Global Defense Initiative Staff Sergeant", icon = "GDI/GDI6_StaffSergeant" },
            new BadgeDef { defName = "GDIRank7", label = "GDI First Sergeant", description = "Global Defense Initiative First Sergeant", icon = "GDI/GDI7_FirstSergeant" },
            new BadgeDef { defName = "GDIRank8", label = "GDI Sergeant Major", description = "Global Defense Initiative Sergeant Major", icon = "GDI/GDI8_SergeantMajor" },
            new BadgeDef { defName = "GDIRank9", label = "GDI Ensign", description = "Global Defense Initiative Ensign", icon = "GDI/GDI9_Ensign" },
            new BadgeDef { defName = "GDIRank10", label = "GDI Second Lieutenant", description = "Global Defense Initiative Second Lieutenant", icon = "GDI/GDI10_SecondLieutenant" },
            new BadgeDef { defName = "GDIRank11", label = "GDI Lieutenant", description = "Global Defense Initiative Lieutenant", icon = "GDI/GDI11_Lieutenant" },
            new BadgeDef { defName = "GDIRank12", label = "GDI Lieutenant Commander", description = "Global Defense Initiative Lieutenant Commander", icon = "GDI/GDI12_LieutenantCommander" },
            new BadgeDef { defName = "GDIRank13", label = "GDI Commander", description = "Global Defense Initiative Commander", icon = "GDI/GDI13_Commander" },
            new BadgeDef { defName = "GDIRank14", label = "GDI Captain", description = "Global Defense Initiative Captain", icon = "GDI/GDI14_Captain" },
            new BadgeDef { defName = "GDIRank15", label = "GDI Major", description = "Global Defense Initiative Major", icon = "GDI/GDI15_Major" },
            new BadgeDef { defName = "GDIRank16", label = "GDI Colonel", description = "Global Defense Initiative Colonel", icon = "GDI/GDI16_Colonel" },
            new BadgeDef { defName = "GDIRank17", label = "GDI Brigadier General", description = "Global Defense Initiative Brigadier General", icon = "GDI/GDI17_BrigadierGeneral" },
            new BadgeDef { defName = "GDIRank18", label = "GDI Major General", description = "Global Defense Initiative Major General", icon = "GDI/GDI18_MajorGeneral" },
            new BadgeDef { defName = "GDIRank19", label = "GDI Lieutenant General", description = "Global Defense Initiative Lieutenant General", icon = "GDI/GDI19_LieutenantGeneral" },
            new BadgeDef { defName = "GDIRank20", label = "GDI General", description = "Global Defense Initiative General", icon = "GDI/GDI20_General" }
        };

        private List<BadgeDef> NOD = new List<BadgeDef> { new BadgeDef { defName = "NodEM", label = "Nod Emblem", description = "Brotherhood of Nod Emblem", icon = "Nod/NodEmblem" },
            new BadgeDef { defName = "NodRank1", label = "Nod Believer", description = "Brotherhood of Nod Believer", icon = "Nod/Nod1_Believer" },
            new BadgeDef { defName = "NodRank2", label = "Nod Initiate", description = "Brotherhood of Nod Initiate", icon = "Nod/Nod2_Initiate" },
            new BadgeDef { defName = "NodRank3", label = "Nod Acolyte", description = "Brotherhood of Nod Acolyte", icon = "Nod/Nod3_Acolyte" },
            new BadgeDef { defName = "NodRank4", label = "Nod Disciple", description = "Brotherhood of Nod Disciple", icon = "Nod/Nod4_Disciple" },
            new BadgeDef { defName = "NodRank5", label = "Nod Brother", description = "Brotherhood of Nod Brother", icon = "Nod/Nod5_Brother" },
            new BadgeDef { defName = "NodRank6", label = "Nod Apostle", description = "Brotherhood of Nod Apostle", icon = "Nod/Nod6_Apostle" },
            new BadgeDef { defName = "NodRank7", label = "Nod Prefect", description = "Brotherhood of Nod Prefect", icon = "Nod/Nod7_Prefect" },
            new BadgeDef { defName = "NodRank8", label = "Nod Confessor", description = "Brotherhood of Confessor", icon = "Nod/Nod8_Confessor" },
            new BadgeDef { defName = "NodRank9", label = "Nod Deacon", description = "Brotherhood of Nod Deacon", icon = "Nod/Nod9_Deacon" },
            new BadgeDef { defName = "NodRank10", label = "Nod Archdeacon", description = "Brotherhood of Nod Archdeacon", icon = "Nod/Nod10_Archdeacon" },
            new BadgeDef { defName = "NodRank11", label = "Nod Abbot", description = "Brotherhood of Abbot", icon = "Nod/Nod11_Abbot" },
            new BadgeDef { defName = "NodRank12", label = "Nod Grand Confessor", description = "Brotherhood of Nod Grand Confessor", icon = "Nod/Nod12_GrandConfessor" },
            new BadgeDef { defName = "NodRank13", label = "Nod Pontifex", description = "Brotherhood of Nod Pontifex", icon = "Nod/Nod13_Pontifex" },
            new BadgeDef { defName = "NodRank14", label = "Nod Vicar", description = "Brotherhood of Nod Vicar", icon = "Nod/Nod14_Vicar" },
            new BadgeDef { defName = "NodRank15", label = "Nod Executor", description = "Brotherhood of Nod Executor", icon = "Nod/Nod15_Executor" },
            new BadgeDef { defName = "NodRank16", label = "Nod Exarch", description = "Brotherhood of Nod Exarch", icon = "Nod/Nod16_Exarch" },
            new BadgeDef { defName = "NodRank17", label = "Nod Vizier", description = "Brotherhood of Nod Vizier", icon = "Nod/Nod17_Vizier" },
            new BadgeDef { defName = "NodRank18", label = "Nod Grand Vizier", description = "Brotherhood of Nod Grand Vizier", icon = "Nod/Nod18_GrandVizier" },
            new BadgeDef { defName = "NodRank19", label = "Nod Inner Circle", description = "Brotherhood of Nod Inner Circle", icon = "Nod/Nod19_InnerCircle" },
            new BadgeDef { defName = "NodRank20", label = "Nod Hand of Kane", description = "Brotherhood of Nod Hand of Kane", icon = "Nod/Nod20_HandofKane" }
        };

        /// <summary>
        /// The instance of the settings to be read by the mod
        /// </summary>
        public static PawnBadgeCCMod instance;

        /// <summary>
        /// The private settings
        /// </summary>
        private PawnBadgeCCSettings settings;

    }
}
