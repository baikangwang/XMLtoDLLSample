using System.IO;
using System.Xml.Serialization;
using XMLtoDLLSample.Exceptions;

namespace XMLtoDLLSample.Configuration
{
    public class ConfigWriter
    {
        private readonly string _path;

        private static ConfigWriter _writer = new ConfigWriter();

        public static ConfigWriter Current { get { return _writer; } }

        protected ConfigWriter()
        {
            _path = Path.Combine(System.Windows.Forms.Application.StartupPath, "Templates", "templates.dll");
        }

        public bool Save(Configuration config)
        {
            string path = Path.GetDirectoryName(_path);
            if (string.IsNullOrEmpty(path))
                path = Path.Combine(System.Windows.Forms.Application.StartupPath, "Templates");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            try
            {
                using (FileStream s = File.OpenWrite(_path))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(Configuration));
                    xml.Serialize(s, config);

                    s.Flush(true);
                    s.Close();
                }
            }
            catch
            {
                throw new ConfigFailSerializeExcep("Configuration could not be saved.");
            }

            return true;
        }
    }
}
