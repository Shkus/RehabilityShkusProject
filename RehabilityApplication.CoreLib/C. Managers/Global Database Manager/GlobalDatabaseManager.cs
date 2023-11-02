using System;
using System.Collections.Generic;

namespace RehabilityApplication.CoreLib
{
    public static class GlobalDatabaseManager
    {
        public static List<TelegramBotUser> telegramBotUsers = new List<TelegramBotUser>();
        public static List<dbClient> clients = new List<dbClient>();
        public static List<dbPersonalDocument> personalDocuments = new List<dbPersonalDocument>();
        public static List<dbProductsInClient> productsInClient = new List<dbProductsInClient>();
        public static List<dbCall> ClientCalls = new List<dbCall>();
        public static List<dbContract> contracts = new List<dbContract>();
        public static List<dbContractList> contractsLists = new List<dbContractList>();
        public static List<ITree> treeListItems = new List<ITree>();
        public static List<dbReestr> reestr = new List<dbReestr>();
        public static List<ITree> treeListItemReestr = new List<ITree>();
        public static List<dbClientInReestr> clientIR = new List<dbClientInReestr>();




        public static void Init()
        {
            // Добавляем пользователей в телеграм бота.
            telegramBotUsers.Add(new TelegramBotUser
            {
                Name = "Евгений",
                Surname = "Пашин",
                Id = 302237012
            });
            telegramBotUsers.Add(new TelegramBotUser
            {
                Name = "Иван",
                Surname = "Пашин",
                Id = 788177332
            });
            telegramBotUsers.Add(new TelegramBotUser
            {
                Name = "Василий",
                Surname = "Шкурихин",
                Id = 1462846866
            });

            //for (int i = 0; i < 10000; i++)
            //{
            //    long number = 100000000000;
            //    long snils = number + i;
            //    string newSnils = snils.ToString().Substring(1, snils.ToString().Length-1);
            //    clients.Add(new dbClient { IsSelected = true, Snils = newSnils });
            //}

            #region Clients


            var client1 = new dbClient()
            {
                IsSelected = true,
                Snils = "00000000000"
            };

            var client2 = new dbClient()
            {
                IsSelected = false,
                Snils = "00000000001"
            };

            var client3 = new dbClient()
            {
                IsSelected = false,
                Snils = "00000000002"
            };

            clients.Add(client1);
            clients.Add(client2);
            clients.Add(client3);
            #endregion

            #region Documents

            var doc11 = new dbPersonalDocument()
            {
                ClientId = client1.Id,
                Daddyname = "Иванович",
                Name = "Иван",
                Surname = "Иванов",
                Department = "лрыпвыопа",
                Date = DateTime.Now.ToString("dd.MM.yyyy"),
                Gender = "М",
                Number = "1111",
                Serial = "111111",
                PlaceFrom = "Молдавия",
                RegistrationAddress = "г. Лаква, ул. ыв ывы, ывава"
            };

            var doc12 = new dbPersonalDocument()
            {
                ClientId = client1.Id,
                Daddyname = "Иванович",
                Name = "Иван",
                Surname = "Просак",
                Department = " sjhkljsdhfljdhlk",
                Date = DateTime.Now.ToString("dd.MM.yyyy"),
                Gender = "М",
                Number = "1112",
                Serial = "121111",
                PlaceFrom = "Молдавия",
                RegistrationAddress = "г. Уфа, ул. ыв ывы, ывава"
            };

            var doc21 = new dbPersonalDocument()
            {
                ClientId = client2.Id,
                Daddyname = "Петрович",
                Name = "Петр",
                Surname = "Петров",
                Department = "лрыпвыопа",
                Date = DateTime.Now.ToString("dd.MM.yyyy"),
                Gender = "М",
                Number = "1111",
                Serial = "111111",
                PlaceFrom = "Молдавия",
                RegistrationAddress = "г. Лаква, ул. ыв ывы, ывава"
            };

            var doc22 = new dbPersonalDocument()
            {
                ClientId = client2.Id,
                Daddyname = "Петрович",
                Name = "Петр",
                Surname = "Петров",
                Department = " sjhkljsdhfljdhlk",
                Date = DateTime.Now.ToString("dd.MM.yyyy"),
                Gender = "М",
                Number = "1112",
                Serial = "121111",
                PlaceFrom = "Молдавия",
                RegistrationAddress = "г. Уфа, ул. ыв ывы, ывава"
            };

            var doc23 = new dbPersonalDocument()
            {
                ClientId = client2.Id,
                Daddyname = "Петрович",
                Name = "Петр",
                Surname = "Петров",
                Department = " sjhkljsdhfljdhlk",
                Date = DateTime.Now.ToString("dd.MM.yyyy"),
                Gender = "М",
                Number = "1122",
                Serial = "121311",
                PlaceFrom = "Молдавия",
                RegistrationAddress = "г. Уфа, ул. ыв ывы, ывава"
            };

            var doc31 = new dbPersonalDocument()
            {
                ClientId = client3.Id,
                Daddyname = "Черкащевич",
                Name = "Черкаш",
                Surname = "Черкашев",
                Department = "лрыпвыопа",
                Date = DateTime.Now.ToString("dd.MM.yyyy"),
                Gender = "М",
                Number = "1451",
                Serial = "112131",
                PlaceFrom = "Пермь",
                RegistrationAddress = "г. Лаква, ул. ыв ывы, ывава"
            };

            personalDocuments.Add(doc11);
            personalDocuments.Add(doc12);
            personalDocuments.Add(doc21);
            personalDocuments.Add(doc22);
            personalDocuments.Add(doc23);
            personalDocuments.Add(doc31);

            #endregion

            #region Products


            var prod11 = new dbProductsInClient()
            {
                Count = 10,
                DirectionNumber = "3",
                IsGived = true,
                Title = "Подгузники",
                ClientId = client1.Id
            };

            var prod12 = new dbProductsInClient()
            {
                Count = 31,
                DirectionNumber = "005",
                IsGived = false,
                Title = "Салфетки",
                ClientId = client1.Id
            };

            var prod13 = new dbProductsInClient()
            {
                Count = 7,
                DirectionNumber = "000123",
                IsGived = true,
                Title = "Пеленки",
                ClientId = client1.Id
            };

            var prod21 = new dbProductsInClient()
            {
                Count = 1,
                DirectionNumber = "007",
                IsGived = false,
                Title = "Оплеухи",
                ClientId = client2.Id
            };
            var prod22 = new dbProductsInClient()
            {
                Count = 6,
                DirectionNumber = "666",
                IsGived = true,
                Title = "Душа",
                ClientId = client2.Id
            };
            var prod23 = new dbProductsInClient()
            {
                Count = 12,
                DirectionNumber = "00021",
                IsGived = false,
                Title = "Мыло",
                ClientId = client2.Id
            };

            var prod31 = new dbProductsInClient()
            {
                Count = 1,
                DirectionNumber = "0011",
                IsGived = false,
                Title = "Гвозди",
                ClientId = client3.Id
            };

            var prod32 = new dbProductsInClient()
            {
                Count = 6,
                DirectionNumber = "666",
                IsGived = true,
                Title = "Каша",
                ClientId = client3.Id
            };
            var prod33 = new dbProductsInClient()
            {
                Count = 9,
                DirectionNumber = "0008",
                IsGived = true,
                Title = "Суп",
                ClientId = client3.Id
            };

            productsInClient.Add(prod11);
            productsInClient.Add(prod12);
            productsInClient.Add(prod13);
            productsInClient.Add(prod21);
            productsInClient.Add(prod22);
            productsInClient.Add(prod23);
            productsInClient.Add(prod31);
            productsInClient.Add(prod32);
            productsInClient.Add(prod33);

            #endregion

            #region calls


            var dbCall11 = new dbCall()
            {
                ClientId = client1.Id,
                Telephone = "89630112231",
                Date = DateTime.Now.ToString("dd.MM.yyyy"),
            };
            var dbCall12 = new dbCall()
            {
                ClientId = client1.Id,
                Telephone = "89630782231",
                Date = DateTime.Now.ToString("dd.MM.yyyy"),
            };
            var dbCall21 = new dbCall()
            {
                ClientId = client2.Id,
                Telephone = "89500114232",
                Date = DateTime.Now.ToString("dd.MM.yyyy"),
            };
            var dbCall22 = new dbCall()
            {
                ClientId = client2.Id,
                Telephone = "89633312231",
                Date = DateTime.Now.ToString("dd.MM.yyyy"),
            };
            var dbCall31 = new dbCall()
            {
                ClientId = client3.Id,
                Telephone = "89990444433",
                Date = DateTime.Now.ToString("dd.MM.yyyy"),
            };
            var dbCall32 = new dbCall()
            {
                ClientId = client3.Id,
                Telephone = "89630109831",
                Date = DateTime.Now.ToString("dd.MM.yyyy"),
            };
            ClientCalls.Add(dbCall11);
            ClientCalls.Add(dbCall12);
            ClientCalls.Add(dbCall21);
            ClientCalls.Add(dbCall22);
            ClientCalls.Add(dbCall31);
            ClientCalls.Add(dbCall32);
            #endregion

            #region Contracts


            var contract1 = new dbContract() { Name = "Контракт 1", };
            var contract2 = new dbContract() { Name = "Контракт 2", };
            var contract3 = new dbContract() { Name = "Контракт 3", };

            contracts.Add(contract1);
            contracts.Add(contract2);
            contracts.Add(contract3);

            var cList11 = new dbContractList() { ParentId = contract1.Id, Name = "Список 11" };
            var cList12 = new dbContractList() { ParentId = contract1.Id, Name = "Список 12" };
            var cList13 = new dbContractList() { ParentId = contract1.Id, Name = "Список 13" };

            var cList21 = new dbContractList() { ParentId = contract2.Id, Name = "Список 21" };
            var cList22 = new dbContractList() { ParentId = contract2.Id, Name = "Список 22" };

            var cList31 = new dbContractList() { ParentId = contract3.Id, Name = "Список 31" };

            contractsLists.Add(cList11);
            contractsLists.Add(cList12);
            contractsLists.Add(cList13);
            contractsLists.Add(cList21);
            contractsLists.Add(cList22);
            contractsLists.Add(cList31);

            #endregion

            treeListItems.Add(contract1);
            treeListItems.Add(contract2);
            treeListItems.Add(contract3);
            treeListItems.Add(cList11);
            treeListItems.Add(cList12);
            treeListItems.Add(cList13);
            treeListItems.Add(cList21);
            treeListItems.Add(cList22);
            treeListItems.Add(cList31);

            var reestr1 = new dbReestr() { ParentId = cList11.Id, Name = "Реестр 1"};
            var reestr2 = new dbReestr() { ParentId = cList21.Id, Name = "Реестр 2"};
            var reestr3 = new dbReestr() { ParentId = cList31.Id, Name = "Реестр 3"};

            reestr.Add(reestr1);
            reestr.Add(reestr2);
            reestr.Add(reestr3);


            var clientIR1 = new dbClientInReestr { ParentId = reestr1.Id, Name = "Пупкин Живот Животович" };
            var clientIR2 = new dbClientInReestr { ParentId = reestr2.Id, Name = "Жемапель Сэр На Сери" };
            var clientIR3 = new dbClientInReestr { ParentId = reestr3.Id, Name = "Сергей Собянович Ле Мур" };

     
            treeListItemReestr.Add(reestr1);
            treeListItemReestr.Add(reestr2);
            treeListItemReestr.Add(reestr3);
            clientIR.Add(clientIR1);
            clientIR.Add(clientIR2);
            clientIR.Add(clientIR3);

            treeListItems.Add(reestr1);
            treeListItems.Add(reestr2);
            treeListItems.Add(reestr3);
            treeListItems.Add(clientIR1);
            treeListItems.Add(clientIR2);
            treeListItems.Add(clientIR3);





		}

    }
}
