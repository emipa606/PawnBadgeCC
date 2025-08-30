using Verse;

namespace PawnBadgeCC;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class PawnBadgeCCSettings : ModSettings
{
    public bool DeutschesHeer;
    public bool GDI;
    public bool GDIClean;
    public bool NOD;
    public bool NODClean;
    public bool SWIAArmy;
    public bool SWIANavy;
    public bool SWRebels;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref GDI, "GDI");
        Scribe_Values.Look(ref GDIClean, "GDIClean");
        Scribe_Values.Look(ref NOD, "NOD");
        Scribe_Values.Look(ref NODClean, "NODClean");
        Scribe_Values.Look(ref SWIAArmy, "SWIAArmy");
        Scribe_Values.Look(ref SWIANavy, "SWIANavy");
        Scribe_Values.Look(ref SWRebels, "SWRebels");
        Scribe_Values.Look(ref DeutschesHeer, "DeutschesHeer");
    }
}