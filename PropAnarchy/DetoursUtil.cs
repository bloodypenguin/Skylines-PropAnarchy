using PropAnarchy.Detours;

namespace PropAnarchy
{
    public static class DetoursUtil
    {
        public static void Deploy()
        {
            PropToolDetour.Deploy();
            PropInstanceDetour.Deploy();
            TreeToolDetour.Deploy();
            TreeInstanceDetour.Deploy();
        }

        public static void Revert()
        {
            PropToolDetour.Revert();
            PropInstanceDetour.Revert();
            TreeToolDetour.Revert();
            TreeInstanceDetour.Revert();
        }
    }
}