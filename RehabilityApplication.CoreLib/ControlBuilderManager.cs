using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Filtering.Templates;
using DevExpress.XtraPrinting.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RehabilityApplication.CoreLib
{
    public static class ControlBuilderManager
    {
        private static Control Fundament;
        private const int offsetY = 20;
        private static object currentObject;
        public static void Build<T>(this Control fundament, T template)
        {
            Fundament = fundament;
            currentObject = template;

            List<PropertyInfo> properties = template.GetType().GetRuntimeProperties().ToList();

            foreach(var property in properties)
            {
                string propertyName = property.Name;

                IEnumerable<Attribute> instructions = from a in property.GetCustomAttributes()
                                                      where a is AutoGenControlAttribute
                                                      select a;

                if(instructions.Count() != 0)
                {
                    ControlType buildingControlType = (instructions.First() as AutoGenControlAttribute).controlType;

                    switch(buildingControlType)
                    {
                        case ControlType.TextBox:
                            CreateTextBox(property);
                            break;
                        case ControlType.ToggleSwitch:
                            break;
                        case ControlType.ComboBox:
                            break;
                        case ControlType.Button:
                            break;
                        case ControlType.DateEdit:
                            break;
                        default:
                            break;
                    }
                }
            }

            Control previousControl = Fundament.Controls[Fundament.Controls.Count - 1];

            LabelControl labelControl = new LabelControl()
            {
                Top = previousControl.Top + previousControl.Height + offsetY,
                Left = 30,
                Text = "",
                AutoSizeMode = LabelAutoSizeMode.None,
                Width = 0
            };

            Fundament.Controls.Add(labelControl);
        }

        private static void CreateTextBox(PropertyInfo prop)
        {
            IEnumerable<Attribute> instructions = from a in prop.GetCustomAttributes()
                                                  where a is AutoGenControlAttribute
                                                  select a;

            AutoGenControlAttribute autoGenControlAttribute = instructions.First() as AutoGenControlAttribute;

            if(Fundament.Controls.Count != 0)
            {
                Control previousControl = Fundament.Controls[Fundament.Controls.Count - 1];

                LabelControl labelControl = new LabelControl()
                {
                    Top = previousControl.Top + previousControl.Height + offsetY,
                    Left = 30,
                    Text = autoGenControlAttribute.LabelTitle,
                    AutoSizeMode = LabelAutoSizeMode.None,
                    Width = autoGenControlAttribute.LabelWidth
                };

                Fundament.Controls.Add(labelControl);

                TextEdit teControl = new TextEdit()
                {
                    Top = previousControl.Top + previousControl.Height + offsetY,
                    Left = labelControl.Left + labelControl.Width + 50,
                    Width = autoGenControlAttribute.ControlWidth
                };

                teControl.DataBindings.Add(new Binding("EditValue", currentObject, prop.Name, false, DataSourceUpdateMode.OnPropertyChanged));

                Fundament.Controls.Add(teControl);
            }
            else
            {
                LabelControl labelControl = new LabelControl()
                {
                    Top = 30,
                    Left = 30,
                    Text = autoGenControlAttribute.LabelTitle,
                    AutoSizeMode = LabelAutoSizeMode.None,
                    Width = autoGenControlAttribute.LabelWidth
                };

                Fundament.Controls.Add(labelControl);

                TextEdit teControl = new TextEdit()
                {
                    Top = 30,
                    Left = labelControl.Left + labelControl.Width + 50,
                    Width = autoGenControlAttribute.ControlWidth
                };

                teControl.DataBindings.Add(new Binding("EditValue", currentObject, prop.Name, false, DataSourceUpdateMode.OnPropertyChanged));

                Fundament.Controls.Add(teControl);
            }
               
        }
    }
}
