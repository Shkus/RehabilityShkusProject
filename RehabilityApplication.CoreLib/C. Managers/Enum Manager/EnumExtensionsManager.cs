using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehabilityApplication.CoreLib
{
    public static class EnumManager
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

        public static Enum GetEnumByDescription(this string Description, Type enumType)
        {
            if (enumType.IsEnum)
            {
                List<Enum> le = GetValuesList(enumType);

                foreach (Enum en in le)
                    if (en.ToDescription() == Description)
                        return en as System.Enum;

                return null;
            }
            return null;
        }

        public static Enum GetEnumByValue(this string Description, Type enumType)
        {
            if (enumType.IsEnum)
            {
                List<Enum> le = GetValuesList(enumType);
                foreach (Enum en in le)
                {
                    if (en.ToString() == Description)
                    {
                        return en as System.Enum;
                    }
                }
                return null;
            }
            return null;
        }

        public static void GetCitiesList(this ComboBoxEdit cbe)
        {
            cbe.Properties.Items.Clear();
            cbe.Properties.Items.AddRange(GetDescriptionsList(typeof(LocationType)));
        }

        public static void GetRolesList(this ComboBoxEdit cbe)
        {
            cbe.Properties.Items.Clear();
            cbe.Properties.Items.AddRange(GetDescriptionsList(typeof(UserRoleType)));
        }
    }
}