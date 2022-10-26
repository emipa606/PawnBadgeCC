using System.Collections.Generic;
using System.Linq;
using Mlie;
using RR_PawnBadge;
using UnityEngine;
using Verse;
using Mod = Verse.Mod;

namespace PawnBadgeCC;

[StaticConstructorOnStartup]
internal class PawnBadgeCCMod : Mod
{
    /// <summary>
    ///     The instance of the settings to be read by the mod
    /// </summary>
    public static PawnBadgeCCMod instance;

    private static string currentVersion;

    private readonly List<BadgeDef> DeutschesHeer = new List<BadgeDef>
    {
        new BadgeDef
        {
            defName = "HeerEM", label = "Heer Emblem", description = "Helmet decal of the Deutsches Heer",
            icon = "Heer/Heer_Emblem"
        },
        new BadgeDef
        {
            defName = "HeerRank1", label = "Mannschaften", description = "Deutsches Heer enlisted shoulderboard",
            icon = "Heer/Heer1_Mannschaften"
        },
        new BadgeDef
        {
            defName = "HeerRank2", label = "Obergrenadier", description = "Deutsches Heer Obergrenadier",
            icon = "Heer/Heer2_Obergrenadier"
        },
        new BadgeDef
        {
            defName = "HeerRank3", label = "Gefreiter", description = "Deutsches Heer Gefreiter",
            icon = "Heer/Heer3_Gefreiter"
        },
        new BadgeDef
        {
            defName = "HeerRank4", label = "Obergefreiter", description = "Deutsches Heer Obergefreiter",
            icon = "Heer/Heer4_Obergefreiter"
        },
        new BadgeDef
        {
            defName = "HeerRank5", label = "Veteran Obergefreiter",
            description = "Deutsches Heer Veteran Obergefreiter", icon = "Heer/Heer5_Obergefreiter"
        },
        new BadgeDef
        {
            defName = "HeerRank6", label = "Stabsgefreiter", description = "Deutsches Heer Stabsgefreiter",
            icon = "Heer/Heer6_Stabsgefreiter"
        },
        new BadgeDef
        {
            defName = "HeerRank7", label = "Unteroffizier", description = "Deutsches Heer Unteroffizier",
            icon = "Heer/Heer7_Unteroffizier"
        },
        new BadgeDef
        {
            defName = "HeerRank8", label = "Unterfeldwebel", description = "Deutsches Heer Unterfeldwebel",
            icon = "Heer/Heer8_Unterfeldwebel"
        },
        new BadgeDef
        {
            defName = "HeerRank9", label = "Feldwebel", description = "Deutsches Heer Feldwebel",
            icon = "Heer/Heer9_Feldwebel"
        },
        new BadgeDef
        {
            defName = "HeerRank10", label = "Oberfeldwebel", description = "Deutsches Heer Oberfeldwebel",
            icon = "Heer/Heer10_Oberfeldwebel"
        },
        new BadgeDef
        {
            defName = "HeerRank11", label = "Stabsfeldwebel", description = "Deutsches Heer Stabsfeldwebel",
            icon = "Heer/Heer11_Stabsfeldwebel"
        },
        new BadgeDef
        {
            defName = "HeerRank12", label = "Leutnant", description = "Deutsches Heer Leutnant",
            icon = "Heer/Heer16_Leutnant"
        },
        new BadgeDef
        {
            defName = "HeerRank13", label = "Oberleutnant", description = "Deutsches Heer Oberleutnant",
            icon = "Heer/Heer17_Oberleutnant"
        },
        new BadgeDef
        {
            defName = "HeerRank14", label = "Hauptmann", description = "Deutsches Heer Hauptmann",
            icon = "Heer/Heer18_Hauptmann"
        },
        new BadgeDef
        {
            defName = "HeerRank15", label = "Major", description = "Deutsches Heer Major",
            icon = "Heer/Heer19_Major"
        },
        new BadgeDef
        {
            defName = "HeerRank16", label = "Oberstleutnant", description = "Deutsches Heer Oberstleutnant",
            icon = "Heer/Heer20_Oberstleutnant"
        },
        new BadgeDef
        {
            defName = "HeerRank17", label = "Oberst", description = "Deutsches Heer Oberst",
            icon = "Heer/Heer21_Oberst"
        },
        new BadgeDef
        {
            defName = "HeerRank18", label = "Generalmajor", description = "Deutsches Heer Generalmajor",
            icon = "Heer/Heer22_Generalmajor"
        },
        new BadgeDef
        {
            defName = "HeerRank19", label = "Generalleutnant", description = "Deutsches Heer Generalleutnant",
            icon = "Heer/Heer23_Generalleutnant"
        },
        new BadgeDef
        {
            defName = "HeerRank20", label = "General", description = "Deutsches Heer General",
            icon = "Heer/Heer24_General"
        },
        new BadgeDef
        {
            defName = "HeerRank21", label = "Generaloberst", description = "Deutsches Heer Generaloberst",
            icon = "Heer/Heer25_Generaloberst"
        },
        new BadgeDef
        {
            defName = "HeerRank22", label = "Generalfeldmarschall",
            description = "Deutsches Heer Generalfeldmarschall", icon = "Heer/Heer26_GeneralFeldmarschall"
        }
    };

