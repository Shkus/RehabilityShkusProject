using DevExpress.CodeParser;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehabilityApplication.CoreLib
{
    public static class ApplicationSettings
    {
        public static BarToggleSwitchItem TS = new BarToggleSwitchItem();

        private static EnumLanguageType currentLanguage;
        public static EnumLanguageType CurrentLanguage
        {
            get => currentLanguage;
            set
            {
                currentLanguage = value;
                CoreGlobalCommandManager.StartCommand((Enum)currentLanguage);
            }
        }
    }
}
