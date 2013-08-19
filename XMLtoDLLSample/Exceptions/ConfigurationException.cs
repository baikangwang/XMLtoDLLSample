using System;

namespace XMLtoDLLSample.Exceptions
{
    public class ConfigException:ApplicationException
    {
        public ConfigException(string message):base(message)
        {
        }

    }

    public class ConfigNotFoundExcep : ConfigException
    {
        public ConfigNotFoundExcep(string message)
            : base(message)
        {
        }

    }

    public class ConfigFailDeserializeExcep : ConfigException
    {
        public ConfigFailDeserializeExcep(string message)
            : base(message)
        {
        }
    }

    public class ConfigFailSerializeExcep : ConfigException
    {
        public ConfigFailSerializeExcep(string message) : base(message)
        {
        }
    }
}
