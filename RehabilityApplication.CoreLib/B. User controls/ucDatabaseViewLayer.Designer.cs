namespace RehabilityApplication.CoreLib
{
    partial class ucDatabaseViewLayer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            var dockingContainer1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer();
            this.documentGroup1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup(this.components);
            this.document3 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.document2 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.document4 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.document5 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.DockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dpClients = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dpPassports = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dpProductsInClient = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dpCalls = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer2 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.DocumentManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.document1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            ((System.ComponentModel.ISupportInitialize)this.documentGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.document3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.document2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.document4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.document5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.DockManager).BeginInit();
            this.dpClients.SuspendLayout();
            this.dpPassports.SuspendLayout();
            this.dpProductsInClient.SuspendLayout();
            this.dpCalls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.DocumentManager).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.tabbedView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.document1).BeginInit();
            this.SuspendLayout();
            // 
            // documentGroup1
            // 
            this.documentGroup1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document[] { this.document3, this.document2, this.document4, this.document5 });
            // 
            // document3
            // 
            this.document3.Caption = "Получатели";
            this.document3.ControlName = "dpClients";
            this.document3.FloatLocation = new System.Drawing.Point(0, 0);
            this.document3.FloatSize = new System.Drawing.Size(200, 200);
            this.document3.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            this.document3.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document3.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // document2
            // 
            this.document2.Caption = "Документы, удостоверяющие личность";
            this.document2.ControlName = "dpPassports";
            this.document2.FloatLocation = new System.Drawing.Point(0, 0);
            this.document2.FloatSize = new System.Drawing.Size(400, 200);
            this.document2.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            this.document2.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document2.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // document4
            // 
            this.document4.Caption = "Товары получателя";
            this.document4.ControlName = "dpProductsInClient";
            this.document4.FloatLocation = new System.Drawing.Point(0, 0);
            this.document4.FloatSize = new System.Drawing.Size(200, 200);
            this.document4.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            this.document4.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document4.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // document5
            // 
            this.document5.Caption = "Звонки";
            this.document5.ControlName = "dpCalls";
            this.document5.FloatLocation = new System.Drawing.Point(0, 0);
            this.document5.FloatSize = new System.Drawing.Size(200, 200);
            this.document5.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            this.document5.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document5.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // DockManager
            // 
            this.DockManager.Form = this;
            this.DockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] { this.dpClients, this.dpPassports, this.dpProductsInClient, this.dpCalls });
            this.DockManager.TopZIndexControls.AddRange(new string[] { "DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl", "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl" });
            // 
            // dpClients
            // 
            this.dpClients.Controls.Add(this.dockPanel2_Container);
            this.dpClients.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dpClients.DockedAsTabbedDocument = true;
            this.dpClients.ID = new System.Guid("df3c0cf0-013e-4f66-85f6-b71fd63f842a");
            this.dpClients.Location = new System.Drawing.Point(0, 0);
            this.dpClients.Name = "dpClients";
            this.dpClients.OriginalSize = new System.Drawing.Size(200, 200);
            this.dpClients.Size = new System.Drawing.Size(1103, 400);
            this.dpClients.Text = "Получатели";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(1103, 400);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // dpPassports
            // 
            this.dpPassports.Controls.Add(this.controlContainer1);
            this.dpPassports.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dpPassports.DockedAsTabbedDocument = true;
            this.dpPassports.FloatSize = new System.Drawing.Size(400, 200);
            this.dpPassports.ID = new System.Guid("d8ed14b4-5f40-48bf-a428-67103b674020");
            this.dpPassports.Location = new System.Drawing.Point(0, 0);
            this.dpPassports.Name = "dpPassports";
            this.dpPassports.OriginalSize = new System.Drawing.Size(400, 200);
            this.dpPassports.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dpPassports.SavedIndex = 2;
            this.dpPassports.Size = new System.Drawing.Size(1103, 400);
            this.dpPassports.Text = "Документы, удостоверяющие личность";
            // 
            // controlContainer1
            // 
            this.controlContainer1.Location = new System.Drawing.Point(0, 0);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(1103, 400);
            this.controlContainer1.TabIndex = 0;
            // 
            // dpProductsInClient
            // 
            this.dpProductsInClient.Controls.Add(this.dockPanel1_Container);
            this.dpProductsInClient.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dpProductsInClient.DockedAsTabbedDocument = true;
            this.dpProductsInClient.ID = new System.Guid("542c049f-113a-44db-9431-f173e82d64d9");
            this.dpProductsInClient.Location = new System.Drawing.Point(0, 0);
            this.dpProductsInClient.Name = "dpProductsInClient";
            this.dpProductsInClient.OriginalSize = new System.Drawing.Size(200, 200);
            this.dpProductsInClient.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dpProductsInClient.SavedIndex = 1;
            this.dpProductsInClient.Size = new System.Drawing.Size(1103, 400);
            this.dpProductsInClient.Text = "Товары получателя";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(1103, 400);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // dpCalls
            // 
            this.dpCalls.Controls.Add(this.controlContainer2);
            this.dpCalls.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dpCalls.DockedAsTabbedDocument = true;
            this.dpCalls.ID = new System.Guid("76b07916-bda0-418e-a540-8d02a8290041");
            this.dpCalls.Location = new System.Drawing.Point(0, 0);
            this.dpCalls.Name = "dpCalls";
            this.dpCalls.OriginalSize = new System.Drawing.Size(200, 200);
            this.dpCalls.Size = new System.Drawing.Size(1103, 396);
            this.dpCalls.Text = "Звонки";
            // 
            // controlContainer2
            // 
            this.controlContainer2.Location = new System.Drawing.Point(0, 0);
            this.controlContainer2.Name = "controlContainer2";
            this.controlContainer2.Size = new System.Drawing.Size(1103, 396);
            this.controlContainer2.TabIndex = 0;
            // 
            // DocumentManager
            // 
            this.DocumentManager.ContainerControl = this;
            this.DocumentManager.View = this.tabbedView1;
            this.DocumentManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] { this.tabbedView1 });
            // 
            // tabbedView1
            // 
            this.tabbedView1.DocumentGroups.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup[] { this.documentGroup1 });
            this.tabbedView1.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] { this.document3, this.document2, this.document4, this.document5 });
            dockingContainer1.Element = this.documentGroup1;
            this.tabbedView1.RootContainer.Nodes.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer[] { dockingContainer1 });
            // 
            // document1
            // 
            this.document1.Caption = "dockPanel2";
            this.document1.ControlName = "dockPanel2";
            this.document1.FloatLocation = new System.Drawing.Point(478, 111);
            this.document1.FloatSize = new System.Drawing.Size(200, 200);
            this.document1.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            this.document1.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document1.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // ucDatabaseViewLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucDatabaseViewLayer";
            this.Size = new System.Drawing.Size(1109, 429);
            ((System.ComponentModel.ISupportInitialize)this.documentGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.document3).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.document2).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.document4).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.document5).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.DockManager).EndInit();
            this.dpClients.ResumeLayout(false);
            this.dpPassports.ResumeLayout(false);
            this.dpProductsInClient.ResumeLayout(false);
            this.dpCalls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.DocumentManager).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.tabbedView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.document1).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager DockManager;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking2010.DocumentManager DocumentManager;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document1;
        private DevExpress.XtraBars.Docking.DockPanel dpPassports;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraBars.Docking.DockPanel dpClients;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup documentGroup1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document3;
        private DevExpress.XtraBars.Docking.DockPanel dpProductsInClient;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document2;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document4;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document5;
        private DevExpress.XtraBars.Docking.DockPanel dpCalls;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer2;
    }
}
