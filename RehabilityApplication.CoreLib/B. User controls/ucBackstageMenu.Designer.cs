namespace RehabilityApplication.CoreLib
{
    partial class ucBackstageMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBackstageMenu));
            BSV = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            backstageViewClientControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            backstageViewClientControl2 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            backstageViewClientControl3 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            tabSettings = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            tabNotifies = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            tabHelp = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            backstageViewItemSeparator1 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            btnExitApplication = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            ((System.ComponentModel.ISupportInitialize)BSV).BeginInit();
            BSV.SuspendLayout();
            SuspendLayout();
            // 
            // BSV
            // 
            BSV.Controls.Add(backstageViewClientControl1);
            BSV.Controls.Add(backstageViewClientControl2);
            BSV.Controls.Add(backstageViewClientControl3);
            BSV.Dock = System.Windows.Forms.DockStyle.Fill;
            BSV.Items.Add(tabSettings);
            BSV.Items.Add(tabNotifies);
            BSV.Items.Add(tabHelp);
            BSV.Items.Add(backstageViewItemSeparator1);
            BSV.Items.Add(btnExitApplication);
            BSV.Location = new System.Drawing.Point(0, 0);
            BSV.Name = "BSV";
            BSV.SelectedTab = tabHelp;
            BSV.SelectedTabIndex = 2;
            BSV.Size = new System.Drawing.Size(607, 423);
            BSV.TabIndex = 0;
            BSV.Text = "backstageViewControl1";
            BSV.VisibleInDesignTime = true;
            // 
            // backstageViewClientControl1
            // 
            backstageViewClientControl1.Location = new System.Drawing.Point(256, 0);
            backstageViewClientControl1.Name = "backstageViewClientControl1";
            backstageViewClientControl1.Size = new System.Drawing.Size(178, 423);
            backstageViewClientControl1.TabIndex = 1;
            // 
            // backstageViewClientControl2
            // 
            backstageViewClientControl2.Location = new System.Drawing.Point(256, 0);
            backstageViewClientControl2.Name = "backstageViewClientControl2";
            backstageViewClientControl2.Size = new System.Drawing.Size(178, 423);
            backstageViewClientControl2.TabIndex = 2;
            // 
            // backstageViewClientControl3
            // 
            backstageViewClientControl3.Location = new System.Drawing.Point(256, 0);
            backstageViewClientControl3.Name = "backstageViewClientControl3";
            backstageViewClientControl3.Size = new System.Drawing.Size(351, 423);
            backstageViewClientControl3.TabIndex = 3;
            // 
            // tabSettings
            // 
            tabSettings.Caption = "Настройки приложения";
            tabSettings.ContentControl = backstageViewClientControl1;
            tabSettings.ImageOptions.ItemNormal.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("tabSettings.ImageOptions.ItemNormal.SvgImage");
            tabSettings.Name = "tabSettings";
            // 
            // tabNotifies
            // 
            tabNotifies.Caption = "Журнал уведомлений";
            tabNotifies.ContentControl = backstageViewClientControl2;
            tabNotifies.ImageOptions.ItemNormal.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("tabNotifies.ImageOptions.ItemNormal.SvgImage");
            tabNotifies.Name = "tabNotifies";
            // 
            // tabHelp
            // 
            tabHelp.Caption = "Справка";
            tabHelp.ContentControl = backstageViewClientControl3;
            tabHelp.ImageOptions.ItemNormal.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("tabHelp.ImageOptions.ItemNormal.SvgImage");
            tabHelp.Name = "tabHelp";
            tabHelp.Selected = true;
            // 
            // backstageViewItemSeparator1
            // 
            backstageViewItemSeparator1.Name = "backstageViewItemSeparator1";
            // 
            // btnExitApplication
            // 
            btnExitApplication.Caption = "Выход из приложения";
            btnExitApplication.ImageOptions.ItemNormal.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnExitApplication.ImageOptions.ItemNormal.SvgImage");
            btnExitApplication.Name = "btnExitApplication";
            // 
            // ucBackstageMenu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(BSV);
            Name = "ucBackstageMenu";
            Size = new System.Drawing.Size(607, 423);
            ((System.ComponentModel.ISupportInitialize)BSV).EndInit();
            BSV.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.BackstageViewControl BSV;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem tabSettings;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl2;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem tabNotifies;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl3;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem tabHelp;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator1;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem btnExitApplication;
    }
}
