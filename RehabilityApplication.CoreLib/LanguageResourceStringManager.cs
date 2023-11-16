using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraTreeList;
using System;
using System.Reflection;

namespace RehabilityApplication.CoreLib
{
    public static class LanguageResourceStringManager
    {
        private static System.Resources.ResourceManager resourceManager;

        public static string GetResourceString(string controlTitle)
        {
            switch(ApplicationSettings.CurrentLanguage)
            {
                case EnumLanguageType.Russian:
                    resourceManager = LanguageRU.ResourceManager;
                    break;
                case EnumLanguageType.English:
                    resourceManager = LanguageEN.ResourceManager;
                    break;
            }

            string value = resourceManager.GetString(controlTitle);
            return value;
        }

        public static void SetResourceString<T>(this T control)
        {
            Type controlType = typeof(T);
            PropertyInfo pi = controlType.GetProperty("Name");
            string name = (string)pi.GetValue(control);

            string value = GetResourceString(name);

            if(typeof(T) == typeof(BarButtonItem))
                (control as BarButtonItem).Caption = value;
            if(typeof(T) == typeof(BarToggleSwitchItem))
                (control as BarToggleSwitchItem).Caption = value;
            if(typeof(T) == typeof(RibbonForm))
                (control as RibbonForm).Text = value;
            if(typeof(T) == typeof(RibbonPage))
                (control as RibbonPage).Text = value;
            if(typeof(T) == typeof(RibbonPageGroup))
                (control as RibbonPageGroup).Text = value;
            if(typeof(T) == typeof(BackstageViewTabItem))
                (control as BackstageViewTabItem).Caption = value;
			if (typeof(T) == typeof(BackstageViewButtonItem))
				(control as BackstageViewButtonItem).Caption = value;
            if (typeof(T) == typeof(DevExpress.XtraBars.Docking.DockPanel))
                (control as DevExpress.XtraBars.Docking.DockPanel).Text = value;
            if(typeof(T) == typeof(TreeList))
            {
                foreach(var column in (control as TreeList).Columns)
                {
                    string controlName = "TL_" + column.FieldName;
                    string val = GetResourceString(controlName);
                    column.Caption = val;
                }
            }
		}


        //public static void SetResourceString(this BarButtonItem button)
        //{
        //    string buttonName = button.Name;
        //    string value = GetResourceString(buttonName);
        //    button.Caption = value;
        //}

        //public static void SetResourceString(this BarToggleSwitchItem toggle)
        //{
        //    string buttonName = toggle.Name;
        //    string value = GetResourceString(buttonName);
        //    toggle.Caption = value;
        //}

        //public static void SetResourceString(this RibbonForm form)
        //{
        //    string buttonName = form.Name;
        //    string value = GetResourceString(buttonName);
        //    form.Text = value;
        //}

        //public static void SetResourceString(this RibbonPage page)
        //{
        //    string buttonName = page.Name;
        //    string value = GetResourceString(buttonName);
        //    page.Text = value;
        //}

        //public static void SetResourceString(this RibbonPageGroup group)
        //{
        //    string buttonName = group.Name;
        //    string value = GetResourceString(buttonName);
        //    group.Text = value;
        //}

        //public static void SetResourceString(this RibbonPageGroup group)
        //{
        //    string buttonName = group.Name;
        //    string value = GetResourceString(buttonName);
        //    group.Text = value;
        //}

        //public static void SetResourceString(this RibbonPageGroup group)
        //{
        //    string buttonName = group.Name;
        //    string value = GetResourceString(buttonName);
        //    group.Text = value;
        //}

        //public static void SetResourceString(this RibbonPageGroup group)
        //{
        //    string buttonName = group.Name;
        //    string value = GetResourceString(buttonName);
        //    group.Text = value;
        //}

        //public static void SetResourceString(this RibbonPageGroup group)
        //{
        //    string buttonName = group.Name;
        //    string value = GetResourceString(buttonName);
        //    group.Text = value;
        //}
    }
}