    private readonly List<BadgeDef> GDI = new List<BadgeDef>
    {
        new BadgeDef
        {
            defName = "GDIEM", label = "GDI Emblem", description = "Global Defense Initiative Emblem",
            icon = "GDI/GDIEmblem"
        },
        new BadgeDef
        {
            defName = "GDIRank1", label = "GDI Recruit", description = "Global Defense Initiative Recruit",
            icon = "GDI/GDI1_Recruit"
        },
        new BadgeDef
        {
            defName = "GDIRank2", label = "GDI Private", description = "Global Defense Initiative Private",
            icon = "GDI/GDI2_Private"
        },
        new BadgeDef
        {
            defName = "GDIRank3", label = "GDI Lance Corporal",
            description = "Global Defense Initiative Lance Corporal", icon = "GDI/GDI3_LanceCorporal"
        },
        new BadgeDef
        {
            defName = "GDIRank4", label = "GDI Corporal", description = "Global Defense Initiative Corporal",
            icon = "GDI/GDI4_Corporal"
        },
        new BadgeDef
        {
            defName = "GDIRank5", label = "GDI Sergeant", description = "Global Defense Initiative Sergeant",
            icon = "GDI/GDI5_Sergeant"
        },
        new BadgeDef
        {
            defName = "GDIRank6", label = "GDI Staff Sergeant",
            description = "Global Defense Initiative Staff Sergeant", icon = "GDI/GDI6_StaffSergeant"
        },
        new BadgeDef
        {
            defName = "GDIRank7", label = "GDI First Sergeant",
            description = "Global Defense Initiative First Sergeant", icon = "GDI/GDI7_FirstSergeant"
        },
        new BadgeDef
        {
            defName = "GDIRank8", label = "GDI Sergeant Major",
            description = "Global Defense Initiative Sergeant Major", icon = "GDI/GDI8_SergeantMajor"
        },
        new BadgeDef
        {
            defName = "GDIRank9", label = "GDI Ensign", description = "Global Defense Initiative Ensign",
            icon = "GDI/GDI9_Ensign"
        },
        new BadgeDef
        {
            defName = "GDIRank10", label = "GDI Second Lieutenant",
            description = "Global Defense Initiative Second Lieutenant", icon = "GDI/GDI10_SecondLieutenant"
        },
        new BadgeDef
        {
            defName = "GDIRank11", label = "GDI Lieutenant", description = "Global Defense Initiative Lieutenant",
            icon = "GDI/GDI11_Lieutenant"
        },
        new BadgeDef
        {
            defName = "GDIRank12", label = "GDI Lieutenant Commander",
            description = "Global Defense Initiative Lieutenant Commander", icon = "GDI/GDI12_LieutenantCommander"
        },
        new BadgeDef
        {
            defName = "GDIRank13", label = "GDI Commander", description = "Global Defense Initiative Commander",
            icon = "GDI/GDI13_Commander"
        },
        new BadgeDef
        {
            defName = "GDIRank14", label = "GDI Captain", description = "Global Defense Initiative Captain",
            icon = "GDI/GDI14_Captain"
        },
        new BadgeDef
        {
            defName = "GDIRank15", label = "GDI Major", description = "Global Defense Initiative Major",
            icon = "GDI/GDI15_Major"
        },
        new BadgeDef
        {
            defName = "GDIRank16", label = "GDI Colonel", description = "Global Defense Initiative Colonel",
            icon = "GDI/GDI16_Colonel"
        },
        new BadgeDef
        {
            defName = "GDIRank17", label = "GDI Brigadier General",
            description = "Global Defense Initiative Brigadier General", icon = "GDI/GDI17_BrigadierGeneral"
        },
        new BadgeDef
        {
            defName = "GDIRank18", label = "GDI Major General",
            description = "Global Defense Initiative Major General", icon = "GDI/GDI18_MajorGeneral"
        },
        new BadgeDef
        {
            defName = "GDIRank19", label = "GDI Lieutenant General",
            description = "Global Defense Initiative Lieutenant General", icon = "GDI/GDI19_LieutenantGeneral"
        },
        new BadgeDef
        {
            defName = "GDIRank20", label = "GDI General", description = "Global Defense Initiative General",
            icon = "GDI/GDI20_General"
        }
    };

