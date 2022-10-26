using Verse;

namespace PawnBadgeCC;

[StaticConstructorOnStartup]
public class PawnBadgeCC
{
    static PawnBadgeCC()
    {
        PawnBadgeCCMod.instance.UpdateBadges();
    }
}