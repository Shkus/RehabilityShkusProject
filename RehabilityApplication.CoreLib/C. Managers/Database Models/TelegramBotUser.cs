using System;
using System.Drawing;

namespace RehabilityApplication.CoreLib
{
    [Serializable]
    public class TelegramBotUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Daddyname { get; set; }
        public string Nickname { get; set; }
        public Bitmap Avatar { get; set; }
        public long Id { get; set; }
        public TelegramBotUser() { }
    }
}