    private readonly List<BadgeDef> NOD = new List<BadgeDef>
    {
        new BadgeDef
        {
            defName = "NodEM", label = "Nod Emblem", description = "Brotherhood of Nod Emblem",
            icon = "Nod/NodEmblem"
        },
        new BadgeDef
        {
            defName = "NodRank1", label = "Nod Believer", description = "Brotherhood of Nod Believer",
            icon = "Nod/Nod1_Believer"
        },
        new BadgeDef
        {
            defName = "NodRank2", label = "Nod Initiate", description = "Brotherhood of Nod Initiate",
            icon = "Nod/Nod2_Initiate"
        },
        new BadgeDef
        {
            defName = "NodRank3", label = "Nod Acolyte", description = "Brotherhood of Nod Acolyte",
            icon = "Nod/Nod3_Acolyte"
        },
        new BadgeDef
        {
            defName = "NodRank4", label = "Nod Disciple", description = "Brotherhood of Nod Disciple",
            icon = "Nod/Nod4_Disciple"
        },
        new BadgeDef
        {
            defName = "NodRank5", label = "Nod Brother", description = "Brotherhood of Nod Brother",
            icon = "Nod/Nod5_Brother"
        },
        new BadgeDef
        {
            defName = "NodRank6", label = "Nod Apostle", description = "Brotherhood of Nod Apostle",
            icon = "Nod/Nod6_Apostle"
        },
        new BadgeDef
        {
            defName = "NodRank7", label = "Nod Prefect", description = "Brotherhood of Nod Prefect",
            icon = "Nod/Nod7_Prefect"
        },
        new BadgeDef
        {
            defName = "NodRank8", label = "Nod Confessor", description = "Brotherhood of Confessor",
            icon = "Nod/Nod8_Confessor"
        },
        new BadgeDef
        {
            defName = "NodRank9", label = "Nod Deacon", description = "Brotherhood of Nod Deacon",
            icon = "Nod/Nod9_Deacon"
        },
        new BadgeDef
        {
            defName = "NodRank10", label = "Nod Archdeacon", description = "Brotherhood of Nod Archdeacon",
            icon = "Nod/Nod10_Archdeacon"
        },
        new BadgeDef
        {
            defName = "NodRank11", label = "Nod Abbot", description = "Brotherhood of Abbot",
            icon = "Nod/Nod11_Abbot"
        },
        new BadgeDef
        {
            defName = "NodRank12", label = "Nod Grand Confessor",
            description = "Brotherhood of Nod Grand Confessor", icon = "Nod/Nod12_GrandConfessor"
        },
        new BadgeDef
        {
            defName = "NodRank13", label = "Nod Pontifex", description = "Brotherhood of Nod Pontifex",
            icon = "Nod/Nod13_Pontifex"
        },
        new BadgeDef
        {
            defName = "NodRank14", label = "Nod Vicar", description = "Brotherhood of Nod Vicar",
            icon = "Nod/Nod14_Vicar"
        },
        new BadgeDef
        {
            defName = "NodRank15", label = "Nod Executor", description = "Brotherhood of Nod Executor",
            icon = "Nod/Nod15_Executor"
        },
        new BadgeDef
        {
            defName = "NodRank16", label = "Nod Exarch", description = "Brotherhood of Nod Exarch",
            icon = "Nod/Nod16_Exarch"
        },
        new BadgeDef
        {
            defName = "NodRank17", label = "Nod Vizier", description = "Brotherhood of Nod Vizier",
            icon = "Nod/Nod17_Vizier"
        },
        new BadgeDef
        {
            defName = "NodRank18", label = "Nod Grand Vizier", description = "Brotherhood of Nod Grand Vizier",
            icon = "Nod/Nod18_GrandVizier"
        },
        new BadgeDef
        {
            defName = "NodRank19", label = "Nod Inner Circle", description = "Brotherhood of Nod Inner Circle",
            icon = "Nod/Nod19_InnerCircle"
        },
        new BadgeDef
        {
            defName = "NodRank20", label = "Nod Hand of Kane", description = "Brotherhood of Nod Hand of Kane",
            icon = "Nod/Nod20_HandofKane"
        }
    };

