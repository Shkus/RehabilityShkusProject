namespace RehabilityApplication.CoreLib
{
    partial class ucYesNoDialog
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
            bCancel = new DevExpress.XtraEditors.SimpleButton();
            labQuestion = new DevExpress.XtraEditors.LabelControl();
            SuspendLayout();
            // 
            // bOk
            // 
            bOk.Location = new System.Drawing.Point(3, 184);
            bOk.Name = "bOk";
            bOk.Size = new System.Drawing.Size(107, 27);
            bOk.TabIndex = 0;
            bOk.Text = "Да";
            // 
            // bCancel
            // 
            bCancel.Location = new System.Drawing.Point(356, 184);
            bCancel.Name = "bCancel";
            bCancel.Size = new System.Drawing.Size(107, 27);
            bCancel.TabIndex = 1;
            bCancel.Text = "Нет";
            // 
            // labQuestion
            // 
            labQuestion.Appearance.Options.UseTextOptions = true;
            labQuestion.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            labQuestion.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            labQuestion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labQuestion.Location = new System.Drawing.Point(14, 10);
            labQuestion.Name = "labQuestion";
            labQuestion.Size = new System.Drawing.Size(439, 168);
            labQuestion.TabIndex = 2;
            labQuestion.Text = "ВОПРОС?";
            // 
            // ucYesNoDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(labQuestion);
            Controls.Add(bCancel);
            Controls.Add(bOk);
            Name = "ucYesNoDialog";
            Size = new System.Drawing.Size(466, 214);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton bOk;
        private DevExpress.XtraEditors.SimpleButton bCancel;
        private DevExpress.XtraEditors.LabelControl labQuestion;
    }
}
