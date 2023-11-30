using DevExpress.Utils.MVVM;
using DevExpress.Xpo;
using DevExpress.XtraRichEdit;
using DevExpress.XtraScheduler.Outlook.Native;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace RehabilityApplication.CoreLib
{
    /// <summary>
    /// Класс главной формы приложения.
    /// </summary>
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        const string clientFile = "clients.xml";

        const string tableName = "Persons";

        /// <summary>
        /// Элемент управления меню, по нажатию кнопк приложения.
        /// </summary>
        ucBackstageMenu backMenu = new ucBackstageMenu();

        /// <summary>
        /// Слой отображения базы данных.
        /// </summary>
        ucDatabaseViewLayer databaseViewLayer = new ucDatabaseViewLayer();

        /// <summary>
        /// Слой отображения исходных данных.
        /// </summary>
        ucSourceDataViewer sourceDataViewLayer = new ucSourceDataViewer();

        /// <summary>
        /// Слой отображения сгенерированных документов.
        /// </summary>
        ucDocumentViewer documentViewLayer = new ucDocumentViewer();

        /// <summary>
        /// Слой отображения структуры папок на Яндекс диске
        /// </summary>
        ucStructureViewer structureViewer = new ucStructureViewer();

        /// <summary>
        /// Слой отображения контрактов и списков контрактов
        /// </summary>
        ucContractView contractsView = new ucContractView();

        /// <summary>
        /// Слой отображения данных SQLite
        /// </summary>
        ucSQLiteViewer sqliteView = new ucSQLiteViewer();

        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public MainForm()
        {
            int Count = 0;

            // Инициализция элементов управления формы.
            InitializeComponent();

            ApplicationSettings.TS = this.tsIsChanges;

            // Подключение элемента управления меню к кнопке приложения.
            RC.ApplicationButtonDropDownControl = backMenu;

            //sqliteView = new ucSQLiteViewer(tsIsChanges);

            // Добавляем слой отображения БД на форму.
            this.PC.Controls.Add(databaseViewLayer);
            // Добавляем слой отображения исходных данных на форму.
            this.PC.Controls.Add(sourceDataViewLayer);
            // Добавляем слой отображения документов на форму.
            this.PC.Controls.Add(documentViewLayer);
            // Добавляем слой отображения структуры папок на Яндекс диске.
            this.PC.Controls.Add(structureViewer);
            // Добавляем слой отображения конрактов.
            this.PC.Controls.Add(contractsView);
            // Добавляем слой отображения данных SQLite.
            this.PC.Controls.Add(sqliteView);

            this.Shown += (s, e) =>
            {



                GlobalDatabaseManager.Init();
                TelegramBotManager.Init();

                CoreGlobalCommandManager.StartCommand(DatabaseCommandType.DatabaseWasInitializated);

                CoreGlobalCommandManager.CommandInitialized += (s, e) =>
                {
                    if(e.Command is YandexDiskManagerCommandType.DatabaseUploaded)
                    {
                        YandexDiskManager.GetFolderStructure("/25-10-2023/Database");
                        //MessageBox.Show("База данных успешно загружена на сервер!");
                    }

                    if(e.Command is EnumLanguageType.Russian || e.Command is EnumLanguageType.English)
                    {
                        RelanguageUI();
                    }

                };

                CoreGlobalCommandManager.CommandDataReceivingInitialized += (s, e) =>
                {

                    if(e.Command is YandexDiskManagerCommandType.FolderStructureWasReaded)
                    {
                        List<ITreeListItem> structure = e.Data;

                        var files = structure.Where(t => t is HostFileItem).ToList();

                        HostFileItem dbXml = (HostFileItem)files.Where(t => t.Name == "db.xml").FirstOrDefault();
                        if(dbXml != null)
                        {
                            string md5 = FileManager.GetMd5(clientFile);

                            if(md5 == dbXml.Md5)
                            {
                                //MessageBox.Show("Ура, файл загружен успешно!");
                            }
                            else
                            {
                                //MessageBox.Show("Упс, похоже файл недогрузился! Повтори попытку!");
                            }
                        }
                        else
                        {
                            //MessageBox.Show("Увы, файл не был загружен!");
                        }
                    }
                };

                //bAuthorizationFormShow.PerformClick();
            };

            this.FormClosing += (s, e) =>
            {
                DialogResult dr = CustomFlyoutDialog.ShowForm(this, null, new ucYesNoDialog("Вы уверены, что хотите выйти из программы?"));

                if(dr != DialogResult.OK)
                {
                    e.Cancel = true;
                }
            };

            btnShowSplashScreen.ItemClick += (s, e) =>
            {
                Task.Run(() =>
                {
                    SplashScreenManager.ShowForm(this, typeof(ProgressForm), true, true, true, true);
                    System.Threading.Thread.Sleep(5000);
                    SplashScreenManager.CloseForm();
                });
            };

            btnGenerateDocuments.ItemClick += (s, e) =>
            {
                Task.Run(() =>
                {
                    SplashScreenManager.ShowForm(this, typeof(ProgressForm), true, true, true, true);
                    DocumentGenerationManager.GenerateDocuments();
                    SplashScreenManager.CloseForm();
                });


            };


        }

        private void RelanguageUI()
        {
            bCreateTable.SetResourceString();
            bAddRecord.SetResourceString();
            bCreateDatabase.SetResourceString();
            bDeleteRecord.SetResourceString();
            bIvanOkMessage.SetResourceString();
            bIvanQuestion.SetResourceString();
            bMapping.SetResourceString();
            bSaveDatabaseInYandexDisk.SetResourceString();
            bShowDatabase.SetResourceString();
            bShowMessage.SetResourceString();
            bShowYesNoDialog.SetResourceString();
            bSync.SetResourceString();
            btnGenerateDocuments.SetResourceString();
            bVasiliyOkMessage.SetResourceString();
            btnShowSplashScreen.SetResourceString();
            btnOpenFileDialog.SetResourceString();
            bClearClients.SetResourceString();
            bCreateFolderOnYandexDisk.SetResourceString();
            tsIsChanges.SetResourceString();
            this.SetResourceString();
            pageContracts.SetResourceString();
            pageDatabase.SetResourceString();
            pageDocuments.SetResourceString();
            pageSourceData.SetResourceString();
            pageSQLite.SetResourceString();
            pageYandexDisk.SetResourceString();
            groupContractActions.SetResourceString();
            groupDatabase.SetResourceString();
            groupDocumentHandles.SetResourceString();
            groupFromExcelFile.SetResourceString();
            groupSQLite.SetResourceString();
            groupYandex.SetResourceString();
        }


        /// <summary>
        /// Обработчик события переключения вкладок.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RC_SelectedPageChanged(object sender, System.EventArgs e)
        {
            if(RC.SelectedPage.Name == nameof(this.pageDocuments))
            {
                documentViewLayer.BringToFront();
            }

            if(RC.SelectedPage.Name == nameof(this.pageDatabase))
            {
                databaseViewLayer.BringToFront();
            }

            if(RC.SelectedPage.Name == nameof(this.pageSourceData))
            {
                sourceDataViewLayer.BringToFront();
            }

            if(RC.SelectedPage.Name == nameof(this.pageYandexDisk))
            {
                structureViewer.BringToFront();
            }

            if(RC.SelectedPage.Name == nameof(this.pageContracts))
            {
                contractsView.BringToFront();
            }

            if(RC.SelectedPage.Name == nameof(this.pageSQLite))
            {
                sqliteView.BringToFront();
            }
        }

        private void btnOpenFileDialog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            DialogResult dr = openFileDialog.ShowDialog();
        }

        private void bShowYesNoDialog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = CustomFlyoutDialog.ShowForm(this, null, new ucYesNoDialog("Вы довольны своей зарплатой?"));

            if(result == DialogResult.OK)
            {
                this.Text = "OK";
            }
            else
            {
                this.Text = "CANCEL";
            }
        }

        private void bVasyaQuestion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = CustomFlyoutDialog.ShowForm(this, null, new ucYesNoDialog("Вы хотите попасть в IT?"));

            if(result == DialogResult.OK)
            {
                this.Text = "Чууувааак";
            }
            else
            {
                this.Text = "Врешь...";
            }

        }

        private void bIvanQuestion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = CustomFlyoutDialog.ShowForm(this, null, new ucYesNoDialog("Хочешь здоровья?"));

            if(result == DialogResult.OK)
            {
                this.Text = "Закаляйся!";
            }
            else
            {
                this.Text = "Твой выбор(";
            }
        }

        private void bShowMessage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CustomFlyoutDialog.ShowForm(this, null, new ucOkDialog("Ты знаешь, а твоя лицензия закончилась, ещё вчера. Будь добр, оплати подписку и живи спокойно дальше!!!"));
        }

        private void bVasiliyOkMessage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CustomFlyoutDialog.ShowForm(this, null, new ucOkDialog("Уважаемый, помни, что каждое нажатие клавишы ОК приводит тебя к тому, что ты станешь подкаблучником и будешь со всем соглашаться. Понял?"));
        }

        private void bIvanOkMessage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CustomFlyoutDialog.ShowForm(this, null, new ucOkDialog("Необходимо хотя раз в день делать зарядку, полезно для кровообращения "));
        }

        private void bCreateFolderOnYandexDisk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool result = YandexDiskManager.CreateFolder("/25-10-2023/", $"{DateTime.Now.ToString("dd.MM.yyyy, HH_mm_ss_fff")}", "Евгений");

        }

        private void bAuthorizationFormShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CustomFlyoutDialog.ShowForm(this, null, new ucAuthorizationForm());
        }

        private void bSaveDatabaseInYandexDisk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var ourClients = GlobalDatabaseManager.clients;
            ClassObject.Serialize(ourClients, clientFile);
            YandexDiskManager.UploadFile("/25-10-2023/Database/db.xml", clientFile);
        }

        private void bClearClients_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CoreGlobalCommandManager.StartCommand(DatabaseCommandType.ClearClients);
        }

        private void bCreateDatabase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqliteManager.CreateDatabaseLocal("Database.db");
        }

        private void bCreateTable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqliteManager.CreateTableInDatabase(tableName);
        }

        private void bAddRecord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string columnNames = "Name, Age, IsSelected";
            if(tsIsChanges.Checked == false)
            {

                SqliteManager.AddRecordToTable(tableName, columnNames, $"'Tom', 22, true");
                SqliteManager.AddRecordToTable(tableName, columnNames, $"'Alice', 32, true");
                SqliteManager.AddRecordToTable(tableName, columnNames, $"'Bryan', 34, false");
                SqliteManager.AddRecordToTable(tableName, columnNames, $"'Oliver', 19, true");
                SqliteManager.AddRecordToTable(tableName, columnNames, $"'Dag', 55, true");
            }
            else
            {
                SqliteManager.SaveAddRecordChange(tableName, columnNames, $"'Tom', 22, true");
                SqliteManager.SaveAddRecordChange(tableName, columnNames, $"'Alice', 32, true");
                SqliteManager.SaveAddRecordChange(tableName, columnNames, $"'Bryan', 34, false");
                SqliteManager.SaveAddRecordChange(tableName, columnNames, $"'Oliver', 19, true");
                SqliteManager.SaveAddRecordChange(tableName, columnNames, $"'Dag', 55, true");
            }

        }

        private void bShowDatabase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var data = SqliteManager.GetRecords(tableName);

            CoreGlobalCommandManager.StartReceiveDataCommand(SQLiteCommandType.LoadDataComplete, data);
        }

        private void bDeleteRecord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CoreGlobalCommandManager.StartCommand(SQLiteCommandType.DeleteRecordPlease);
            bShowDatabase.PerformClick();
        }

        private void bSync_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqliteManager.Synchronize();
        }

        private void bMapping_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var data = SqliteManager.MapData(tableName);
            CoreGlobalCommandManager.StartReceiveDataCommand(SQLiteCommandType.LoadDataComplete, data);

            //List<ToyClass> list = new List<ToyClass>();

            ////////////ToyClass car1 = new CarClass() { Name = "Masha" };

            ////////////Product sh1 = new Shkaf();
            ////////////Product sh2 = new Shkaf();
            ////////////Product sh3 = new Shkaf();

            ////////////Product dr1 = new Door();
            ////////////Product dr2 = new Door();
            ////////////Product dr3 = new Door();

            ////////////car1.Sold(new List<Product> { sh1, dr1, sh2, dr2, dr3, sh3 });

            //CarClass car1 = new CarClass() { Engine = "V6", Id="564" };
            //CarClass car2 = new CarClass(car1) { Engine = "V8" };

            //lis.Add(doll1);
            //list.Add(car1);

            //doll1.Plakat();
            ////car1.Ehat();
        }

        private void bEngLang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ApplicationSettings.CurrentLanguage = EnumLanguageType.English;
            //CoreGlobalCommandManager.StartCommand(EnumLanguageType.English);
        }

        private void bRusLang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ApplicationSettings.CurrentLanguage = EnumLanguageType.Russian;
            //CoreGlobalCommandManager.StartCommand(EnumLanguageType.Russian);
        }

        private void bDocumentType1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ////DocumentType1 documentType1 = new DocumentType1() { Name = "Meridian", Description = "Пуско-наладочные работы" };
            //DocumentType1 documentType1 = new DocumentType1() { Name = "Роботех", Description = "Починить робота" };

            //documentType1.GenerateDocument();

            // Ivan
            IvanTemplateResume itr = new IvanTemplateResume()
            {
                Name = "Иван",
                Profession = "Грузчик",
                Objective = "Шланги",
                Skills = "Копать и не копать",
                Jobtitle = "Старший Грузчик",
                Company = "Промет",
                StartDate = "2019",
                Description_experience = "Бери больше, кидай дальше",
                Y_E = "2005-2008",
                INS = "Пермский радиотехнический",
                T_S = "10 из 10"




            };
            itr.GenerateDocument();


        }

        private void bDocumentType2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //DocumentType2 documentType2 = new DocumentType2() {Name = "Горец", Company = "Роботех", Address = "ул. Шоссе Космнавтов 395, лит. Е", City = "Пермь",
            //RecepientName = "Дункин Маклауд", Title = "Проект СВЕЗАААААА!!!"};

            //documentType2.GenerateDocument();

            // VasiliyVa

            VasiliyResumeType vrt = new VasiliyResumeType()
            {
                name = "Васиилий",
                surname = "Шкурихин",
                address = "Пермь",
                phone = "89222415995",
                mail = "ru",
                about = "Начинающий C# разработчик",
                startDate = "2009",
                jobTitle = "Начальник бюро сборки и испытаний перспективной авиации",
                company = "АО «Пермский завод Машиностроитель»",
                describe = "хватит с меня",
                year = "2003",
                school = "СОШ",
                totalScore = "4,5",
                hobby = "программирование, квадроциклы, снегоходы"

            };

            vrt.GenerateDocument();

        }

        private void bDocumentType3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //DocumentType3 documentType3 = new DocumentType3()
            //{
            //    Name = "Дункан",
            //    Surname = "Маклауд"
            //};

            //documentType3.GenerateDocument();
        }

        private void bClientEditor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = CustomFlyoutDialog.ShowForm(this, null, new ucClientEditor(new dbClient() { Count = 1234 }, 500, 1000));

            if(result == DialogResult.OK)
            {
            }
            else
            {
            }
        }

        private void bOpenExcelFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            JuniorExcelFileManager.OpenExcelFile();
        }

        private void bShowAsTreeList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CoreGlobalCommandManager.StartCommand(SourceDataCommandType.ShowAsTreeList);
        }

        private void bShowAsExcelView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CoreGlobalCommandManager.StartCommand(SourceDataCommandType.ShowAsExcelView);
        }

        private void bShowProducts_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //// Middle
            //ProductHeader ph = new ProductHeader();
            //MiddleExcelUniversalFileManager.OpenExcelFile(ph);

            //// Senior
            ProductHeader ph = new ProductHeader();
            SeniorExcelUniversalFileManager<ProductItem, ProductHeader>.OpenExcelFile(ph);
        }

        private void bShowClientSimplified_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TableItem2Header ph = new TableItem2Header();
            SeniorExcelUniversalFileManager<TableItem2, TableItem2Header>.OpenExcelFile(ph);
        }

        private void bShowEO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
			EOHeader ph = new EOHeader();
			SeniorExcelUniversalFileManager<EOItem, EOHeader>.OpenExcelFile(ph);
		}
    }


    public enum SourceDataCommandType
    {
        ShowAsTreeList,
        ShowAsExcelView,
    }



    public class DocumentType1
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [AutoReplace(ParameterName: "%Name%")]
        public string Name { get; set; }
        [AutoReplace(ParameterName: "%Description%")]
        public string Description { get; set; }
        public string TemplateFilename = @"D:\!!! Базовые элементы\Рабочий стол\Акт выполненных работ.docx";
        public DocumentType1() { }
    }

    public class DocumentType2
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [AutoReplace(ParameterName: "%RecepientName%")]
        public string RecepientName { get; set; }
        [AutoReplace(ParameterName: "%Title%")]
        public string Title { get; set; }
        [AutoReplace(ParameterName: "%Company%")]
        public string Company { get; set; }
        [AutoReplace(ParameterName: "%Address%")]
        public string Address { get; set; }
        [AutoReplace(ParameterName: "%City%")]
        public string City { get; set; } // %CITY%
        [AutoReplace(ParameterName: "%Name%")]
        public string Name { get; set; } // %NAME%


        public string TemplateFilename = @"D:\!!! Базовые элементы\Рабочий стол\RECEPIENTNAME.docx";
        public DocumentType2() { }
    }
    public class DocumentType3
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [AutoReplace(ParameterName: "%Name%")]
        public string Name { get; set; }
        [AutoReplace(ParameterName: "%Surname%")]
        public string Surname { get; set; }
        public string TemplateFilename = @"D:\!!! Базовые элементы\Рабочий стол\Resume.docx";
        public DocumentType3() { }
    }

    public class VasiliyResumeType

    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [AutoReplace("%Name%")]
        public string name { get; set; }
        [AutoReplace("%Surname%")]
        public string surname { get; set; }
        [AutoReplace("%Address%")]
        public string address { get; set; }
        [AutoReplace("%Phone%")]
        public string phone { get; set; }
        [AutoReplace("%Mail%")]
        public string mail { get; set; }
        [AutoReplace("%About%")]
        public string about { get; set; }
        [AutoReplace("%Start_Date%")]
        public string startDate { get; set; }
        [AutoReplace("%Job_Title%")]
        public string jobTitle { get; set; }
        [AutoReplace("%Company%")]
        public string company { get; set; }
        [AutoReplace("%Describe%")]
        public string describe { get; set; }
        [AutoReplace("%Year%")]
        public string year { get; set; }
        [AutoReplace("%School%")]
        public string school { get; set; }
        [AutoReplace("%Total_Score%")]
        public string totalScore { get; set; }
        [AutoReplace("%Hobby%")]
        public string hobby { get; set; }

        public string TemplateFilename = @"D:\!!! Базовые элементы\Рабочий стол\VasiliyTemplate.docx";
        public VasiliyResumeType() { }
    }


    public class IvanTemplateResume
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [AutoReplace(ParameterName: "%Name%")]
        public string Name { get; set; }
        [AutoReplace(ParameterName: "%Profession%")]
        public string Profession { get; set; }
        [AutoReplace(ParameterName: "%objective%")]
        public string Objective { get; set; }
        [AutoReplace(ParameterName: "%Skills%")]
        public string Skills { get; set; }
        [AutoReplace("%Jobtitle%")]
        public string Jobtitle { get; set; }
        [AutoReplace("%Company%")]
        public string Company { get; set; }
        [AutoReplace("%StartDate%")]
        public string StartDate { get; set; }
        [AutoReplace("%Decription_experience%")]
        public string Description_experience { get; set; }
        [AutoReplace("%Year_Education%")]
        public string Y_E { get; set; }
        [AutoReplace("%Institute%")]
        public string INS { get; set; }
        [AutoReplace("%Total_Score%")]
        public string T_S { get; set; }



        public string TemplateFilename = @"D:\!!! Базовые элементы\Рабочий стол\IvanTemplate.docx";
        public IvanTemplateResume() { }
    }
}