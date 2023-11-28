using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;

namespace RehabilityApplication.CoreLib
{
    public static partial class EnumManager
    {
        public static Enum GetEnumByDescription(this string Description, Type enumType)
        {
            if(enumType.IsEnum)
            {
                List<Enum> le = GetValuesList(enumType);

                foreach(Enum en in le)
                    if(en.ToDescription() == Description)
                        return en as System.Enum;

                return null;
            }
            return null;
        }

        public static Enum GetEnumByValue(this string Description, Type enumType)
        {
            if(enumType.IsEnum)
            {
                List<Enum> le = GetValuesList(enumType);
                foreach(Enum en in le)
                {
                    if(en.ToString() == Description)
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
