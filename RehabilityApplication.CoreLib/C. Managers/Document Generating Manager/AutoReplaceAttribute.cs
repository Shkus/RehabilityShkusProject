using System;

namespace RehabilityApplication.CoreLib
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class AutoReplaceAttribute:Attribute
    {
        public string ParameterName { get; }
        public bool IsThisInstanceAsList { get; } = false;

        public AutoReplaceAttribute() { }
        public AutoReplaceAttribute(bool isThisInstanceAsList) { this.IsThisInstanceAsList = isThisInstanceAsList; }
        public AutoReplaceAttribute(string ParameterName) { this.ParameterName = ParameterName; }
        public AutoReplaceAttribute(bool isThisInstanceAsList, string ParameterName = "" ) 
        { 
            this.ParameterName = ParameterName; 
            this.IsThisInstanceAsList = isThisInstanceAsList; 
        }
    }
}
