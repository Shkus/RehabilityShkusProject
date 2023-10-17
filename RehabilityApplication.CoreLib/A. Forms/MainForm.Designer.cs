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
            RC = new DevExpress.XtraBars.Ribbon.RibbonControl();
            Skins = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            SkinPalettes = new DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem();
            pageDatabase = new DevExpress.XtraBars.Ribbon.RibbonPage();
            groupDatabase = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            pageSourceData = new DevExpress.XtraBars.Ribbon.RibbonPage();
            groupFromExcelFile = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            pageDocuments = new DevExpress.XtraBars.Ribbon.RibbonPage();
            groupDocumentHandles = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            RSB = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            DLAF = new DevExpress.LookAndFeel.DefaultLookAndFeel(components);
            ((System.ComponentModel.ISupportInitialize)RC).BeginInit();
            SuspendLayout();
            // 
            // RC
            // 
            RC.ExpandCollapseItem.Id = 0;
            RC.Items.AddRange(new DevExpress.XtraBars.BarItem[] { RC.ExpandCollapseItem, RC.SearchEditItem, Skins, SkinPalettes });
            RC.Location = new System.Drawing.Point(0, 0);
            RC.MaxItemId = 3;
            RC.Name = "RC";
            RC.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { pageDatabase, pageSourceData, pageDocuments });
            RC.QuickToolbarItemLinks.Add(Skins);
            RC.QuickToolbarItemLinks.Add(SkinPalettes);
            RC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2007;
            RC.ShowQatLocationSelector = false;
            RC.ShowToolbarCustomizeItem = false;
            RC.Size = new System.Drawing.Size(1090, 162);
            RC.StatusBar = RSB;
            RC.Toolbar.ShowCustomizeItem = false;
            RC.SelectedPageChanged += RC_SelectedPageChanged;
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
            // pageDatabase
            // 
            pageDatabase.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { groupDatabase });
            pageDatabase.Name = "pageDatabase";
            pageDatabase.Text = "База данных";
            // 
            // groupDatabase
            // 
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
            groupDocumentHandles.Name = "groupDocumentHandles";
            groupDocumentHandles.Text = "Обработка";
            // 
            // RSB
            // 
            RSB.Location = new System.Drawing.Point(0, 464);
            RSB.Name = "RSB";
            RSB.Ribbon = RC;
            RSB.Size = new System.Drawing.Size(1090, 26);
            // 
            // DLAF
            // 
            DLAF.LookAndFeel.SkinName = "The Bezier";
            // 
            // MainForm
            // 
            AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1090, 490);
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
    }
}