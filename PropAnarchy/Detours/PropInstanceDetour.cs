using ColossalFramework;
using ColossalFramework.Math;
using PropAnarchy.Redirection;
using UnityEngine;

namespace PropAnarchy.Detours
{
    [TargetType(typeof(PropInstance))]
    public class PropInstanceDetour
    {
        [RedirectMethod]
        public static void set_Blocked(ref PropInstance prop, bool value)
        {
            if (!value)
                prop.m_flags = (ushort)((uint)prop.m_flags & 4294967231U);
        }

        [RedirectMethod]
        private static void CheckOverlap(ref PropInstance prop, ushort propID)
        {
            prop.Blocked = false;
        }
    }
}