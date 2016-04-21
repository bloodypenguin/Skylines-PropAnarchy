using PropAnarchy.OptionsFramework;
using PropAnarchy.Redirection;
using UnityEngine;

namespace PropAnarchy.Detours
{
    [TargetType(typeof(TreeInstance))]
    public class TreeInstanceDetour
    {
        [RedirectMethod]
        public static void set_GrowState(ref TreeInstance tree, int value)
        {
            if (value == 0)
            {
                return;
            }
            tree.m_flags = (ushort)((int)tree.m_flags & -3841 | Mathf.Clamp(value, 0, 15) << 8);
        }

        [RedirectMethod]
        private static void CheckOverlap(ref TreeInstance tree, uint treeID)
        {
            if (!OptionsWrapper<Options>.Options.anarchyAlwaysOn)
            {
                return;
            }
            tree.GrowState = 1;
        }
    }
}