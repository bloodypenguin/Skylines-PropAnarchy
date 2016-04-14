using ICities;
using PropAnarchy.OptionsFramework;

namespace PropAnarchy
{
    public class Mod : IUserMod
    {
        public string Name => "Prop & Tree Anarchy";

        public string Description => "Place your props and trees wherever you like";

        public void OnSettingsUI(UIHelperBase helper)
        {
            helper.AddOptionsGroup<Options>();
        }

    }
}
