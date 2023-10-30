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
            if (disposing && (components != null))
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            RC = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bAuthorizationFormShow = new DevExpress.XtraBars.BarButtonItem();
            Skins = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            SkinPalettes = new DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem();
            btnShowSplashScreen = new DevExpress.XtraBars.BarButtonItem();
            btnGenerateDocuments = new DevExpress.XtraBars.BarButtonItem();
            btnOpenFileDialog = new DevExpress.XtraBars.BarButtonItem();
            bShowYesNoDialog = new DevExpress.XtraBars.BarButtonItem();
            bVasyaQuestion = new DevExpress.XtraBars.BarButtonItem();
            bIvanQuestion = new DevExpress.XtraBars.BarButtonItem();
            bShowMessage = new DevExpress.XtraBars.BarButtonItem();
            bVasiliyOkMessage = new DevExpress.XtraBars.BarButtonItem();
            bIvanOkMessage = new DevExpress.XtraBars.BarButtonItem();
            bCreateFolderOnYandexDisk = new DevExpress.XtraBars.BarButtonItem();
            bSaveDatabaseInYandexDisk = new DevExpress.XtraBars.BarButtonItem();
            pageDatabase = new DevExpress.XtraBars.Ribbon.RibbonPage();
            groupDatabase = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            pageSourceData = new DevExpress.XtraBars.Ribbon.RibbonPage();
            groupFromExcelFile = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            pageDocuments = new DevExpress.XtraBars.Ribbon.RibbonPage();
            groupDocumentHandles = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            pageYandexDisk = new DevExpress.XtraBars.Ribbon.RibbonPage();
            groupYandex = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            RSB = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            DLAF = new DevExpress.LookAndFeel.DefaultLookAndFeel(components);
            bClearClients = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)RC).BeginInit();
            SuspendLayout();
            // 
            // RC
            // 
            RC.CaptionBarItemLinks.Add(bAuthorizationFormShow);
            RC.ExpandCollapseItem.Id = 0;
            RC.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bAuthorizationFormShow, RC.ExpandCollapseItem, RC.SearchEditItem, Skins, SkinPalettes, btnShowSplashScreen, btnGenerateDocuments, btnOpenFileDialog, bShowYesNoDialog, bVasyaQuestion, bIvanQuestion, bShowMessage, bVasiliyOkMessage, bIvanOkMessage, bCreateFolderOnYandexDisk, bSaveDatabaseInYandexDisk, bClearClients });
            RC.Location = new System.Drawing.Point(0, 0);
            RC.MaxItemId = 17;
            RC.Name = "RC";
            RC.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { pageDatabase, pageSourceData, pageDocuments, pageYandexDisk });
            RC.QuickToolbarItemLinks.Add(Skins);
            RC.QuickToolbarItemLinks.Add(SkinPalettes);
            RC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2007;
            RC.ShowQatLocationSelector = false;
            RC.ShowToolbarCustomizeItem = false;
            RC.Size = new System.Drawing.Size(803, 162);
            RC.StatusBar = RSB;
            RC.Toolbar.ShowCustomizeItem = false;
            RC.SelectedPageChanged += RC_SelectedPageChanged;
            // 
            // bAuthorizationFormShow
            // 
            bAuthorizationFormShow.Caption = "Авторизация";
            bAuthorizationFormShow.Id = 14;
            bAuthorizationFormShow.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bAuthorizationFormShow.ImageOptions.SvgImage");
            bAuthorizationFormShow.Name = "bAuthorizationFormShow";
            bAuthorizationFormShow.ItemClick += bAuthorizationFormShow_ItemClick;
            // 
            // Skins
            // 
            Skins.Caption = "Стили отображения графического интерфейса";
            Skins.Id = 1;
            Skins.Name = "Skins";
            // 
            // SkinPalettes
            // 
            SkinPalettes.Caption = "Палитры текущего стиля отображения";
            SkinPalettes.Id = 2;
            SkinPalettes.Name = "SkinPalettes";
            // 
            // btnShowSplashScreen
            // 
            btnShowSplashScreen.Caption = "Показать сплэш-скрин";
            btnShowSplashScreen.Id = 4;
            btnShowSplashScreen.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnShowSplashScreen.ImageOptions.SvgImage");
            btnShowSplashScreen.Name = "btnShowSplashScreen";
            // 
            // btnGenerateDocuments
            // 
            btnGenerateDocuments.Caption = "Сгенерировать документацию";
            btnGenerateDocuments.Id = 5;
            btnGenerateDocuments.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnGenerateDocuments.ImageOptions.SvgImage");
            btnGenerateDocuments.Name = "btnGenerateDocuments";
            // 
            // btnOpenFileDialog
            // 
            btnOpenFileDialog.Caption = "Открыть окно открытия файла";
            btnOpenFileDialog.Id = 6;
            btnOpenFileDialog.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnOpenFileDialog.ImageOptions.SvgImage");
            btnOpenFileDialog.Name = "btnOpenFileDialog";
            btnOpenFileDialog.ItemClick += btnOpenFileDialog_ItemClick;
            // 
            // bShowYesNoDialog
            // 
            bShowYesNoDialog.Caption = "Открыть ДА/НЕТ диалоговое окно";
            bShowYesNoDialog.Id = 7;
            bShowYesNoDialog.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bShowYesNoDialog.ImageOptions.SvgImage");
            bShowYesNoDialog.Name = "bShowYesNoDialog";
            bShowYesNoDialog.ItemClick += bShowYesNoDialog_ItemClick;
            // 
            // bVasyaQuestion
            // 
            bVasyaQuestion.Caption = "Вопрос Василия";
            bVasyaQuestion.Id = 8;
            bVasyaQuestion.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bVasyaQuestion.ImageOptions.SvgImage");
            bVasyaQuestion.Name = "bVasyaQuestion";
            bVasyaQuestion.ItemClick += bVasyaQuestion_ItemClick;
            // 
            // bIvanQuestion
            // 
            bIvanQuestion.Caption = "Вопрос Ивана";
            bIvanQuestion.Id = 9;
            bIvanQuestion.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bIvanQuestion.ImageOptions.SvgImage");
            bIvanQuestion.Name = "bIvanQuestion";
            bIvanQuestion.ItemClick += bIvanQuestion_ItemClick;
            // 
            // bShowMessage
            // 
            bShowMessage.Caption = "Покажи сообщение";
            bShowMessage.Id = 10;
            bShowMessage.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bShowMessage.ImageOptions.SvgImage");
            bShowMessage.Name = "bShowMessage";
            bShowMessage.ItemClick += bShowMessage_ItemClick;
            // 
            // bVasiliyOkMessage
            // 
            bVasiliyOkMessage.Caption = "Василий, твой месседж";
            bVasiliyOkMessage.Id = 11;
            bVasiliyOkMessage.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bVasiliyOkMessage.ImageOptions.SvgImage");
            bVasiliyOkMessage.Name = "bVasiliyOkMessage";
            bVasiliyOkMessage.ItemClick += bVasiliyOkMessage_ItemClick;
            // 
            // bIvanOkMessage
            // 
            bIvanOkMessage.Caption = "Иван, твой месседж";
            bIvanOkMessage.Id = 12;
            bIvanOkMessage.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bIvanOkMessage.ImageOptions.SvgImage");
            bIvanOkMessage.Name = "bIvanOkMessage";
            bIvanOkMessage.ItemClick += bIvanOkMessage_ItemClick;
            // 
            // bCreateFolderOnYandexDisk
            // 
            bCreateFolderOnYandexDisk.Caption = "Создать папку";
            bCreateFolderOnYandexDisk.Id = 13;
            bCreateFolderOnYandexDisk.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bCreateFolderOnYandexDisk.ImageOptions.SvgImage");
            bCreateFolderOnYandexDisk.Name = "bCreateFolderOnYandexDisk";
            bCreateFolderOnYandexDisk.ItemClick += bCreateFolderOnYandexDisk_ItemClick;
            // 
            // bSaveDatabaseInYandexDisk
            // 
            bSaveDatabaseInYandexDisk.Caption = "Сохранить БД на сервер";
            bSaveDatabaseInYandexDisk.Id = 15;
            bSaveDatabaseInYandexDisk.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bSaveDatabaseInYandexDisk.ImageOptions.SvgImage");
            bSaveDatabaseInYandexDisk.Name = "bSaveDatabaseInYandexDisk";
            bSaveDatabaseInYandexDisk.ItemClick += bSaveDatabaseInYandexDisk_ItemClick;
            // 
            // pageDatabase
            // 
            pageDatabase.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { groupDatabase });
            pageDatabase.Name = "pageDatabase";
            pageDatabase.Text = "База данных";
            // 
            // groupDatabase
            // 
            groupDatabase.ItemLinks.Add(btnShowSplashScreen);
            groupDatabase.ItemLinks.Add(btnOpenFileDialog);
            groupDatabase.ItemLinks.Add(bShowYesNoDialog);
            groupDatabase.ItemLinks.Add(bVasyaQuestion);
            groupDatabase.ItemLinks.Add(bIvanQuestion);
            groupDatabase.ItemLinks.Add(bShowMessage);
            groupDatabase.ItemLinks.Add(bVasiliyOkMessage);
            groupDatabase.ItemLinks.Add(bIvanOkMessage);
            groupDatabase.ItemLinks.Add(bSaveDatabaseInYandexDisk);
            groupDatabase.ItemLinks.Add(bClearClients);
            groupDatabase.Name = "groupDatabase";
            groupDatabase.Text = "База данных";
            // 
            // pageSourceData
            // 
            pageSourceData.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { groupFromExcelFile });
            pageSourceData.Name = "pageSourceData";
            pageSourceData.Text = "Исходные данные";
            // 
            // groupFromExcelFile
            // 
            groupFromExcelFile.Name = "groupFromExcelFile";
            groupFromExcelFile.Text = "Источник Excel";
            // 
            // pageDocuments
            // 
            pageDocuments.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { groupDocumentHandles });
            pageDocuments.Name = "pageDocuments";
            pageDocuments.Text = "Документы";
            // 
            // groupDocumentHandles
            // 
            groupDocumentHandles.ItemLinks.Add(btnGenerateDocuments);
            groupDocumentHandles.Name = "groupDocumentHandles";
            groupDocumentHandles.Text = "Обработка";
            // 
            // pageYandexDisk
            // 
            pageYandexDisk.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { groupYandex });
            pageYandexDisk.Name = "pageYandexDisk";
            pageYandexDisk.Text = "Яндекс.Диск";
            // 
            // groupYandex
            // 
            groupYandex.ItemLinks.Add(bCreateFolderOnYandexDisk);
            groupYandex.Name = "groupYandex";
            groupYandex.Text = "Яндекс";
            // 
            // RSB
            // 
            RSB.Location = new System.Drawing.Point(0, 448);
            RSB.Name = "RSB";
            RSB.Ribbon = RC;
            RSB.Size = new System.Drawing.Size(803, 24);
            // 
            // DLAF
            // 
            DLAF.LookAndFeel.SkinName = "The Bezier";
            // 
            // bClearClients
            // 
            bClearClients.Caption = "Очистить клиентов";
            bClearClients.Id = 16;
            bClearClients.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bClearClients.ImageOptions.SvgImage");
            bClearClients.Name = "bClearClients";
            bClearClients.ItemClick += bClearClients_ItemClick;
            // 
            // MainForm
            // 
            AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(803, 472);
            Controls.Add(RSB);
            Controls.Add(RC);
            Name = "MainForm";
            Ribbon = RC;
            StatusBar = RSB;
            ((System.ComponentModel.ISupportInitialize)RC).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}