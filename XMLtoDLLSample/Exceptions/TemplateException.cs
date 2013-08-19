using System;

namespace XMLtoDLLSample.Exceptions
{
    public class TemplateException:ApplicationException
    {
        public TemplateException(string message) : base(message)
        {
        }
    }

    public class TemplateFailSerializeExcep : TemplateException
    {
        public TemplateFailSerializeExcep(string message) : base(message)
        {
        }
    }

    public class TemplateFailDeserializeExcep : TemplateException
    {
        public TemplateFailDeserializeExcep(string message) : base(message)
        {
        }
    }

    public class TemplateNotFoundExcep : TemplateException
    {
        public TemplateNotFoundExcep(string message) : base(message)
        {
        }
    }
}
