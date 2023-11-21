using System;
using System.Drawing;

namespace RehabilityApplication.CoreLib
{
    [Serializable]
    public class TelegramBotUser
    {
        [AutoGenControl(controlType = ControlType.TextBox, ControlWidth = 200, LabelTitle = "ИМЯ", LabelWidth = 70)]
        public string Name { get; set; }

        [AutoGenControl(controlType = ControlType.TextBox, ControlWidth = 200, LabelTitle = "ФАМИЛИЯ", LabelWidth = 70)]
        public string Surname { get; set; }

        [AutoGenControl(controlType = ControlType.TextBox, ControlWidth = 200, LabelTitle = "ОТЧЕСТВО", LabelWidth = 70)]
        public string Daddyname { get; set; }

        [AutoGenControl(controlType = ControlType.TextBox, ControlWidth = 200, LabelTitle = "НИК", LabelWidth = 70)]
        public string Nickname { get; set; }
        public Bitmap Avatar { get; set; }
        public long Id { get; set; }
        public TelegramBotUser() { }




        [AutoGenControl(controlType = ControlType.TextBox, ControlWidth = 100, LabelTitle = "НИК1", LabelWidth = 70)]
        public string Nickname2 { get; set; }

        [AutoGenControl(controlType = ControlType.TextBox, ControlWidth = 120, LabelTitle = "НИК2", LabelWidth = 70)]
        public string Nickname3 { get; set; }

        [AutoGenControl(controlType = ControlType.TextBox, ControlWidth = 140, LabelTitle = "НИК3", LabelWidth = 70)]
        public string Nickname4 { get; set; }

        [AutoGenControl(controlType = ControlType.TextBox, ControlWidth = 160, LabelTitle = "НИК4", LabelWidth = 70)]
        public string Nickname5 { get; set; }

        [AutoGenControl(controlType = ControlType.TextBox, ControlWidth = 180, LabelTitle = "НИК5", LabelWidth = 70)]
        public string Nickname6 { get; set; }

        [AutoGenControl(controlType = ControlType.TextBox, ControlWidth = 200, LabelTitle = "НИК6", LabelWidth = 70)]
        public string Nickname7 { get; set; }

        [AutoGenControl(controlType = ControlType.TextBox, ControlWidth = 220, LabelTitle = "НИК7", LabelWidth = 70)]
        public string Nickname8 { get; set; }

        [AutoGenControl(controlType = ControlType.TextBox, ControlWidth = 240, LabelTitle = "НИК8", LabelWidth = 70)]
        public string Nickname9 { get; set; }

        [AutoGenControl(controlType = ControlType.TextBox, ControlWidth = 260, LabelTitle = "НИК9", LabelWidth = 70)]
        public string Nickname10 { get; set; }

    }
}
