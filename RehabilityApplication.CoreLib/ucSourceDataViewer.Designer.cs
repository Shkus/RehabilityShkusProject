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
            spreadsheetControl1 = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            SuspendLayout();
            // 
            // spreadsheetControl1
            // 
            spreadsheetControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            spreadsheetControl1.Location = new System.Drawing.Point(0, 0);
            spreadsheetControl1.Name = "spreadsheetControl1";
            spreadsheetControl1.Size = new System.Drawing.Size(467, 350);
            spreadsheetControl1.TabIndex = 0;
            spreadsheetControl1.Text = "spreadsheetControl1";
            // 
            // ucSourceDataViewer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(spreadsheetControl1);
            Name = "ucSourceDataViewer";
            Size = new System.Drawing.Size(467, 350);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraSpreadsheet.SpreadsheetControl spreadsheetControl1;
    }
}
