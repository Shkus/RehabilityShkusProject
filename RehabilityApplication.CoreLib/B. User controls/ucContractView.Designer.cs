namespace RehabilityApplication.CoreLib
{
    partial class ucContractView
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
            this.TL.KeyFieldName = "Id";
            this.TL.Location = new System.Drawing.Point(0, 0);
            this.TL.Name = "TL";
            this.TL.OptionsView.ShowHorzLines = false;
            this.TL.OptionsView.ShowIndicator = false;
            this.TL.OptionsView.ShowVertLines = false;
            this.TL.ParentFieldName = "ParentId";
            this.TL.Size = new System.Drawing.Size(520, 425);
            this.TL.TabIndex = 0;
            // 
            // ucContractView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TL);
            this.Name = "ucContractView";
            this.Size = new System.Drawing.Size(520, 425);
            ((System.ComponentModel.ISupportInitialize)this.TL).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraTreeList.TreeList TL;
    }
}
