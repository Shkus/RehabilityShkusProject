using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace RehabilityApplication.CoreLib
{
    public static class TelegramBotManager
    {
        static List<TelegramBotClient> bots = new List<TelegramBotClient>();
        static async Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            await Task.Run(() =>
            {
            });
        }

        public static void Init()
        {
            foreach (string botToken in EnumManager.GetDescriptionsList(typeof(TelegramBotUsingType)))
            {
                TelegramBotClient bot = new TelegramBotClient(botToken);
                bot.StartReceiving(Update, Error);
                bots.Add(bot);
            }
        }

        static async Task Update(ITelegramBotClient client, Update update, CancellationToken token)
        {
            var message = update.Message;

            if (message?.Text != null)
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Я получил ваше сообщение! Ожидайте ответа...");
                return;
            }

            //if (message?.Text != null)
            //{
            //    if (message.Text.ToLower().Contains("hello"))
            //    {
            //        await client.SendTextMessageAsync(message.Chat.Id, "hi");
            //        return;
            //    }

                //    if (message.Text.ToUpper().Contains("КНИГА 1"))
                //    {
                //        string filepath = @"D:\!!! Базовые элементы\Рабочий стол\Стань свободным быстро.pdf";
                //        await using Stream stream = System.IO.File.OpenRead(filepath);
                //        await client.SendDocumentAsync(message.Chat.Id, new Telegram.Bot.Types.InputFileStream(stream, Path.GetFileName(filepath)));
                //        return;
                //    }

                //    if (message.Text.ToLower().StartsWith("add"))
                //    {
                //        string[] args = message.Text.Split('|', StringSplitOptions.RemoveEmptyEntries);

                //        if (args.Count() != 4)
                //        {
                //            return;
                //        }

                //        items.Add(new DatabaseItem()
                //        {
                //            Name = args[1],
                //            Description = args[2],
                //            Type = args[3]
                //        });

                //        BeginInvoke(new MethodInvoker(delegate
                //        {
                //            this.TL.RefreshDataSource();
                //        }));

                //        return;
                //    }

                //    if (message.Text.ToUpper().Contains("КНИГА 2"))
                //    {
                //        string filepath = @"D:\!!! Базовые элементы\Рабочий стол\Стань свободным быстро.pdf";
                //        await using Stream stream = System.IO.File.OpenRead(filepath);
                //        await client.SendDocumentAsync(message.Chat.Id, new Telegram.Bot.Types.InputFileStream(stream, Path.GetFileName(filepath)));
                //        return;
                //    }

                //    if (message.Text.ToUpper().Contains("ЗАКРЫТЬ ПРИЛОЖЕНИЕ"))
                //    {
                //        this.IsClosingApp = true;
                //        return;
                //    }

                //    if (message.Text.ToUpper().StartsWith("DATA"))
                //    {
                //        string[] args = message.Text.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                //        if (args.Count() == 1)
                //        {
                //            SendMessage($"Неверная команда от {message.Chat.Username} !!! Добавь пробел!!!");
                //            return;
                //        }

                //        int index = -1;
                //        int.TryParse(args[1], out index);

                //        try
                //        {
                //            DatabaseItem di = items[index];
                //            SendMessage($"Запись {index}: Название [{di.Name}], Описание [{di.Description}], Возрастное ограничение [{di.Type}]");
                //        }
                //        catch
                //        {
                //            SendMessage($"Запись {index}: отсутствует в базе данных.");
                //        }

                //        return;
                //    }
                //}

                //if (message?.Photo != null)
                //{
                //    await client.SendTextMessageAsync(message.Chat.Id, "Отличная картинка");
                //    return;
                //}
        }

        static void SendMessage(string text)
        {
            //Task.Run(() =>
            //{
            //    bot.SendTextMessageAsync(302237012, text);
            //});

            //Task.Run(() =>
            //{
            //    bot.SendTextMessageAsync(788177332, text);
            //});

            //Task.Run(() =>
            //{
            //    bot.SendTextMessageAsync(1462846866, text);
            //});
        }
    }
}
