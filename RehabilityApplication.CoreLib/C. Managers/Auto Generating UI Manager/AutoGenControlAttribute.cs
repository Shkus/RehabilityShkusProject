using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace RehabilityApplication.CoreLib
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class AutoGenControlAttribute : Attribute
    {
        public AutoGenControlAttribute() { }

        public ControlType controlType { get; set; } = ControlType.TextBox;
        public string LabelTitle { get; set; }
        public int LabelWidth { get; set; } = 100;
        public int ControlWidth { get; set; } = 100;

        public bool IsInLine { get; set; } = false;

        public object ComboBoxItems { get; set; }

        public string HeaderTitle { get; set; } = string.Empty;
    }

    public enum ControlType
    {
        TextBox,
        ToggleSwitch,
        ComboBox,
        ComboBoxByEnum,
        Button,
        DateEdit,
    }
}
