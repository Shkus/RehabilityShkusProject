using DevExpress.XtraSplashScreen;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RehabilityApplication.CoreLib
{
    /// <summary>
    /// Класс главной формы приложения.
    /// </summary>
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
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

            this.Shown += (s, e) =>
            {
                GlobalDatabaseManager.Init();
                TelegramBotManager.Init();

                CoreGlobalCommandManager.StartCommand(DatabaseCommandType.DatabaseWasInitializated);
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
    }
}