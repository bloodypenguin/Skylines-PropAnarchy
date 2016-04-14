using System.Xml.Serialization;
using PropAnarchy.OptionsFramework;

namespace PropAnarchy
{
    public class Options : IModOptions
    {
        public Options()
        {
            pauseSimulationWhenAnarchyOn = true;
            resetAnarchyStateOnToolChange = true;
            anarchyOnByDefault = false;
            allowAnarchyWhenPlacingBuildingsAndRoads = false;
        }

        [Checkbox("Pause simulation when anarchy On (and tool is active)")]
        public bool pauseSimulationWhenAnarchyOn { set; get; }

        [Checkbox("Reset anarchy on tool change")]
        public bool resetAnarchyStateOnToolChange { set; get; }

        [Checkbox("Anarchy On by default")]
        public bool anarchyOnByDefault { set; get; }

        [Checkbox("Allow anarchy when placing buildings and roads")]
        public bool allowAnarchyWhenPlacingBuildingsAndRoads { set; get; }

        [XmlIgnore]
        public string FileName => "CSL-PropAnarchy.xml";
    }
}