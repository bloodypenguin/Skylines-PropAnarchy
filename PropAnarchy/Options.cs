using System.Xml.Serialization;
using PropAnarchy.OptionsFramework;

namespace PropAnarchy
{
    public class Options : IModOptions
    {
        public Options()
        {
            anarchyAlwaysOn = false;
            anarchyOnByDefault = false;
        }
        [Checkbox("Anarchy always ON (no UI)")]
        public bool anarchyAlwaysOn { set; get; }

        [Checkbox("Anarchy ON by default (ignored if anarchy is always ON)")]
        public bool anarchyOnByDefault { set; get; }

        [XmlIgnore]
        public string FileName => "CSL-PropAnarchy.xml";
    }
}