using DevExpress.Charts.Native;
using DevExpress.DataAccess.Web.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace RehabilityApplication.CoreLib
{
    public class dbClient
    {
        [AutoGenControl(controlType = ControlType.TextBox, ControlWidth = 100, LabelTitle = "СНИЛС", LabelWidth = 70, HeaderTitle = "Параметры отображения")]
        public string Snils { get; set; }

        [AutoGenControl(controlType = ControlType.TextBox, ControlWidth = 100, LabelTitle = "Кол-во", LabelWidth = 70, IsInLine = true)]
        public int Count { get; set; }

        [AutoGenControl(controlType = ControlType.ComboBox, ControlWidth = 100, LabelTitle = "Город", LabelWidth = 70, ComboBoxItems = new string[] { "Москва", "Санкт-Петербург", "Пермь" })]
        public string City { get; set; }

        [AutoGenControl(controlType = ControlType.ComboBox, ControlWidth = 100, LabelTitle = "Имя шрифта", LabelWidth = 70, ComboBoxItems = new string[] { "Arial", "Times New Roman", "Courier New", "Verdana" }, IsInLine = true)]
        public string FontFamily { get; set; }

        [AutoGenControl(controlType = ControlType.ComboBox, ControlWidth = 200, LabelTitle = "Размер шрифта", LabelWidth = 70, ComboBoxItems = new string[] { "8", "9", "10", "11", "12", "14", "16", "18", "20", "24", "30", "36", "40", "48", "60", }, HeaderTitle = "Параметры сохранения")]
        public string FontSize { get; set; }





        [AutoGenControl(controlType = ControlType.DateEdit, ControlWidth = 100, LabelTitle = "Дата начала контракта", LabelWidth = 150, HeaderTitle = "Календарь")]
        public DateTime DateEdit { get; set; }

        [AutoGenControl(controlType = ControlType.DateEdit, ControlWidth = 100, LabelTitle = "Датa окончания контракта", LabelWidth = 150, IsInLine = true)]
        public DateTime DateEdit1 { get; set; }





        [AutoGenControl(controlType = ControlType.ToggleSwitch, ControlWidth = 100, LabelTitle = "Врубить", LabelWidth = 150, HeaderTitle = "Переключалка")]
        public bool IsOn { get; set; }

		[AutoGenControl(controlType = ControlType.ToggleSwitch, ControlWidth = 100, LabelTitle = "Тапнуть", LabelWidth = 150, IsInLine = true)]
		public bool IsNot { get; set; }

		public bool IsSelected { get; set; }
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [AutoGenControl(controlType = ControlType.TextBox, ControlWidth = 200, LabelTitle = "Ф.И.О.", LabelWidth = 70)]
        public string FIO

        {
            get
            {
                dbPersonalDocument passport = GlobalDatabaseManager.personalDocuments.Where(t => t.ClientId == this.Id).LastOrDefault();

                if(passport == null)
                {
                    passport = new dbPersonalDocument();
                    GlobalDatabaseManager.personalDocuments.Add(passport);
                }

                string Name = passport.Name;
                string Surname = passport.Surname;
                string Daddyname = passport.Daddyname;
                return $"{Surname} {Name} {Daddyname}";
            }

            set
            {
                dbPersonalDocument passport = GlobalDatabaseManager.personalDocuments.Where(t => t.ClientId == this.Id).LastOrDefault();

                if(passport == null)
                {
                    passport = new dbPersonalDocument();
                    GlobalDatabaseManager.personalDocuments.Add(passport);
                }

               string fio = value;

                if(fio != string.Empty)
                {
                    string[] FIO = fio.Split(' ', StringSplitOptions.None);

                    if(FIO.Length == 1)
                    {
                        passport.Name = FIO[0];

                    }
                    else if(FIO.Length == 2)
                    {
                        passport.Name = FIO[0];
                        passport.Surname = FIO[1];

                    }
                    else
                    {
                        passport.Name = FIO[0];
                        passport.Surname = FIO[1];
                        passport.Daddyname = FIO[2];
                    }
                }

                passport.ClientId = this.Id;
            }
        }
        public dbClient() { }
        public dbClient(dbClient client)
        {
            if(client == null)
            {
                dbClient newClient = new dbClient();
                this.FIO = newClient.FIO;
                this.Id = newClient.Id;
                this.IsSelected = newClient.IsSelected;
                this.Snils = newClient.Snils;
                return;
            }

            this.FIO = client.FIO;
            this.Id = client.Id;
            this.IsSelected = client.IsSelected;
            this.Snils = client.Snils;
        }

        //public dbClient Clone(dbClient client)
        //{
        //    return new dbClient(client);
        //}
    }

    public enum CityType
    {
        [Description("Москва")]
        Moscow,
        [Description("Санкт-Петербург")]
        SaintPeterburg,
        [Description("Пермь")]
        Perm
    }
}
