using Verse;

namespace PawnBadgeCC
{
    /// <summary>
    /// Definition of the settings for the mod
    /// </summary>
    internal class PawnBadgeCCSettings : ModSettings
    {
        public bool GDI = false;
        public bool GDIClean = false;
        public bool NOD = false;
        public bool NODClean = false;
        public bool SWIAArmy = false;
        public bool SWIANavy = false;
        public bool SWRebels = false;
        public bool DeutschesHeer = false;

        /// <summary>
        /// Saving and loading the values
        /// </summary>
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref GDI, "GDI", false, false);
            Scribe_Values.Look(ref GDIClean, "GDIClean", false, false);
            Scribe_Values.Look(ref NOD, "NOD", false, false);
            Scribe_Values.Look(ref NODClean, "NODClean", false, false);
            Scribe_Values.Look(ref SWIAArmy, "SWIAArmy", false, false);
            Scribe_Values.Look(ref SWIANavy, "SWIANavy", false, false);
            Scribe_Values.Look(ref SWRebels, "SWRebels", false, false);
            Scribe_Values.Look(ref DeutschesHeer, "DeutschesHeer", false, false);
        }
    }
}