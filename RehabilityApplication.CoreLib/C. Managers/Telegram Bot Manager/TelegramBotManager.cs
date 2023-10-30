using DevExpress.DataAccess.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Types;

using GCM = RehabilityApplication.CoreLib.CoreGlobalCommandManager;

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

        /// <summary>
        /// Инициалзация при первом запуске программы
        /// </summary>
        public static void Init()
        {
            foreach (string botToken in EnumManager.GetDescriptionsList(typeof(TelegramBotUsingType)))
            {
                TelegramBotClient bot = new TelegramBotClient(botToken);
                bot.StartReceiving(Update, Error);
                bots.Add(bot);
            }

            GCM.CommandDataReceivingInitialized += (s, e) =>
            {
                if (e.Command is PlanetEarthCommandType.SendMoney)
                {
                    SendMessage("Благодарим, земляне!", e.Data);
                }

                if (e.Command is PlanetEarthCommandType.SendPeople)
                {
                    SendMessage("Благодарим, земляне, но идите ка вы лесом!", e.Data);
                }

                if (e.Command is PlanetEarthCommandType.SendWeapon)
                {
                    SendMessage("Благодарим, земляне за поддержку режима!", e.Data);
                }

                if (e.Command is PlanetEarthCommandType.HelloVasyok)
                {
                    SendMessage("ой всё", e.Data);
                }
                if (e.Command is RehabilityMarsCommand.HiBraza)
                {
                    SendMessage("Всем доброго настроения", e.Data);
                }

                if (e.Command is FoodDelivery.Done)
                {
                    SendMessage("Выполненою Еда готова, забирайте", e.Data);
                }

                if (e.Command is ResponseCommandType.ClientAlreadyExist)
                {
                    SendMessage($"Клиент с указанным СНИЛС [{e.Data[0]}] уже есть в базе!", (long)e.Data[1]);
                }

                if (e.Command is ResponseCommandType.ClientIsNotExist)
                {
                    SendMessage($"Клиент с указанным СНИЛС [{e.Data[0]}] не существует в базе!", (long)(e.Data as List<object>).Last());
                }
            };
        }

        static async Task Update(ITelegramBotClient client, Update update, CancellationToken token)
        {
            var message = update.Message;

            if (message.Text == null)
            {
                return;
            }

            string str = message.Text.ToLower();

            try
            {
                GCM.StartCommand(PlanetEarthCommandType.SendAnyMessage, str);
            }
            catch (Exception ex) { }

            if (message?.Text != null)
            {
                var botId = client.BotId;
                await client.SendTextMessageAsync(message.Chat.Id, "Я получил ваше сообщение! Ожидайте ответа...");

                if (message.Text.ToLower().Contains("send money"))
                {
                    GCM.StartReceiveDataCommand(PlanetEarthCommandType.SendMoney, botId);
                }

                if (message.Text.ToLower().Contains("send people"))
                {
                    GCM.StartReceiveDataCommand(PlanetEarthCommandType.SendPeople, botId);
                }

                if (message.Text.ToLower().Contains("send weapon"))
                {
                    GCM.StartReceiveDataCommand(PlanetEarthCommandType.SendWeapon, botId);
                }

                if (message.Text.ToLower().Contains("please give me my money"))
                {
                    GCM.StartReceiveDataCommand(PlanetEarthCommandType.HelloVasyok, botId);
                }
                if (message.Text.ToLower().Contains("zdarova"))
                {
                    GCM.StartReceiveDataCommand(RehabilityMarsCommand.HiBraza, botId);
                }

                if (message.Text.ToLower().Contains("done"))
                {
                    CoreGlobalCommandManager.StartReceiveDataCommand(FoodDelivery.Done, botId);
                }


                if (message.Text.ToLower().StartsWith("add new client"))
                {
                    string[] args = message.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string snils = args.Last();
                    GCM.StartReceiveDataCommand(DatabaseCommandType.AddNewClientInit, new List<object> { snils, botId });
                }

                if (message.Text.ToLower().StartsWith("remove client"))
                {
                    string[] args = message.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string snils = args.Last();
                    GCM.StartReceiveDataCommand(DatabaseCommandType.RemoveClient, new List<object> { snils, botId });
                }

                if (message.Text.ToLower().StartsWith("editdataclient"))
                {
                    string[] args = message.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string newSnils = args.Last();
                    string oldSnils = args[args.Length - 2];
                    GCM.StartReceiveDataCommand(DatabaseCommandType.editDataClient, new List<object> { oldSnils, newSnils, botId });
                }

                if (message.Text.ToLower().StartsWith("gendocclient") ||
                    message.Text.ToLower().StartsWith("gdc"))
                {
                    string[] args = message.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string snils = args.Last();
                    string adresspath = DocumentGenerationManager.GenerateDocuments(snils);

                    if (adresspath == string.Empty)
                    {
                        try
                        {
                            CoreGlobalCommandManager.StartReceiveDataCommand(ResponseCommandType.ClientIsNotExist, new List<object> { snils, client.BotId });
                        }
                        catch { }
                        return;
                    }

                    await using Stream stream = System.IO.File.OpenRead(adresspath);
                    await client.SendDocumentAsync(message.Chat.Id, new InputFileStream(stream, Path.GetFileName(adresspath)));
                    return;
                }


                if (message.Text.ToLower().StartsWith("genpdfclient") ||
                        message.Text.ToLower().StartsWith("gpc"))
                {
                    string[] args = message.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string snils = args.Last();
                    string adresspath = DocumentGenerationManager.GenerateDocuments(snils, true);

                    if (adresspath == string.Empty)
                    {
                        try
                        {
                            CoreGlobalCommandManager.StartReceiveDataCommand(ResponseCommandType.ClientIsNotExist, new List<object> { snils, client.BotId });
                        }
                        catch { }
                        return;
                    }
                    await using Stream stream = System.IO.File.OpenRead(adresspath);
                    await client.SendDocumentAsync(message.Chat.Id, new InputFileStream(stream, Path.GetFileName(adresspath)));
                    return;

                }

                

                if (message.Text.ToLower().StartsWith("createfolder") ||
                        message.Text.ToLower().StartsWith("cf"))
                {
                    string[] args = message.Text.Split('|', StringSplitOptions.RemoveEmptyEntries);

                    try
                    {
                        if (YandexDiskManager.IsInitializedTokes==false)
                        {
                            YandexDiskManager.Init();
                        }

                    }
                    catch { }
                    return;
                }

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

        static void SendMessage(string text, long botId)
        {
            foreach (var user in GlobalDatabaseManager.telegramBotUsers)
            {
                bots.Where(t => t.BotId == botId).First().SendTextMessageAsync(user.Id, text);
                GCM.StartCommand(PlanetEarthCommandType.SendAnyMessage, $"Ушло сообщение ['{text}'] боту с id={botId} на пользователя: {user.Name}");
            }
        }
    }
}
