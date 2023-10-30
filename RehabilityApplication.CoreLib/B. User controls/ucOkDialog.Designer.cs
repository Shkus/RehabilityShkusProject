namespace RehabilityApplication.CoreLib
{
    partial class ucOkDialog
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
            bOk = new DevExpress.XtraEditors.SimpleButton();
            labMessage = new DevExpress.XtraEditors.LabelControl();
            SuspendLayout();
            // 
            // bOk
            // 
            bOk.Location = new System.Drawing.Point(200, 263);
            bOk.Name = "bOk";
            bOk.Size = new System.Drawing.Size(125, 40);
            bOk.TabIndex = 0;
            bOk.Text = "ПОНЯЛ";
            // 
            // labMessage
            // 
            labMessage.Appearance.Options.UseTextOptions = true;
            labMessage.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            labMessage.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            labMessage.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            labMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labMessage.Location = new System.Drawing.Point(32, 22);
            labMessage.Name = "labMessage";
            labMessage.Size = new System.Drawing.Size(439, 215);
            labMessage.TabIndex = 3;
            labMessage.Text = "УТВЕРЖДЕНИЕ";
            // 
            // ucOkDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(labMessage);
            Controls.Add(bOk);
            Name = "ucOkDialog";
            Size = new System.Drawing.Size(498, 319);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton bOk;
        private DevExpress.XtraEditors.LabelControl labMessage;
    }
}
