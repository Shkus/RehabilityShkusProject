namespace RehabilityApplication.CoreLib
{
    partial class ucSourceDataViewer
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
            Table = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            TL = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)TL).BeginInit();
            SuspendLayout();
            // 
            // Table
            // 
            Table.Dock = System.Windows.Forms.DockStyle.Fill;
            Table.Location = new System.Drawing.Point(0, 0);
            Table.Name = "Table";
            Table.Size = new System.Drawing.Size(467, 350);
            Table.TabIndex = 0;
            Table.Text = "Text";
            // 
            // TL
            // 
            TL.Dock = System.Windows.Forms.DockStyle.Fill;
            TL.Location = new System.Drawing.Point(0, 0);
            TL.Name = "TL";
            TL.Size = new System.Drawing.Size(467, 350);
            TL.TabIndex = 1;
            // 
            // ucSourceDataViewer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(Table);
            Controls.Add(TL);
            Name = "ucSourceDataViewer";
            Size = new System.Drawing.Size(467, 350);
            ((System.ComponentModel.ISupportInitialize)TL).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraSpreadsheet.SpreadsheetControl Table;
        private DevExpress.XtraTreeList.TreeList TL;
    }
}
