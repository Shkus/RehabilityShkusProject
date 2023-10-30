using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RehabilityApplication.CoreLib
{
    /// <summary>
    /// Класс главной формы приложения.
    /// </summary>
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        const string clientFile = "clients.xml";
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
        /// Конструктор формы.
        /// </summary>
        public MainForm()
        {
            int Count = 0;

            // Инициализция элементов управления формы.
            InitializeComponent();

            // Подключение элемента управления меню к кнопке приложения.
            RC.ApplicationButtonDropDownControl = backMenu;

            // Добавляем слой отображения БД на форму.
            this.Controls.Add(databaseViewLayer);
            // Добавляем слой отображения исходных данных на форму.
            this.Controls.Add(sourceDataViewLayer);
            // Добавляем слой отображения документов на форму.
            this.Controls.Add(documentViewLayer);
            // Добавляем слой отображения структуры папок на Яндекс диске.
            this.Controls.Add(structureViewer);

            this.Shown += (s, e) =>
            {
                GlobalDatabaseManager.Init();
                TelegramBotManager.Init();

                CoreGlobalCommandManager.StartCommand(DatabaseCommandType.DatabaseWasInitializated);

                CoreGlobalCommandManager.CommandInitialized += (s, e) =>
                {
                    if (e.Command is YandexDiskManagerCommandType.DatabaseUploaded)
                    {
                        YandexDiskManager.GetFolderStructure("/25-10-2023/Database");
                        //MessageBox.Show("База данных успешно загружена на сервер!");
                    }

                };

                CoreGlobalCommandManager.CommandDataReceivingInitialized += (s, e) =>
                {

                    if (e.Command is YandexDiskManagerCommandType.FolderStructureWasReaded)
                    {
                        List<ITreeListItem> structure = e.Data;

                        var files = structure.Where(t => t is HostFileItem).ToList();

                        HostFileItem dbXml = (HostFileItem)files.Where(t => t.Name == "db.xml").FirstOrDefault();
                        if (dbXml != null)
                        {
                            string md5 = FileManager.GetMd5(clientFile);

                            if (md5 == dbXml.Md5)
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

                bAuthorizationFormShow.PerformClick();
            };

            this.FormClosing += (s, e) =>
            {
                DialogResult dr = CustomFlyoutDialog.ShowForm(this, null, new ucYesNoDialog("Вы уверены, что хотите выйти из программы?"));

                if (dr != DialogResult.OK)
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

        /// <summary>
        /// Обработчик события переключения вкладок.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RC_SelectedPageChanged(object sender, System.EventArgs e)
        {
            if (RC.SelectedPage.Name == nameof(this.pageDocuments))
            {
                documentViewLayer.BringToFront();
            }

            if (RC.SelectedPage.Name == nameof(this.pageDatabase))
            {
                databaseViewLayer.BringToFront();
            }

            if (RC.SelectedPage.Name == nameof(this.pageSourceData))
            {
                sourceDataViewLayer.BringToFront();
            }

            if (RC.SelectedPage.Name == nameof(this.pageYandexDisk))
            {
                structureViewer.BringToFront();
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

            if (result == DialogResult.OK)
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

            if (result == DialogResult.OK)
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

            if (result == DialogResult.OK)
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
    }
}