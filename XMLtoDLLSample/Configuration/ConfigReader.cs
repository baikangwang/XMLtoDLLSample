using System.IO;
using System.Xml.Serialization;
using XMLtoDLLSample.Exceptions;

namespace XMLtoDLLSample.Configuration
{
    public class ConfigReader
    {
        private readonly string _path;

        private static ConfigReader _reader=new ConfigReader();

        public static ConfigReader Current { get { return _reader; } }

        protected ConfigReader()
        {
            _path = Path.Combine(System.Windows.Forms.Application.StartupPath, "Templates", "templates.dll");
        }

        public Configuration Read()
        {
            
            if (!File.Exists(_path))
                throw new ConfigNotFoundExcep("Configuration file is not exists ever.");
            
            Configuration config;
            
            using (FileStream s=File.OpenRead(_path))
            {
                XmlSerializer xml=new XmlSerializer(typeof(Configuration));
                try
                {
                    config=xml.Deserialize(s) as Configuration;
                }
                catch
                {
                    throw new ConfigFailDeserializeExcep("Configuration could not be read.");
                }
                s.Close();
            }

            return config;
        }
    }
}
