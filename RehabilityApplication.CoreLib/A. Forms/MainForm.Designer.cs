namespace RehabilityApplication.CoreLib
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.RC = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bAuthorizationFormShow = new DevExpress.XtraBars.BarButtonItem();
            this.Skins = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.SkinPalettes = new DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem();
            this.btnShowSplashScreen = new DevExpress.XtraBars.BarButtonItem();
            this.btnGenerateDocuments = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenFileDialog = new DevExpress.XtraBars.BarButtonItem();
            this.bShowYesNoDialog = new DevExpress.XtraBars.BarButtonItem();
            this.bVasyaQuestion = new DevExpress.XtraBars.BarButtonItem();
            this.bIvanQuestion = new DevExpress.XtraBars.BarButtonItem();
            this.bShowMessage = new DevExpress.XtraBars.BarButtonItem();
            this.bVasiliyOkMessage = new DevExpress.XtraBars.BarButtonItem();
            this.bIvanOkMessage = new DevExpress.XtraBars.BarButtonItem();
            this.bCreateFolderOnYandexDisk = new DevExpress.XtraBars.BarButtonItem();
            this.bSaveDatabaseInYandexDisk = new DevExpress.XtraBars.BarButtonItem();
            this.bClearClients = new DevExpress.XtraBars.BarButtonItem();
            this.bCreateDatabase = new DevExpress.XtraBars.BarButtonItem();
            this.bCreateTable = new DevExpress.XtraBars.BarButtonItem();
            this.bAddRecord = new DevExpress.XtraBars.BarButtonItem();
            this.bShowDatabase = new DevExpress.XtraBars.BarButtonItem();
            this.bDeleteRecord = new DevExpress.XtraBars.BarButtonItem();
            this.tsIsChanges = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.bSync = new DevExpress.XtraBars.BarButtonItem();
            this.pageDatabase = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.groupDatabase = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageSourceData = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.groupFromExcelFile = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageDocuments = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.groupDocumentHandles = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageYandexDisk = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.groupYandex = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageContracts = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.groupContractActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageSQLite = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.groupSQLite = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RSB = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.DLAF = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.PC = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)this.RC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.PC).BeginInit();
            this.SuspendLayout();
            // 
            // RC
            // 
            this.RC.CaptionBarItemLinks.Add(this.bAuthorizationFormShow);
            this.RC.ExpandCollapseItem.Id = 0;
            this.RC.Items.AddRange(new DevExpress.XtraBars.BarItem[] { this.bAuthorizationFormShow, this.RC.ExpandCollapseItem, this.RC.SearchEditItem, this.Skins, this.SkinPalettes, this.btnShowSplashScreen, this.btnGenerateDocuments, this.btnOpenFileDialog, this.bShowYesNoDialog, this.bVasyaQuestion, this.bIvanQuestion, this.bShowMessage, this.bVasiliyOkMessage, this.bIvanOkMessage, this.bCreateFolderOnYandexDisk, this.bSaveDatabaseInYandexDisk, this.bClearClients, this.bCreateDatabase, this.bCreateTable, this.bAddRecord, this.bShowDatabase, this.bDeleteRecord, this.tsIsChanges, this.bSync });
            this.RC.Location = new System.Drawing.Point(0, 0);
            this.RC.MaxItemId = 24;
            this.RC.Name = "RC";
            this.RC.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { this.pageDatabase, this.pageSourceData, this.pageDocuments, this.pageYandexDisk, this.pageContracts, this.pageSQLite });
            this.RC.QuickToolbarItemLinks.Add(this.Skins);
            this.RC.QuickToolbarItemLinks.Add(this.SkinPalettes);
            this.RC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2007;
            this.RC.ShowQatLocationSelector = false;
            this.RC.ShowToolbarCustomizeItem = false;
            this.RC.Size = new System.Drawing.Size(1004, 162);
            this.RC.StatusBar = this.RSB;
            this.RC.Toolbar.ShowCustomizeItem = false;
            this.RC.SelectedPageChanged += this.RC_SelectedPageChanged;
            // 
            // bAuthorizationFormShow
            // 
            this.bAuthorizationFormShow.Caption = "Авторизация";
            this.bAuthorizationFormShow.Id = 14;
            this.bAuthorizationFormShow.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bAuthorizationFormShow.ImageOptions.SvgImage");
            this.bAuthorizationFormShow.Name = "bAuthorizationFormShow";
            this.bAuthorizationFormShow.ItemClick += this.bAuthorizationFormShow_ItemClick;
            // 
            // Skins
            // 
            this.Skins.Caption = "Стили отображения графического интерфейса";
            this.Skins.Id = 1;
            this.Skins.Name = "Skins";
            // 
            // SkinPalettes
            // 
            this.SkinPalettes.Caption = "Палитры текущего стиля отображения";
            this.SkinPalettes.Id = 2;
            this.SkinPalettes.Name = "SkinPalettes";
            // 
            // btnShowSplashScreen
            // 
            this.btnShowSplashScreen.Caption = "Показать сплэш-скрин";
            this.btnShowSplashScreen.Id = 4;
            this.btnShowSplashScreen.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnShowSplashScreen.ImageOptions.SvgImage");
            this.btnShowSplashScreen.Name = "btnShowSplashScreen";
            // 
            // btnGenerateDocuments
            // 
            this.btnGenerateDocuments.Caption = "Сгенерировать документацию";
            this.btnGenerateDocuments.Id = 5;
            this.btnGenerateDocuments.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnGenerateDocuments.ImageOptions.SvgImage");
            this.btnGenerateDocuments.Name = "btnGenerateDocuments";
            // 
            // btnOpenFileDialog
            // 
            this.btnOpenFileDialog.Caption = "Открыть окно открытия файла";
            this.btnOpenFileDialog.Id = 6;
            this.btnOpenFileDialog.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnOpenFileDialog.ImageOptions.SvgImage");
            this.btnOpenFileDialog.Name = "btnOpenFileDialog";
            this.btnOpenFileDialog.ItemClick += this.btnOpenFileDialog_ItemClick;
            // 
            // bShowYesNoDialog
            // 
            this.bShowYesNoDialog.Caption = "Открыть ДА/НЕТ диалоговое окно";
            this.bShowYesNoDialog.Id = 7;
            this.bShowYesNoDialog.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bShowYesNoDialog.ImageOptions.SvgImage");
            this.bShowYesNoDialog.Name = "bShowYesNoDialog";
            this.bShowYesNoDialog.ItemClick += this.bShowYesNoDialog_ItemClick;
            // 
            // bVasyaQuestion
            // 
            this.bVasyaQuestion.Caption = "Вопрос Василия";
            this.bVasyaQuestion.Id = 8;
            this.bVasyaQuestion.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bVasyaQuestion.ImageOptions.SvgImage");
            this.bVasyaQuestion.Name = "bVasyaQuestion";
            this.bVasyaQuestion.ItemClick += this.bVasyaQuestion_ItemClick;
            // 
            // bIvanQuestion
            // 
            this.bIvanQuestion.Caption = "Вопрос Ивана";
            this.bIvanQuestion.Id = 9;
            this.bIvanQuestion.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bIvanQuestion.ImageOptions.SvgImage");
            this.bIvanQuestion.Name = "bIvanQuestion";
            this.bIvanQuestion.ItemClick += this.bIvanQuestion_ItemClick;
            // 
            // bShowMessage
            // 
            this.bShowMessage.Caption = "Покажи сообщение";
            this.bShowMessage.Id = 10;
            this.bShowMessage.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bShowMessage.ImageOptions.SvgImage");
            this.bShowMessage.Name = "bShowMessage";
            this.bShowMessage.ItemClick += this.bShowMessage_ItemClick;
            // 
            // bVasiliyOkMessage
            // 
            this.bVasiliyOkMessage.Caption = "Василий, твой месседж";
            this.bVasiliyOkMessage.Id = 11;
            this.bVasiliyOkMessage.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bVasiliyOkMessage.ImageOptions.SvgImage");
            this.bVasiliyOkMessage.Name = "bVasiliyOkMessage";
            this.bVasiliyOkMessage.ItemClick += this.bVasiliyOkMessage_ItemClick;
            // 
            // bIvanOkMessage
            // 
            this.bIvanOkMessage.Caption = "Иван, твой месседж";
            this.bIvanOkMessage.Id = 12;
            this.bIvanOkMessage.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bIvanOkMessage.ImageOptions.SvgImage");
            this.bIvanOkMessage.Name = "bIvanOkMessage";
            this.bIvanOkMessage.ItemClick += this.bIvanOkMessage_ItemClick;
            // 
            // bCreateFolderOnYandexDisk
            // 
            this.bCreateFolderOnYandexDisk.Caption = "Создать папку";
            this.bCreateFolderOnYandexDisk.Id = 13;
            this.bCreateFolderOnYandexDisk.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bCreateFolderOnYandexDisk.ImageOptions.SvgImage");
            this.bCreateFolderOnYandexDisk.Name = "bCreateFolderOnYandexDisk";
            this.bCreateFolderOnYandexDisk.ItemClick += this.bCreateFolderOnYandexDisk_ItemClick;
            // 
            // bSaveDatabaseInYandexDisk
            // 
            this.bSaveDatabaseInYandexDisk.Caption = "Сохранить БД на сервер";
            this.bSaveDatabaseInYandexDisk.Id = 15;
            this.bSaveDatabaseInYandexDisk.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bSaveDatabaseInYandexDisk.ImageOptions.SvgImage");
            this.bSaveDatabaseInYandexDisk.Name = "bSaveDatabaseInYandexDisk";
            this.bSaveDatabaseInYandexDisk.ItemClick += this.bSaveDatabaseInYandexDisk_ItemClick;
            // 
            // bClearClients
            // 
            this.bClearClients.Caption = "Очистить клиентов";
            this.bClearClients.Id = 16;
            this.bClearClients.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bClearClients.ImageOptions.SvgImage");
            this.bClearClients.Name = "bClearClients";
            this.bClearClients.ItemClick += this.bClearClients_ItemClick;
            // 
            // bCreateDatabase
            // 
            this.bCreateDatabase.Caption = "Создать БД";
            this.bCreateDatabase.Id = 17;
            this.bCreateDatabase.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bCreateDatabase.ImageOptions.SvgImage");
            this.bCreateDatabase.Name = "bCreateDatabase";
            this.bCreateDatabase.ItemClick += this.bCreateDatabase_ItemClick;
            // 
            // bCreateTable
            // 
            this.bCreateTable.Caption = "Создать таблицу";
            this.bCreateTable.Id = 18;
            this.bCreateTable.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bCreateTable.ImageOptions.SvgImage");
            this.bCreateTable.Name = "bCreateTable";
            this.bCreateTable.ItemClick += this.bCreateTable_ItemClick;
            // 
            // bAddRecord
            // 
            this.bAddRecord.Caption = "Добавить запись";
            this.bAddRecord.Id = 19;
            this.bAddRecord.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bAddRecord.ImageOptions.SvgImage");
            this.bAddRecord.Name = "bAddRecord";
            this.bAddRecord.ItemClick += this.bAddRecord_ItemClick;
            // 
            // bShowDatabase
            // 
            this.bShowDatabase.Caption = "Показать записи";
            this.bShowDatabase.Id = 20;
            this.bShowDatabase.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bShowDatabase.ImageOptions.SvgImage");
            this.bShowDatabase.Name = "bShowDatabase";
            this.bShowDatabase.ItemClick += this.bShowDatabase_ItemClick;
            // 
            // bDeleteRecord
            // 
            this.bDeleteRecord.Caption = "Удалить запись";
            this.bDeleteRecord.Id = 21;
            this.bDeleteRecord.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bDeleteRecord.ImageOptions.SvgImage");
            this.bDeleteRecord.Name = "bDeleteRecord";
            this.bDeleteRecord.ItemClick += this.bDeleteRecord_ItemClick;
            // 
            // tsIsChanges
            // 
            this.tsIsChanges.Caption = "Сохранять как изменение";
            this.tsIsChanges.Id = 22;
            this.tsIsChanges.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("tsIsChanges.ImageOptions.SvgImage");
            this.tsIsChanges.Name = "tsIsChanges";
            this.tsIsChanges.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            // 
            // bSync
            // 
            this.bSync.Caption = "Синхронизация";
            this.bSync.Id = 23;
            this.bSync.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bSync.ImageOptions.SvgImage");
            this.bSync.Name = "bSync";
            this.bSync.ItemClick += this.bSync_ItemClick;
            // 
            // pageDatabase
            // 
            this.pageDatabase.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { this.groupDatabase });
            this.pageDatabase.Name = "pageDatabase";
            this.pageDatabase.Text = "База данных";
            // 
            // groupDatabase
            // 
            this.groupDatabase.ItemLinks.Add(this.btnShowSplashScreen);
            this.groupDatabase.ItemLinks.Add(this.btnOpenFileDialog);
            this.groupDatabase.ItemLinks.Add(this.bShowYesNoDialog);
            this.groupDatabase.ItemLinks.Add(this.bVasyaQuestion);
            this.groupDatabase.ItemLinks.Add(this.bIvanQuestion);
            this.groupDatabase.ItemLinks.Add(this.bShowMessage);
            this.groupDatabase.ItemLinks.Add(this.bVasiliyOkMessage);
            this.groupDatabase.ItemLinks.Add(this.bIvanOkMessage);
            this.groupDatabase.ItemLinks.Add(this.bSaveDatabaseInYandexDisk);
            this.groupDatabase.ItemLinks.Add(this.bClearClients);
            this.groupDatabase.Name = "groupDatabase";
            this.groupDatabase.Text = "База данных";
            // 
            // pageSourceData
            // 
            this.pageSourceData.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { this.groupFromExcelFile });
            this.pageSourceData.Name = "pageSourceData";
            this.pageSourceData.Text = "Исходные данные";
            // 
            // groupFromExcelFile
            // 
            this.groupFromExcelFile.Name = "groupFromExcelFile";
            this.groupFromExcelFile.Text = "Источник Excel";
            // 
            // pageDocuments
            // 
            this.pageDocuments.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { this.groupDocumentHandles });
            this.pageDocuments.Name = "pageDocuments";
            this.pageDocuments.Text = "Документы";
            // 
            // groupDocumentHandles
            // 
            this.groupDocumentHandles.ItemLinks.Add(this.btnGenerateDocuments);
            this.groupDocumentHandles.Name = "groupDocumentHandles";
            this.groupDocumentHandles.Text = "Обработка";
            // 
            // pageYandexDisk
            // 
            this.pageYandexDisk.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { this.groupYandex });
            this.pageYandexDisk.Name = "pageYandexDisk";
            this.pageYandexDisk.Text = "Яндекс.Диск";
            // 
            // groupYandex
            // 
            this.groupYandex.ItemLinks.Add(this.bCreateFolderOnYandexDisk);
            this.groupYandex.Name = "groupYandex";
            this.groupYandex.Text = "Яндекс";
            // 
            // pageContracts
            // 
            this.pageContracts.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { this.groupContractActions });
            this.pageContracts.Name = "pageContracts";
            this.pageContracts.Text = "Контракты";
            // 
            // groupContractActions
            // 
            this.groupContractActions.Name = "groupContractActions";
            this.groupContractActions.Text = "Действия";
            // 
            // pageSQLite
            // 
            this.pageSQLite.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { this.groupSQLite });
            this.pageSQLite.Name = "pageSQLite";
            this.pageSQLite.Text = "SQLite";
            // 
            // groupSQLite
            // 
            this.groupSQLite.ItemLinks.Add(this.bCreateDatabase);
            this.groupSQLite.ItemLinks.Add(this.bCreateTable);
            this.groupSQLite.ItemLinks.Add(this.bAddRecord);
            this.groupSQLite.ItemLinks.Add(this.bShowDatabase);
            this.groupSQLite.ItemLinks.Add(this.bDeleteRecord);
            this.groupSQLite.ItemLinks.Add(this.tsIsChanges);
            this.groupSQLite.ItemLinks.Add(this.bSync);
            this.groupSQLite.Name = "groupSQLite";
            this.groupSQLite.Text = "Действия SQLite";
            // 
            // RSB
            // 
            this.RSB.Location = new System.Drawing.Point(0, 607);
            this.RSB.Name = "RSB";
            this.RSB.Ribbon = this.RC;
            this.RSB.Size = new System.Drawing.Size(1004, 24);
            // 
            // DLAF
            // 
            this.DLAF.LookAndFeel.SkinName = "The Bezier";
            // 
            // PC
            // 
            this.PC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PC.Location = new System.Drawing.Point(0, 162);
            this.PC.Name = "PC";
            this.PC.Size = new System.Drawing.Size(1004, 445);
            this.PC.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 631);
            this.Controls.Add(this.PC);
            this.Controls.Add(this.RSB);
            this.Controls.Add(this.RC);
            this.Name = "MainForm";
            this.Ribbon = this.RC;
            this.StatusBar = this.RSB;
            ((System.ComponentModel.ISupportInitialize)this.RC).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.PC).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl RC;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageDatabase;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupDatabase;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar RSB;
        private DevExpress.LookAndFeel.DefaultLookAndFeel DLAF;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageSourceData;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupFromExcelFile;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageDocuments;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupDocumentHandles;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem Skins;
        private DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem SkinPalettes;
        private DevExpress.XtraBars.BarButtonItem btnShowSplashScreen;
        private DevExpress.XtraBars.BarButtonItem btnGenerateDocuments;
        private DevExpress.XtraBars.BarButtonItem btnOpenFileDialog;
        private DevExpress.XtraBars.BarButtonItem bShowYesNoDialog;
        private DevExpress.XtraBars.BarButtonItem bVasyaQuestion;
        private DevExpress.XtraBars.BarButtonItem bIvanQuestion;
        private DevExpress.XtraBars.BarButtonItem bShowMessage;
        private DevExpress.XtraBars.BarButtonItem bVasiliyOkMessage;
        private DevExpress.XtraBars.BarButtonItem bIvanOkMessage;
        private DevExpress.XtraBars.BarButtonItem bCreateFolderOnYandexDisk;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageYandexDisk;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupYandex;
        private DevExpress.XtraBars.BarButtonItem bAuthorizationFormShow;
        private DevExpress.XtraBars.BarButtonItem bSaveDatabaseInYandexDisk;
        private DevExpress.XtraBars.BarButtonItem bClearClients;
        private DevExpress.XtraEditors.PanelControl PC;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageContracts;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupContractActions;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageSQLite;
        private DevExpress.XtraBars.BarButtonItem bCreateDatabase;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupSQLite;
        private DevExpress.XtraBars.BarButtonItem bCreateTable;
        private DevExpress.XtraBars.BarButtonItem bAddRecord;
        private DevExpress.XtraBars.BarButtonItem bShowDatabase;
        private DevExpress.XtraBars.BarButtonItem bDeleteRecord;
        private DevExpress.XtraBars.BarToggleSwitchItem tsIsChanges;
        private DevExpress.XtraBars.BarButtonItem bSync;
    }
}