    private readonly List<BadgeDef> SWIAArmy = new List<BadgeDef>
    {
        new BadgeDef
        {
            defName = "SWIAArmyEM", label = "Star Wars Imperial Army Emblem",
            description = "Star Wars Imperial Army Emblem", icon = "SWIAArmy/SWIAArmy_Emblem"
        },
        new BadgeDef
        {
            defName = "SWIAArmyRank1", label = "Ensign", description = "Ensign", icon = "SWIAArmy/SWIAArmy1_Ensign"
        },
        new BadgeDef
        {
            defName = "SWIAArmyRank2", label = "Junior Lieutenant", description = "Junior Lieutenant",
            icon = "SWIAArmy/SWIAArmy2_JuniorLieutenant"
        },
        new BadgeDef
        {
            defName = "SWIAArmyRank3", label = "Second Lieutenant", description = "Second Lieutenant",
            icon = "SWIAArmy/SWIAArmy3_SecondLieutenant"
        },
        new BadgeDef
        {
            defName = "SWIAArmyRank4", label = "Lieutenant", description = "Lieutenant",
            icon = "SWIAArmy/SWIAArmy4_Lieutenant"
        },
        new BadgeDef
        {
            defName = "SWIAArmyRank5", label = "Senior Lieutenant", description = "Senior Lieutenant",
            icon = "SWIAArmy/SWIAArmy5_SeniorLieutenant"
        },
        new BadgeDef
        {
            defName = "SWIAArmyRank6", label = "Captain", description = "Captain",
            icon = "SWIAArmy/SWIAArmy6_Captain"
        },
        new BadgeDef
        {
            defName = "SWIAArmyRank7", label = "Senior Captain", description = "Senior Captain",
            icon = "SWIAArmy/SWIAArmy7_SeniorCaptain"
        },
        new BadgeDef
            { defName = "SWIAArmyRank8", label = "Major", description = "Major", icon = "SWIAArmy/SWIAArmy8_Major" },
        new BadgeDef
        {
            defName = "SWIAArmyRank9", label = "Lieutenant Colonel", description = "Lieutenant Colonel",
            icon = "SWIAArmy/SWIAArmy9_LieutenantColonel"
        },
        new BadgeDef
        {
            defName = "SWIAArmyRank10", label = "Colonel", description = "Colonel",
            icon = "SWIAArmy/SWIAArmy10_Colonel"
        },
        new BadgeDef
        {
            defName = "SWIAArmyRank11", label = "Senior Colonel", description = "Senior Colonel",
            icon = "SWIAArmy/SWIAArmy11_SeniorColonel"
        },
        new BadgeDef
        {
            defName = "SWIAArmyRank12", label = "Major General", description = "Major General",
            icon = "SWIAArmy/SWIAArmy12_MajorGeneral"
        },
        new BadgeDef
        {
            defName = "SWIAArmyRank13", label = "Lieutenant General", description = "Lieutenant General",
            icon = "SWIAArmy/SWIAArmy13_LieutenantGeneral"
        },
        new BadgeDef
        {
            defName = "SWIAArmyRank14", label = "General", description = "General",
            icon = "SWIAArmy/SWIAArmy14_General"
        },
        new BadgeDef
        {
            defName = "SWIAArmyRank15", label = "Marshal", description = "Marshal",
            icon = "SWIAArmy/SWIAArmy15_Marshal"
        },
        new BadgeDef
        {
            defName = "SWIAArmyRank16", label = "Grand General", description = "Grand General",
            icon = "SWIAArmy/SWIAArmy16_GrandGeneral"
        }
    };

