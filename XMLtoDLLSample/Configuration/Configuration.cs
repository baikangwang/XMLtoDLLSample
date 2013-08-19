using System.Xml.Serialization;

namespace XMLtoDLLSample.Configuration
{
    [XmlRoot]
    public class Configuration
    {
        [XmlArray]
        public TemplateSetting[] TemplateSettings { get; set; }
    }
}
