namespace RehabilityApplication.CoreLib
{
    partial class ucSQLiteViewer
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
            this.TL = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)this.TL).BeginInit();
            this.SuspendLayout();
            // 
            // TL
            // 
            this.TL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TL.Location = new System.Drawing.Point(0, 0);
            this.TL.Name = "TL";
            this.TL.Size = new System.Drawing.Size(477, 386);
            this.TL.TabIndex = 0;
            // 
            // ucSQLiteViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TL);
            this.Name = "ucSQLiteViewer";
            this.Size = new System.Drawing.Size(477, 386);
            ((System.ComponentModel.ISupportInitialize)this.TL).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraTreeList.TreeList TL;
    }
}
