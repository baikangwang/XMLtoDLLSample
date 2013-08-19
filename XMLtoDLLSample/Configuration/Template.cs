using System.Xml.Serialization;

namespace XMLtoDLLSample.Configuration
{
    public class TemplateSetting
    {
        [XmlElement]
        public string SpecialHandlingIndicator { get; set; }

        [XmlArray]
        public Template[] Templates { get; set; }
    }

    public class Template
    {
        [XmlAttribute]
        public string EntityName { get; set; }

        [XmlAttribute]
        public string Location { get; set; }
    }
}