    private readonly List<BadgeDef> SWIANavy = new List<BadgeDef>
    {
        new BadgeDef
        {
            defName = "SWIANavyEM", label = "Star Wars Imperial Navy Emblem",
            description = "Star Wars Imperial Navy Emblem", icon = "SWIANavy/SWIANavy_Emblem"
        },
        new BadgeDef
        {
            defName = "SWIANavyRank1", label = "Ensign", description = "Ensign", icon = "SWIANavy/SWIANavy1_Ensign"
        },
        new BadgeDef
        {
            defName = "SWIANavyRank2", label = "Junior Lieutenant", description = "Junior Lieutenant",
            icon = "SWIANavy/SWIANavy2_JuniorLieutenant"
        },
        new BadgeDef
        {
            defName = "SWIANavyRank3", label = "Second Lieutenant", description = "Second Lieutenant",
            icon = "SWIANavy/SWIANavy3_SecondLieutenant"
        },
        new BadgeDef
        {
            defName = "SWIANavyRank4", label = "Lieutenant", description = "Lieutenant",
            icon = "SWIANavy/SWIANavy4_Lieutenant"
        },
        new BadgeDef
        {
            defName = "SWIANavyRank5", label = "Senior Lieutenant", description = "Senior Lieutenant",
            icon = "SWIANavy/SWIANavy5_SeniorLieutenant"
        },
        new BadgeDef
        {
            defName = "SWIANavyRank6", label = "Captain", description = "Captain",
            icon = "SWIANavy/SWIANavy6_Captain"
        },
        new BadgeDef
        {
            defName = "SWIANavyRank7", label = "Senior Captain", description = "Senior Captain",
            icon = "SWIANavy/SWIANavy7_SeniorCaptain"
        },
        new BadgeDef
        {
            defName = "SWIANavyRank8", label = "Lieutenant Commander", description = "Lieutenant Commander",
            icon = "SWIANavy/SWIANavy8_LieutenantCommander"
        },
        new BadgeDef
        {
            defName = "SWIANavyRank9", label = "Commander", description = "Commander",
            icon = "SWIANavy/SWIANavy9_Commander"
        },
        new BadgeDef
        {
            defName = "SWIANavyRank10", label = "Commodore", description = "Commodore",
            icon = "SWIANavy/SWIANavy10_Commodore"
        },
        new BadgeDef
        {
            defName = "SWIANavyRank11", label = "Senior Commodore", description = "Senior Commodore",
            icon = "SWIANavy/SWIANavy11_SeniorCommodore"
        },
        new BadgeDef
        {
            defName = "SWIANavyRank12", label = "Rear Admiral", description = "Rear Admiral",
            icon = "SWIANavy/SWIANavy12_RearAdmiral"
        },
        new BadgeDef
        {
            defName = "SWIANavyRank13", label = "Vice Admiral", description = "Vice Admiral",
            icon = "SWIANavy/SWIANavy13_ViceAdmiral"
        },
        new BadgeDef
        {
            defName = "SWIANavyRank14", label = "Admiral", description = "Admiral",
            icon = "SWIANavy/SWIANavy14_Admiral"
        },
        new BadgeDef
        {
            defName = "SWIANavyRank15", label = "Fleet Admiral", description = "Fleet Admiral",
            icon = "SWIANavy/SWIANavy15_FleetAdmiral"
        },
        new BadgeDef
        {
            defName = "SWIANavyRank16", label = "Grand Admiral", description = "Grand Admiral",
            icon = "SWIANavy/SWIANavy16_GrandAdmiral"
        }
    };

