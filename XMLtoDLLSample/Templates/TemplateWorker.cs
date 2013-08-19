using System;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;
using XMLtoDLLSample.Exceptions;

namespace XMLtoDLLSample.Templates
{
    public interface ITemplateWorker
    {
        object Template { get; }
        string EntityName { get; }
        string Save(string specHlder, string path = null);
        object Load(string path);
    }

    public abstract class TemplateWorker<T>:IDisposable,ITemplateWorker where T: ITemplate, new()
    {
        private T _template;

        public virtual object Template { get { return _template; } set { _template = (T) value; } }

        public abstract string EntityName { get; }

        protected TemplateWorker()
        {
            _template=new T();
        }

        public virtual string Save(string specHlder, string path=null)
        {
            if (string.IsNullOrEmpty(path))
                path = Path.Combine(Application.StartupPath, "Templates", specHlder + "_" + EntityName + ".xml");
            
            string oPath = Path.GetDirectoryName(path);
            if (string.IsNullOrEmpty(oPath))
                oPath = Path.Combine(Application.StartupPath, "Templates");

            if (!Directory.Exists(oPath))
                Directory.CreateDirectory(oPath);

            try
            {
                using (FileStream fs = File.OpenWrite(path))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(T));
                    xml.Serialize(fs, Template);
                    fs.Flush(true);
                    fs.Close();
                }
            }
            catch
            {
                throw new TemplateFailSerializeExcep(string.Format("{0} Template could not be saved.", EntityName));
            }

            return path;
        }

        public virtual object Load(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(string.Format("{0} Template file path is invalid.",EntityName));

            if (!File.Exists(path))
                throw new TemplateNotFoundExcep(string.Format("{0} Template is not existing.", EntityName));


            try
            {
                using (FileStream fs = File.OpenRead(path))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(T));
                    Template = (T)xml.Deserialize(fs);
                    fs.Close();
                }
            }
            catch
            {
                throw new TemplateFailDeserializeExcep(string.Format("{0} Template could not be opened.",EntityName));
            }

            return Template;
        }
        
        public virtual void Dispose()
        {
            Template = default(T);
        }
    }
}
