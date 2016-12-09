using PropAnarchy.OptionsFramework.Attibutes;

namespace PropAnarchy
{
    [Options("PropAnarchy.xml", "CSL-PropAnarchy.xml")]
    public class Options
    {
        public Options()
        {
            noUi = false;
            anarchyOnByDefault = false;
            unhideAllPropsOnLevelLoading = false;
            unhideAllTreesOnLevelLoading = false;
            keyCombo = 0;
        }

        [Checkbox("PTA_OPTION_NO_UI")]
        public bool noUi { set; get; }

        [Checkbox("PTA_OPTION_UNHIDE_PROPS")]
        public bool unhideAllPropsOnLevelLoading { set; get; }

        [Checkbox("PTA_OPTION_UNHIDE_TREES")]
        public bool unhideAllTreesOnLevelLoading { set; get; }

        [Checkbox("PTA_OPTION_ALWAYS_ON")]
        public bool anarchyAlwaysOn { set; get; }

        [Checkbox("PTA_OPTION_DEFAULT_ON")]
        public bool anarchyOnByDefault { set; get; }

        [DropDown("PTA_OPTION_COMBO", nameof(ComboType))]
        public int keyCombo { set; get; }
    }
}