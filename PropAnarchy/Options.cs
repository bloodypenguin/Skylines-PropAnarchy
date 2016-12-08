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

        [Checkbox("No UI")]
        public bool noUi { set; get; }

        [Checkbox("Unhide all props on level loading")]
        public bool unhideAllPropsOnLevelLoading { set; get; }

        [Checkbox("Unhide all trees on level loading")]
        public bool unhideAllTreesOnLevelLoading { set; get; }

        [Checkbox("Anarchy always ON")]
        public bool anarchyAlwaysOn { set; get; }

        [Checkbox("Anarchy ON by default (ignored if anarchy is always ON)")]
        public bool anarchyOnByDefault { set; get; }

        [DropDown("Toggle ON/OFF key combo (ignored if anarchy is always ON)", nameof(ComboType))]
        public int keyCombo { set; get; }
    }
}