namespace RehabilityApplication.CoreLib
{
    partial class ucDocumentViewer
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
            richEditControl1 = new DevExpress.XtraRichEdit.RichEditControl();
            SuspendLayout();
            // 
            // richEditControl1
            // 
            richEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            richEditControl1.Location = new System.Drawing.Point(0, 0);
            richEditControl1.Name = "richEditControl1";
            richEditControl1.Size = new System.Drawing.Size(408, 339);
            richEditControl1.TabIndex = 0;
            richEditControl1.Text = "Приветствую тебя пользователь!";
            // 
            // ucDocumentViewer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(richEditControl1);
            Name = "ucDocumentViewer";
            Size = new System.Drawing.Size(408, 339);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraRichEdit.RichEditControl richEditControl1;
    }
}
