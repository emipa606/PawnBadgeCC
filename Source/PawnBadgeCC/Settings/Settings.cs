using Verse;

namespace PawnBadgeCC
{
    /// <summary>
    /// Definition of the settings for the mod
    /// </summary>
    internal class PawnBadgeCCSettings : ModSettings
    {
        public bool GDI = true;
        public bool GDIClean = false;
        public bool NOD = true;
        public bool NODClean = false;

        /// <summary>
        /// Saving and loading the values
        /// </summary>
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref GDI, "GDI", true, false);
            Scribe_Values.Look(ref GDIClean, "GDIClean", true, false);
            Scribe_Values.Look(ref NOD, "NOD", true, false);
            Scribe_Values.Look(ref NODClean, "NODClean", true, false);
        }
    }
}