    private readonly List<BadgeDef> SWRebels = new List<BadgeDef>
    {
        new BadgeDef
        {
            defName = "SWRebelsEM", label = "Star Wars Rebels Emblem", description = "Star Wars Rebels Emblem",
            icon = "SWRebels/SWRebels_Emblem"
        },
        new BadgeDef
        {
            defName = "SWRebelsRank1", label = "Army Lieutenant", description = "Army Lieutenant",
            icon = "SWRebels/SWRebels1_ArmyLieutenant"
        },
        new BadgeDef
        {
            defName = "SWRebelsRank2", label = "Army Captain", description = "Army Captain",
            icon = "SWRebels/SWRebels2_ArmyCaptain"
        },
        new BadgeDef
        {
            defName = "SWRebelsRank3", label = "Army Major", description = "Army Major",
            icon = "SWRebels/SWRebels3_ArmyMajor"
        },
        new BadgeDef
        {
            defName = "SWRebelsRank4", label = "Army Commander", description = "Army Commander",
            icon = "SWRebels/SWRebels4_ArmyCommander"
        },
        new BadgeDef
        {
            defName = "SWRebelsRank5", label = "Army Colonel", description = "Army Colonel",
            icon = "SWRebels/SWRebels5_ArmyColonel"
        },
        new BadgeDef
        {
            defName = "SWRebelsRank6", label = "Army Admiral", description = "Army Admiral",
            icon = "SWRebels/SWRebels6_ArmyAdmiral"
        },
        new BadgeDef
        {
            defName = "SWRebelsRank7", label = "Navy Lieutenant", description = "Navy Lieutenant",
            icon = "SWRebels/SWRebels7_NavyLieutenant"
        },
        new BadgeDef
        {
            defName = "SWRebelsRank8", label = "Navy Captain", description = "Navy Captain",
            icon = "SWRebels/SWRebels8_NavyCaptain"
        },
        new BadgeDef
        {
            defName = "SWRebelsRank9", label = "Navy Major", description = "Navy Major",
            icon = "SWRebels/SWRebels9_NavyMajor"
        },
        new BadgeDef
        {
            defName = "SWRebelsRank10", label = "Navy Commander", description = "Navy Commander",
            icon = "SWRebels/SWRebels10_NavyCommander"
        },
        new BadgeDef
        {
            defName = "SWRebelsRank11", label = "Navy Rear Admiral", description = "Navy Rear Admiral",
            icon = "SWRebels/SWRebels11_NavyRearAdmiral"
        },
        new BadgeDef
        {
            defName = "SWRebelsRank12", label = "Navy Surface Marshal", description = "Navy Surface Marshal",
            icon = "SWRebels/SWRebels12_NavySurfaceMarshal"
        }
    };

    /// <summary>
    ///     The private settings
    /// </summary>
    private PawnBadgeCCSettings settings;

    /// <summary>
    ///     Cunstructor
    /// </summary>
    /// <param name="content"></param>
    public PawnBadgeCCMod(ModContentPack content) : base(content)
    {
        instance = this;
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(ModLister.GetActiveModWithIdentifier("Mlie.PawnBadgeCC"));
    }

