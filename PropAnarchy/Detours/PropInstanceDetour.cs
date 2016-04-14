using PropAnarchy.Redirection;

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
    }
}