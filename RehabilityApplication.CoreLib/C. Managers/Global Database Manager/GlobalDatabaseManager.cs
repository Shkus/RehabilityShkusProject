using System.Collections.Generic;

namespace RehabilityApplication.CoreLib
{
    public static class GlobalDatabaseManager
    {
        public static List<TelegramBotUser> telegramBotUsers = new List<TelegramBotUser>();

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
        }
    }
}