    /// <summary>
    ///     The instance-settings for the mod
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
        set => settings = value;
    }

    /// <summary>
    ///     The title for the mod-settings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "PawnBadge - Collection";
    }

    /// <summary>
    ///     The settings-window
    ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
    /// </summary>
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        listing_Standard.Label("Enabled pawn-badges", -1, "Selected rows will show up in game");
        listing_Standard.Gap();
        listing_Standard.Label("Command & Conquer");
        listing_Standard.CheckboxLabeled("GDI", ref Settings.GDI, "Badges of the Global Defence Initiative");
        listing_Standard.CheckboxLabeled("GDI borderless", ref Settings.GDIClean, "GDI badges, without border");
        listing_Standard.CheckboxLabeled("NOD", ref Settings.NOD, "Badges of the Brotherhood of Nod");
        listing_Standard.CheckboxLabeled("NOD borderless", ref Settings.NODClean, "NOD badges, without border");
        listing_Standard.Gap();
        listing_Standard.Label("Star Wars");
        listing_Standard.CheckboxLabeled("Imperial Army", ref Settings.SWIAArmy, "Badges of the Imperial Army");
        listing_Standard.CheckboxLabeled("Imperial Navy", ref Settings.SWIANavy, "Badges of the Imperial Navy");
        listing_Standard.CheckboxLabeled("Rebels", ref Settings.SWRebels, "Badges of the Rebels");
        listing_Standard.Gap();
        listing_Standard.Label("Real");
        listing_Standard.CheckboxLabeled("Deutsches Heer", ref Settings.DeutschesHeer,
            "Badges of the Deutsches Heer");
        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label($"Installed mod-version: {currentVersion}");
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
    }

    public override void WriteSettings()
    {
        base.WriteSettings();
        instance.UpdateBadges();
    }

    public void UpdateBadges()
    {
        SetBadgeSetVisibility(GDI, Settings.GDI, false);
        SetBadgeSetVisibility(GDI, Settings.GDIClean, true);
        SetBadgeSetVisibility(NOD, Settings.NOD, false);
        SetBadgeSetVisibility(NOD, Settings.NODClean, true);
        SetBadgeSetVisibility(SWIAArmy, Settings.SWIAArmy, false);
        SetBadgeSetVisibility(SWIANavy, Settings.SWIANavy, false);
        SetBadgeSetVisibility(SWRebels, Settings.SWRebels, false);
        SetBadgeSetVisibility(DeutschesHeer, Settings.DeutschesHeer, false);
    }

    private void SetBadgeSetVisibility(List<BadgeDef> badgeSet, bool visible, bool transparent)
    {
        var workingSet = new List<BadgeDef>();
        foreach (var badgeDef in badgeSet)
        {
            if (transparent)
            {
                workingSet.Add(new BadgeDef
                {
                    icon = badgeDef.icon.Replace("/", "Transparent/"),
                    defName = $"{badgeDef.defName}Trans",
                    label = badgeDef.label,
                    description = badgeDef.description
                });
            }
            else
            {
                workingSet.Add(badgeDef);
            }
        }

        var currentDefs = (from dd in DefDatabase<BadgeDef>.AllDefsListForReading
            where dd.icon == workingSet[0].icon
            select dd).ToList();
        //Log.Message("current: " + string.Join(",", DefDatabase<BadgeDef>.AllDefsListForReading));
        //Log.Message("new: " + string.Join(",", workingSet));
        var exist = currentDefs.Count > 0;

        if (visible && !exist)
        {
            Log.Message($"Pawn Badge CC: Adding Badge-set to database, emblem: {workingSet[0].icon}");
            DefDatabase<BadgeDef>.Add(workingSet);
            return;
        }

        if (visible || !exist)
        {
            return;
        }

        Log.Message($"Pawn Badge CC: Removing Badge-set from database, emblem: {workingSet[0].icon}");
        foreach (var badgeDef in (from dr in DefDatabase<BadgeDef>.AllDefsListForReading
                     where dr.defName.StartsWith(workingSet[0].defName.Substring(0, 3)) &&
                           dr.defName.EndsWith("Trans") == transparent
                     select dr).ToList())
        {
            GenGeneric.InvokeStaticMethodOnGenericType(typeof(DefDatabase<>), typeof(BadgeDef), "Remove",
                badgeDef);
        }
    }
}