using DevExpress.Charts.Native;
using DevExpress.DataAccess.Web.Native;
using System;
using System.Linq;

namespace RehabilityApplication.CoreLib
{
    public class dbClient
    {
        [AutoGenControl(controlType = ControlType.TextBox, ControlWidth = 200, LabelTitle = "СНИЛС", LabelWidth = 70)]
        public string Snils { get; set; }
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
}
