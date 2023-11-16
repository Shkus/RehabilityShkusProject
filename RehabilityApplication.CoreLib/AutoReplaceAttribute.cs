using System;

namespace RehabilityApplication.CoreLib
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class AutoReplaceAttribute:Attribute
    {
        public string ParameterName { get; }

        public AutoReplaceAttribute(string ParameterName)
        {
            this.ParameterName = ParameterName;
        }
    }
}
