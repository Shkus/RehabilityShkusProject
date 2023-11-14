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
            components = new System.ComponentModel.Container();
            DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer dockingContainer1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer();
            documentGroup1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup(components);
            document3 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(components);
            document2 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(components);
            document4 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(components);
            document5 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(components);
            DockManager = new DevExpress.XtraBars.Docking.DockManager(components);
            dpClients = new DevExpress.XtraBars.Docking.DockPanel();
            dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            dpPassports = new DevExpress.XtraBars.Docking.DockPanel();
            controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            dpProductsInClient = new DevExpress.XtraBars.Docking.DockPanel();
            dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            dpCalls = new DevExpress.XtraBars.Docking.DockPanel();
            controlContainer2 = new DevExpress.XtraBars.Docking.ControlContainer();
            DocumentManager = new DevExpress.XtraBars.Docking2010.DocumentManager(components);
            tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(components);
            document1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(components);
            ((System.ComponentModel.ISupportInitialize)documentGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)document3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)document2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)document4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)document5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DockManager).BeginInit();
            dpClients.SuspendLayout();
            dpPassports.SuspendLayout();
            dpProductsInClient.SuspendLayout();
            dpCalls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DocumentManager).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabbedView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)document1).BeginInit();
            SuspendLayout();
            // 
            // documentGroup1
            // 
            documentGroup1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document[] { document3, document2, document4, document5 });
            // 
            // document3
            // 
            document3.Caption = "Получатели";
            document3.ControlName = "dpClients";
            document3.FloatLocation = new System.Drawing.Point(0, 0);
            document3.FloatSize = new System.Drawing.Size(200, 200);
            document3.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            document3.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            document3.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // document2
            // 
            document2.Caption = "Документы, удостоверяющие личность";
            document2.ControlName = "dpPassports";
            document2.FloatLocation = new System.Drawing.Point(0, 0);
            document2.FloatSize = new System.Drawing.Size(400, 200);
            document2.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            document2.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            document2.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // document4
            // 
            document4.Caption = "Товары получателя";
            document4.ControlName = "dpProductsInClient";
            document4.FloatLocation = new System.Drawing.Point(0, 0);
            document4.FloatSize = new System.Drawing.Size(200, 200);
            document4.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            document4.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            document4.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // document5
            // 
            document5.Caption = "Звонки";
            document5.ControlName = "dpCalls";
            document5.FloatLocation = new System.Drawing.Point(0, 0);
            document5.FloatSize = new System.Drawing.Size(200, 200);
            document5.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            document5.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            document5.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // DockManager
            // 
            DockManager.Form = this;
            DockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] { dpClients, dpPassports, dpProductsInClient, dpCalls });
            DockManager.TopZIndexControls.AddRange(new string[] { "DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl", "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl" });
            // 
            // dpClients
            // 
            dpClients.Controls.Add(dockPanel2_Container);
            dpClients.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            dpClients.DockedAsTabbedDocument = true;
            dpClients.ID = new System.Guid("df3c0cf0-013e-4f66-85f6-b71fd63f842a");
            dpClients.Location = new System.Drawing.Point(0, 0);
            dpClients.Name = "dpClients";
            dpClients.OriginalSize = new System.Drawing.Size(200, 200);
            dpClients.Size = new System.Drawing.Size(1103, 400);
            dpClients.Text = "Получатели";
            // 
            // dockPanel2_Container
            // 
            dockPanel2_Container.Location = new System.Drawing.Point(0, 0);
            dockPanel2_Container.Name = "dockPanel2_Container";
            dockPanel2_Container.Size = new System.Drawing.Size(1103, 400);
            dockPanel2_Container.TabIndex = 0;
            // 
            // dpPassports
            // 
            dpPassports.Controls.Add(controlContainer1);
            dpPassports.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            dpPassports.DockedAsTabbedDocument = true;
            dpPassports.FloatSize = new System.Drawing.Size(400, 200);
            dpPassports.ID = new System.Guid("d8ed14b4-5f40-48bf-a428-67103b674020");
            dpPassports.Location = new System.Drawing.Point(0, 0);
            dpPassports.Name = "dpPassports";
            dpPassports.OriginalSize = new System.Drawing.Size(400, 200);
            dpPassports.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            dpPassports.SavedIndex = 2;
            dpPassports.Size = new System.Drawing.Size(1103, 400);
            dpPassports.Text = "Документы, удостоверяющие личность";
            // 
            // controlContainer1
            // 
            controlContainer1.Location = new System.Drawing.Point(0, 0);
            controlContainer1.Name = "controlContainer1";
            controlContainer1.Size = new System.Drawing.Size(1103, 400);
            controlContainer1.TabIndex = 0;
            // 
            // dpProductsInClient
            // 
            dpProductsInClient.Controls.Add(dockPanel1_Container);
            dpProductsInClient.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            dpProductsInClient.DockedAsTabbedDocument = true;
            dpProductsInClient.ID = new System.Guid("542c049f-113a-44db-9431-f173e82d64d9");
            dpProductsInClient.Location = new System.Drawing.Point(0, 0);
            dpProductsInClient.Name = "dpProductsInClient";
            dpProductsInClient.OriginalSize = new System.Drawing.Size(200, 200);
            dpProductsInClient.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            dpProductsInClient.SavedIndex = 1;
            dpProductsInClient.Size = new System.Drawing.Size(1103, 400);
            dpProductsInClient.Text = "Товары получателя";
            // 
            // dockPanel1_Container
            // 
            dockPanel1_Container.Location = new System.Drawing.Point(0, 0);
            dockPanel1_Container.Name = "dockPanel1_Container";
            dockPanel1_Container.Size = new System.Drawing.Size(1103, 400);
            dockPanel1_Container.TabIndex = 0;
            // 
            // dpCalls
            // 
            dpCalls.Controls.Add(controlContainer2);
            dpCalls.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            dpCalls.DockedAsTabbedDocument = true;
            dpCalls.ID = new System.Guid("76b07916-bda0-418e-a540-8d02a8290041");
            dpCalls.Location = new System.Drawing.Point(0, 0);
            dpCalls.Name = "dpCalls";
            dpCalls.OriginalSize = new System.Drawing.Size(200, 200);
            dpCalls.Size = new System.Drawing.Size(789, 293);
            dpCalls.Text = "Звонки";
            // 
            // controlContainer2
            // 
            controlContainer2.Location = new System.Drawing.Point(0, 0);
            controlContainer2.Name = "controlContainer2";
            controlContainer2.Size = new System.Drawing.Size(789, 293);
            controlContainer2.TabIndex = 0;
            // 
            // DocumentManager
            // 
            DocumentManager.ContainerControl = this;
            DocumentManager.View = tabbedView1;
            DocumentManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] { tabbedView1 });
            // 
            // tabbedView1
            // 
            tabbedView1.DocumentGroups.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup[] { documentGroup1 });
            tabbedView1.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] { document3, document2, document4, document5 });
            dockingContainer1.Element = documentGroup1;
            tabbedView1.RootContainer.Nodes.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer[] { dockingContainer1 });
            // 
            // document1
            // 
            document1.Caption = "dockPanel2";
            document1.ControlName = "dockPanel2";
            document1.FloatLocation = new System.Drawing.Point(478, 111);
            document1.FloatSize = new System.Drawing.Size(200, 200);
            document1.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            document1.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            document1.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // ucDatabaseViewLayer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Name = "ucDatabaseViewLayer";
            Size = new System.Drawing.Size(795, 322);
            ((System.ComponentModel.ISupportInitialize)documentGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)document3).EndInit();
            ((System.ComponentModel.ISupportInitialize)document2).EndInit();
            ((System.ComponentModel.ISupportInitialize)document4).EndInit();
            ((System.ComponentModel.ISupportInitialize)document5).EndInit();
            ((System.ComponentModel.ISupportInitialize)DockManager).EndInit();
            dpClients.ResumeLayout(false);
            dpPassports.ResumeLayout(false);
            dpProductsInClient.ResumeLayout(false);
            dpCalls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DocumentManager).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabbedView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)document1).EndInit();
            ResumeLayout(false);
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
