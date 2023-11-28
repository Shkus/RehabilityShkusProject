using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace RehabilityApplication.CoreLib
{
    public static partial class EnumManager
    {
        public static List<string> GetDescriptionsList(this Type enumType)
        {
            if (enumType.IsEnum)
            {
                List<Enum> le = GetValuesList(enumType);
                List<string> ld = new List<string>();
                le.ForEach(t => ld.Add(t.ToDescription()));
                return ld;
            }
            return null;
        }

        public static List<Enum> GetValuesList(this Type enumType)
        {
            if (enumType.IsEnum)
                return Enum.GetValues(enumType).Cast<Enum>().ToList();

            return null;
        }

        public static string ToDescription(this Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0
              ? (T)attributes[0]
              : null;
        }
    }
}