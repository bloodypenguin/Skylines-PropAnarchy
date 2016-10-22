using System.Xml.Serialization;
using PropAnarchy.OptionsFramework;

namespace PropAnarchy
{
    public class Options : IModOptions
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

        [DropDown("Toggle ON/OFF key combo", nameof(ComboType))]
        public int keyCombo { set; get; }

        [Checkbox("Anarchy always ON")]
        public bool anarchyAlwaysOn { set; get; }

        [Checkbox("Anarchy ON by default (ignored if anarchy is always ON)")]
        public bool anarchyOnByDefault { set; get; }

        [Checkbox("Unhide all props on level loading")]
        public bool unhideAllPropsOnLevelLoading { set; get; }

        [Checkbox("Unhide all trees on level loading")]
        public bool unhideAllTreesOnLevelLoading { set; get; }

        [XmlIgnore]
        public string FileName => "CSL-PropAnarchy.xml";
    }
}