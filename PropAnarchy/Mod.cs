using ICities;
using PropAnarchy.OptionsFramework.Extensions;
using PropAnarchy.TranslationFramework;

namespace PropAnarchy
{
    public class Mod : IUserMod
    {
        public static Translation translation = new Translation();

        public string Name => "Prop & Tree Anarchy";

        public string Description => translation.GetTranslation("PTA_DESCRIPTION");

        public void OnSettingsUI(UIHelperBase helper)
        {
            helper.AddOptionsGroup<Options>(s => translation.GetTranslation(s));
        }
    }
}
