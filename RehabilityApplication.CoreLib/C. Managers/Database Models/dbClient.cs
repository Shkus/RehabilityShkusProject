using DevExpress.Charts.Native;
using System;
using System.Linq;

namespace RehabilityApplication.CoreLib
{
    public class dbClient
    {
        public string Snils { get; set; }
        public bool IsSelected { get; set; }
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FIO
        {
            get
            {
                dbPersonalDocument passport = GlobalDatabaseManager.personalDocuments.Where(t => t.ClientId == this.Id).Last();
                string Name = passport.Name;
                string Surname = passport.Surname;
                string Daddyname = passport.Daddyname;
                return $"{Surname} {Name} {Daddyname}";
            }
        }
        public dbClient() { }
    }
}
