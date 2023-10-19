using System.Collections.Generic;

namespace RehabilityApplication.CoreLib
{
    public static class GlobalDatabaseManager
    {
        public static List<TelegramBotUser> telegramBotUsers = new List<TelegramBotUser>();
        public static List<dbClient> clients = new List<dbClient>();

        public static void Init()
        {
            // Добавляем пользователей в телеграм бота.
            telegramBotUsers.Add(new TelegramBotUser
            {
                Name = "Евгений", Surname = "Пашин", Id = 302237012
            });
            telegramBotUsers.Add(new TelegramBotUser
            {
                Name = "Иван", Surname = "Пашин", Id = 788177332
            });
            telegramBotUsers.Add(new TelegramBotUser
            {
                Name = "Василий", Surname = "Шкурихин", Id = 1462846866
            });

            for (int i = 0; i < 10000; i++)
            {
                long number = 100000000000;
                long snils = number + i;
                string newSnils = snils.ToString().Substring(1, snils.ToString().Length-1);
                clients.Add(new dbClient { IsSelected = true, Snils = newSnils });
            }



            //clients.Add(new dbClient { IsSelected = true, Snils = "012345678901"});
            //clients.Add(new dbClient { IsSelected = true, Snils = "123456789102"});
            //clients.Add(new dbClient { IsSelected = true, Snils = "234567890123"});
            //clients.Add(new dbClient { IsSelected = true, Snils = "345678901234"});
            //clients.Add(new dbClient { IsSelected = true, Snils = "456789012345"});
        }
    }
}
