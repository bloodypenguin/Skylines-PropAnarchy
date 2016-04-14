using System.Xml.Serialization;

namespace PropAnarchy.OptionsFramework
{
    public interface IModOptions
    {
        [XmlIgnore]
        string FileName
        {
            get;
        }
    }
}