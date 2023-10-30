namespace RehabilityApplication.CoreLib
{
    partial class ucStructureViewer
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
            TL = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)TL).BeginInit();
            SuspendLayout();
            // 
            // TL
            // 
            TL.Dock = System.Windows.Forms.DockStyle.Fill;
            TL.KeyFieldName = "Id";
            TL.Location = new System.Drawing.Point(0, 0);
            TL.Name = "TL";
            TL.ParentFieldName = "ParentId";
            TL.Size = new System.Drawing.Size(497, 388);
            TL.TabIndex = 0;
            // 
            // ucStructureViewer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(TL);
            Name = "ucStructureViewer";
            Size = new System.Drawing.Size(497, 388);
            ((System.ComponentModel.ISupportInitialize)TL).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraTreeList.TreeList TL;
    }
}
