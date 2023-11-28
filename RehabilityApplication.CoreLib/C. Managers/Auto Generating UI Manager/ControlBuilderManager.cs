using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace RehabilityApplication.CoreLib
{
    public static class ControlBuilderManager
    {
        private static Control Fundament;
        private const int offsetY = 20;
        private const int offsetX = 40;
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
                            CreateToggleSwitch(property);
                            break;
                        case ControlType.ComboBox:
                            CreateComboBox(property);
                            break;
                        case ControlType.Button:
                            break;
                        case ControlType.DateEdit:
                            CreateDateEdit(property);
                            break;
                        case ControlType.ComboBoxByEnum:
                            CreateComboBoxByEnum(property);
                            break;
                        //case ControlType.DateEdit:
                        //    CreateDateEdit1(property);
                        //    break;

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

            Control previousControl = null;

            if(Fundament.Controls.Count != 0)
            {
                previousControl = Fundament.Controls[Fundament.Controls.Count - 1];
            }

            if(autoGenControlAttribute.HeaderTitle != string.Empty)
            {
                LabelControl headerControl = new LabelControl()
                {
                    Top = previousControl == null ? 30 : previousControl.Top + previousControl.Height + offsetY,
                    Left = 30,
                    Text = autoGenControlAttribute.HeaderTitle,
                    Font = new System.Drawing.Font("Arial", 18),
                    ForeColor = Color.Blue,
                };
                Fundament.Controls.Add(headerControl);
                previousControl = headerControl;
            }

            if(Fundament.Controls.Count != 0)
            {
                if(autoGenControlAttribute.IsInLine == false)
                {
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
                        Top = previousControl.Top,
                        Left = previousControl.Left + previousControl.Width + offsetX,
                        Text = autoGenControlAttribute.LabelTitle,
                        AutoSizeMode = LabelAutoSizeMode.None,
                        Width = autoGenControlAttribute.LabelWidth
                    };
                    Fundament.Controls.Add(labelControl);
                    TextEdit teControl = new TextEdit()
                    {
                        Top = previousControl.Top,
                        Left = labelControl.Left + labelControl.Width + 50,
                        Width = autoGenControlAttribute.ControlWidth
                    };
                    teControl.DataBindings.Add(new Binding("EditValue", currentObject, prop.Name, false, DataSourceUpdateMode.OnPropertyChanged));
                    Fundament.Controls.Add(teControl);
                }
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

        private static void CreateComboBox(PropertyInfo prop)
        {
            IEnumerable<Attribute> instructions = from a in prop.GetCustomAttributes()
                                                  where a is AutoGenControlAttribute
                                                  select a;

            AutoGenControlAttribute autoGenControlAttribute = instructions.First() as AutoGenControlAttribute;

            Control previousControl = null;

            if(Fundament.Controls.Count != 0)
            {
                previousControl = Fundament.Controls[Fundament.Controls.Count - 1];
            }

            if(autoGenControlAttribute.HeaderTitle != string.Empty)
            {
                LabelControl headerControl = new LabelControl()
                {
                    Top = previousControl == null ? 30 : previousControl.Top + previousControl.Height + offsetY,
                    Left = 30,
                    Text = autoGenControlAttribute.HeaderTitle,
                    Font = new System.Drawing.Font("Arial", 18),
                    ForeColor = Color.Red
                };
                Fundament.Controls.Add(headerControl);
                previousControl = headerControl;
            }


            if(Fundament.Controls.Count != 0)
            {
                if(autoGenControlAttribute.IsInLine == false)
                {
                    LabelControl labelControl = new LabelControl()
                    {
                        Top = previousControl.Top + previousControl.Height + offsetY,
                        Left = 30,
                        Text = autoGenControlAttribute.LabelTitle,
                        AutoSizeMode = LabelAutoSizeMode.None,
                        Width = autoGenControlAttribute.LabelWidth
                    };
                    Fundament.Controls.Add(labelControl);
                    ComboBoxEdit teControl = new ComboBoxEdit()
                    {
                        Top = previousControl.Top + previousControl.Height + offsetY,
                        Left = labelControl.Left + labelControl.Width + 50,
                        Width = autoGenControlAttribute.ControlWidth,
                        EditValue = (autoGenControlAttribute.ComboBoxItems as string[]).ToList()[0]
                    };
                    teControl.Properties.Items.AddRange((autoGenControlAttribute.ComboBoxItems as string[]).ToList());
                    teControl.DataBindings.Add(new Binding("EditValue", currentObject, prop.Name, false, DataSourceUpdateMode.OnPropertyChanged));
                    Fundament.Controls.Add(teControl);
                }
                else
                {
                    LabelControl labelControl = new LabelControl()
                    {
                        Top = previousControl.Top,
                        Left = previousControl.Left + previousControl.Width + offsetX,
                        Text = autoGenControlAttribute.LabelTitle,
                        AutoSizeMode = LabelAutoSizeMode.None,
                        Width = autoGenControlAttribute.LabelWidth
                    };
                    Fundament.Controls.Add(labelControl);
                    ComboBoxEdit teControl = new ComboBoxEdit()
                    {
                        Top = previousControl.Top,
                        Left = labelControl.Left + labelControl.Width + 50,
                        Width = autoGenControlAttribute.ControlWidth,
                        EditValue = (autoGenControlAttribute.ComboBoxItems as string[]).ToList()[0]
                    };
                    teControl.Properties.Items.AddRange((autoGenControlAttribute.ComboBoxItems as string[]).ToList());
                    teControl.DataBindings.Add(new Binding("EditValue", currentObject, prop.Name, false, DataSourceUpdateMode.OnPropertyChanged));
                    Fundament.Controls.Add(teControl);
                }
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
                ComboBoxEdit teControl = new ComboBoxEdit()
                {
                    Top = 30,
                    Left = labelControl.Left + labelControl.Width + 50,
                    Width = autoGenControlAttribute.ControlWidth,
                    EditValue = (autoGenControlAttribute.ComboBoxItems as string[]).ToList()[0]
                };
                teControl.DataBindings.Add(new Binding("EditValue", currentObject, prop.Name, false, DataSourceUpdateMode.OnPropertyChanged));

                Fundament.Controls.Add(teControl);
            }
        }

        private static void CreateDateEdit(PropertyInfo prop)
        {
            IEnumerable<Attribute> instructions = from a in prop.GetCustomAttributes()
                                                  where a is AutoGenControlAttribute
                                                  select a;
            AutoGenControlAttribute autoGenControlAttribute = instructions.First() as AutoGenControlAttribute;
            Control previousControl = null;

            if(Fundament.Controls.Count != 0)
            {
                previousControl = Fundament.Controls[Fundament.Controls.Count - 1];
            }

            if(autoGenControlAttribute.HeaderTitle != string.Empty)
            {
                LabelControl headerControl = new LabelControl()
                {
                    Top = previousControl == null ? 30 : previousControl.Top + previousControl.Height + offsetY,
                    Left = 30,
                    Text = autoGenControlAttribute.HeaderTitle,
                    Font = new System.Drawing.Font("Arial", 18),
                    ForeColor = Color.Yellow
                };
                Fundament.Controls.Add(headerControl);
                previousControl = headerControl;
            }

            if(Fundament.Controls.Count != 0)
            {
                if(autoGenControlAttribute.IsInLine == false)
                {
                    LabelControl labelControl = new LabelControl()
                    {
                        Top = previousControl.Top + previousControl.Height + offsetY,
                        Left = 30,
                        Text = autoGenControlAttribute.LabelTitle,
                        AutoSizeMode = LabelAutoSizeMode.None,
                        Width = autoGenControlAttribute.LabelWidth
                    };
                    Fundament.Controls.Add(labelControl);
                    DateEdit teControl = new DateEdit()
                    {
                        Top = previousControl.Top + previousControl.Height + offsetY,
                        Left = labelControl.Left + labelControl.Width + 50,
                        Width = autoGenControlAttribute.ControlWidth,
                    };
                    teControl.DataBindings.Add(new Binding("EditValue", currentObject, prop.Name, false, DataSourceUpdateMode.OnPropertyChanged));
                    Fundament.Controls.Add(teControl);
                }
                else
                {
                    LabelControl labelControl = new LabelControl()
                    {
                        Top = previousControl.Top,
                        Left = previousControl.Left + previousControl.Width + offsetX,
                        Text = autoGenControlAttribute.LabelTitle,
                        AutoSizeMode = LabelAutoSizeMode.None,
                        Width = autoGenControlAttribute.LabelWidth
                    };
                    Fundament.Controls.Add(labelControl);
                    DateEdit teControl = new DateEdit()
                    {
                        Top = previousControl.Top,
                        Left = labelControl.Left + labelControl.Width + 50,
                        Width = autoGenControlAttribute.ControlWidth,
                    };
                    teControl.DataBindings.Add(new Binding("EditValue", currentObject, prop.Name, false, DataSourceUpdateMode.OnPropertyChanged));
                    Fundament.Controls.Add(teControl);
                }
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
                DateEdit teControl = new DateEdit()
                {
                    Top = 30,
                    Left = labelControl.Left + labelControl.Width + 50,
                    Width = autoGenControlAttribute.ControlWidth,
                    EditValue = (autoGenControlAttribute.ComboBoxItems as string[]).ToList()[0]
                };
                teControl.DataBindings.Add(new Binding("EditValue", currentObject, prop.Name, false, DataSourceUpdateMode.OnPropertyChanged));

                Fundament.Controls.Add(teControl);
            }
        }

        private static void CreateToggleSwitch(PropertyInfo prop)
        {
            //IEnumerable<Attribute> instruction = from a in prop.GetCustomAttributes() where a is AutoGenControlAttribute select a;
            //AutoGenControlAttribute autoGenControlAttribute = instruction.First() as AutoGenControlAttribute;

            //if(Fundament.Controls.Count != 0)
            //{
            //    Control previousControl = Fundament.Controls[Fundament.Controls.Count - 1];

            //    if(autoGenControlAttribute.IsInLine == false)
            //    {
            //        LabelControl labelControl = new LabelControl()
            //        {
            //            Top = previousControl.Top + previousControl.Height + offsetY,
            //            Left = 30,
            //            Text = autoGenControlAttribute.LabelTitle,
            //            AutoSizeMode = LabelAutoSizeMode.None,
            //            Width = autoGenControlAttribute.LabelWidth
            //        };

            //        Fundament.Controls.Add(labelControl);

            //        ToggleSwitch toggleSwitch = new ToggleSwitch()
            //        {
            //            Top = previousControl.Top + previousControl.Height + offsetY,
            //            Left = labelControl.Left + labelControl.Width + 50,
            //            Width = autoGenControlAttribute.LabelWidth,
            //        };
            //        toggleSwitch.Properties.OffText = "Выкл";
            //        toggleSwitch.Properties.OnText = "Вкл";


            //        toggleSwitch.DataBindings.Add(new Binding("IsOn", currentObject, prop.Name, false, DataSourceUpdateMode.OnPropertyChanged));
            //        Fundament.Controls.Add(toggleSwitch);

            //    }

            //    else
            //    {
            //        LabelControl labelControl = new LabelControl()
            //        {
            //            Top = previousControl.Top,
            //            Left = previousControl.Left + previousControl.Width + offsetX,
            //            Text = autoGenControlAttribute.LabelTitle,
            //            AutoSizeMode = LabelAutoSizeMode.None,
            //            Width = autoGenControlAttribute.LabelWidth
            //        };
            //        Fundament.Controls.Add(labelControl);
            //        ToggleSwitch toggleSwitch = new ToggleSwitch()
            //        {
            //            Top = previousControl.Top,
            //            Left = labelControl.Left + labelControl.Width + 50,
            //            Width = autoGenControlAttribute.ControlWidth

            //        };

            //toggleSwitch.Properties.OffText = "Выкл";
            //toggleSwitch.Properties.OnText = "Вкл";

            //toggleSwitch.DataBindings.Add(new Binding("IsOn", currentObject, prop.Name, false, DataSourceUpdateMode.OnPropertyChanged));
            //Fundament.Controls.Add(toggleSwitch);


            IEnumerable<Attribute> instructions = from a in prop.GetCustomAttributes()
                                                  where a is AutoGenControlAttribute
                                                  select a;

            AutoGenControlAttribute autoGenControlAttribute = instructions.First() as AutoGenControlAttribute;

            Control previousControl = null;

            if(Fundament.Controls.Count != 0)
            {
                previousControl = Fundament.Controls[Fundament.Controls.Count - 1];
            }

            if(autoGenControlAttribute.HeaderTitle != string.Empty)
            {
                LabelControl headerControl = new LabelControl()
                {
                    Top = previousControl == null ? 30 : previousControl.Top + previousControl.Height + offsetY,
                    Left = 30,
                    Text = autoGenControlAttribute.HeaderTitle,
                    Font = new System.Drawing.Font("Arial", 18),
                    ForeColor = Color.Green
                };
                Fundament.Controls.Add(headerControl);
                previousControl = headerControl;
            }


            if(Fundament.Controls.Count != 0)
            {
                if(autoGenControlAttribute.IsInLine == false)
                {
                    LabelControl labelControl = new LabelControl()
                    {
                        Top = previousControl.Top + previousControl.Height + offsetY,
                        Left = 30,
                        Text = autoGenControlAttribute.LabelTitle,
                        AutoSizeMode = LabelAutoSizeMode.None,
                        Width = autoGenControlAttribute.LabelWidth
                    };
                    Fundament.Controls.Add(labelControl);

                    ToggleSwitch toggleSwitch = new ToggleSwitch()
                    {
                        Top = previousControl.Top + previousControl.Height + offsetY,
                        Left = labelControl.Left + labelControl.Width + 50,
                        Width = autoGenControlAttribute.ControlWidth

                    };

                    toggleSwitch.Properties.OffText = "Выкл";
                    toggleSwitch.Properties.OnText = "Вкл";


                    Fundament.Controls.Add(toggleSwitch);
                }
                else
                {
                    LabelControl labelControl = new LabelControl()
                    {
                        Top = previousControl.Top,
                        Left = previousControl.Left + previousControl.Width + offsetX,
                        Text = autoGenControlAttribute.LabelTitle,
                        AutoSizeMode = LabelAutoSizeMode.None,
                        Width = autoGenControlAttribute.LabelWidth
                    };
                    Fundament.Controls.Add(labelControl);

                    ToggleSwitch toggleSwitch = new ToggleSwitch()
                    {
                        Top = previousControl.Top,
                        Left = labelControl.Left + labelControl.Width + 50,
                        Width = autoGenControlAttribute.ControlWidth

                    };
                    toggleSwitch.Properties.OffText = "Выкл";
                    toggleSwitch.Properties.OnText = "Вкл";


                    toggleSwitch.DataBindings.Add(new Binding("IsOn", currentObject, prop.Name, false, DataSourceUpdateMode.OnPropertyChanged));
                    Fundament.Controls.Add(toggleSwitch);
                }
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

                ToggleSwitch toggleSwitch = new ToggleSwitch()
                {
                    Top = 30,
                    Left = labelControl.Left + labelControl.Width + 50,
                    Width = autoGenControlAttribute.ControlWidth,

                };

                toggleSwitch.Properties.OffText = "Выкл";
                toggleSwitch.Properties.OnText = "Вкл";


                toggleSwitch.DataBindings.Add(new Binding("IsOn", currentObject, prop.Name, false, DataSourceUpdateMode.OnPropertyChanged));
                Fundament.Controls.Add(toggleSwitch);
            }
        }

        private static void CreateComboBoxByEnum(PropertyInfo prop)
        {
            IEnumerable<Attribute> instructions = from a in prop.GetCustomAttributes()
                                                  where a is AutoGenControlAttribute
                                                  select a;

            AutoGenControlAttribute autoGenControlAttribute = instructions.First() as AutoGenControlAttribute;

            Type propType = prop.PropertyType;
            List<string> values = propType.GetDescriptionsList();

            object propValue = prop.GetValue(currentObject, new object[] { });

            Control previousControl = null;

            if(Fundament.Controls.Count != 0)
            {
                previousControl = Fundament.Controls[Fundament.Controls.Count - 1];
            }

            if(autoGenControlAttribute.HeaderTitle != string.Empty)
            {
                LabelControl headerControl = new LabelControl()
                {
                    Top = previousControl == null ? 30 : previousControl.Top + previousControl.Height + offsetY,
                    Left = 30,
                    Text = autoGenControlAttribute.HeaderTitle,
                    Font = new System.Drawing.Font("Arial", 18),
                    ForeColor = Color.Red
                };
                Fundament.Controls.Add(headerControl);
                previousControl = headerControl;
            }

            if(Fundament.Controls.Count != 0)
            {
                if(autoGenControlAttribute.IsInLine == false)
                {
                    LabelControl labelControl = new LabelControl()
                    {
                        Top = previousControl.Top + previousControl.Height + offsetY,
                        Left = 30,
                        Text = autoGenControlAttribute.LabelTitle,
                        AutoSizeMode = LabelAutoSizeMode.None,
                        Width = autoGenControlAttribute.LabelWidth
                    };
                    Fundament.Controls.Add(labelControl);
                    ComboBoxEdit teControl = new ComboBoxEdit()
                    {
                        Top = previousControl.Top + previousControl.Height + offsetY,
                        Left = labelControl.Left + labelControl.Width + 50,
                        Width = autoGenControlAttribute.ControlWidth,
                    };

                    teControl.Text = propValue.ToString().GetEnumByValue(propType).ToDescription();
                    teControl.Properties.Items.AddRange(values);
                    teControl.DataBindings.Add(new Binding("Text", currentObject, prop.Name, false, DataSourceUpdateMode.OnPropertyChanged));

                    teControl.TextChanged += (s, e) =>
                    {
                        prop.SetValue(currentObject, teControl.Text.GetEnumByDescription(propType));
                    };

                    Fundament.Controls.Add(teControl);
                }
                else
                {
                    LabelControl labelControl = new LabelControl()
                    {
                        Top = previousControl.Top,
                        Left = previousControl.Left + previousControl.Width + offsetX,
                        Text = autoGenControlAttribute.LabelTitle,
                        AutoSizeMode = LabelAutoSizeMode.None,
                        Width = autoGenControlAttribute.LabelWidth
                    };
                    Fundament.Controls.Add(labelControl);
                    ComboBoxEdit teControl = new ComboBoxEdit()
                    {
                        Top = previousControl.Top,
                        Left = labelControl.Left + labelControl.Width + 50,
                        Width = autoGenControlAttribute.ControlWidth,
                    };

                    teControl.Text = propValue.ToString().GetEnumByValue(propType).ToDescription();
                    teControl.Properties.Items.AddRange(values);
                    teControl.DataBindings.Add(new Binding("Text", currentObject, prop.Name, false, DataSourceUpdateMode.OnPropertyChanged));

                    teControl.TextChanged += (s, e) =>
                    {
                        prop.SetValue(currentObject, teControl.Text.GetEnumByDescription(propType));
                    };

                    Fundament.Controls.Add(teControl);
                }
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
                ComboBoxEdit teControl = new ComboBoxEdit()
                {
                    Top = 30,
                    Left = labelControl.Left + labelControl.Width + 50,
                    Width = autoGenControlAttribute.ControlWidth,
                };

                teControl.Text = propValue.ToString().GetEnumByValue(propType).ToDescription();
                teControl.Properties.Items.AddRange(values);
                teControl.DataBindings.Add(new Binding("Text", currentObject, prop.Name, false, DataSourceUpdateMode.OnPropertyChanged));

                teControl.TextChanged += (s, e) =>
                {
                    prop.SetValue(currentObject, teControl.Text.GetEnumByDescription(propType));
                };

                Fundament.Controls.Add(teControl);
            }
        }















    }

    //private static void CreateDateEdit1(PropertyInfo prop)

    //{
    //    IEnumerable<Attribute> instructions = from a in prop.GetCustomAttributes()
    //                                          where a is AutoGenControlAttribute
    //                                          select a;
    //    AutoGenControlAttribute autoGenControlAttribute = instructions.First() as AutoGenControlAttribute;

    //    if (Fundament.Controls.Count != 0)
    //    {
    //        Control previousControl = Fundament.Controls[Fundament.Controls.Count - 1];
    //        if (autoGenControlAttribute.IsInLine == false)
    //        {
    //            LabelControl LabelControl = new LabelControl()
    //            {
    //                Top = previousControl.Top + previousControl.Height + offsetY,
    //                Left = 25,
    //                Text = autoGenControlAttribute.LabelTitle,
    //                AutoSizeMode = LabelAutoSizeMode.None,
    //                Width = autoGenControlAttribute.LabelWidth
    //            };
    //            Fundament.Controls.Add(LabelControl);
    //            DateEdit DateEdit = new DateEdit()
    //            {
    //                Top = previousControl.Top + previousControl.Height + offsetY,
    //                Left = LabelControl.Left + LabelControl.Width + 50,
    //                Width = autoGenControlAttribute.ControlWidth,
    //            };
    //            DateEdit.DataBindings.Add(new Binding("EditValue", currentObject, prop.Name, false, DataSourceUpdateMode.OnPropertyChanged));
    //            Fundament.Controls.Add(DateEdit);
    //        }
    //        else
    //        {

    //            LabelControl LabelControl = new LabelControl()
    //            {
    //                Top = previousControl.Top,
    //                Left = previousControl.Left + previousControl.Width + offsetX,
    //                Text = autoGenControlAttribute.LabelTitle,
    //                AutoSizeMode = LabelAutoSizeMode.None,
    //                Width = autoGenControlAttribute.LabelWidth
    //            };
    //            Fundament.Controls.Add(LabelControl);
    //            DateEdit DateEdit = new DateEdit()
    //            {
    //                Top = previousControl.Top + previousControl.Height + offsetY,
    //                Left = LabelControl.Left + LabelControl.Width + 50,
    //                Width = autoGenControlAttribute.ControlWidth,
    //            };
    //            DateEdit.DataBindings.Add(new Binding("EditValue", currentObject, prop.Name, false, DataSourceUpdateMode.OnPropertyChanged));
    //            Fundament.Controls.Add(DateEdit);
    //        }
    //    }

    //}


    public enum FontSizeType
    {
        Bold,
        Thin,
        Middle,
        ExtraBold
    }
}