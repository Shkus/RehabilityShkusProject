using DevExpress.XtraSplashScreen;
using System.Threading.Tasks;

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
    }
}