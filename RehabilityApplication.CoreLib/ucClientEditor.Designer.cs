namespace RehabilityApplication.CoreLib
{
    partial class ucClientEditor
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
            bOk = new DevExpress.XtraEditors.SimpleButton();
            bCancel = new DevExpress.XtraEditors.SimpleButton();
            capSnils = new DevExpress.XtraEditors.LabelControl();
            teSnils = new DevExpress.XtraEditors.TextEdit();
            teFIO = new DevExpress.XtraEditors.TextEdit();
            capFIO = new DevExpress.XtraEditors.LabelControl();
            tsSelected = new DevExpress.XtraEditors.LabelControl();
            tsIsSelected = new DevExpress.XtraEditors.ToggleSwitch();
            Panel = new DevExpress.XtraEditors.XtraScrollableControl();
            ((System.ComponentModel.ISupportInitialize)teSnils.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)teFIO.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tsIsSelected.Properties).BeginInit();
            SuspendLayout();
            // 
            // bOk
            // 
            bOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            bOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            bOk.Location = new System.Drawing.Point(22, 179);
            bOk.Name = "bOk";
            bOk.Size = new System.Drawing.Size(115, 31);
            bOk.TabIndex = 0;
            bOk.Text = "Принять";
            bOk.Click += bOk_Click;
            // 
            // bCancel
            // 
            bCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            bCancel.Location = new System.Drawing.Point(421, 179);
            bCancel.Name = "bCancel";
            bCancel.Size = new System.Drawing.Size(115, 31);
            bCancel.TabIndex = 1;
            bCancel.Text = "Отмена";
            // 
            // capSnils
            // 
            capSnils.Location = new System.Drawing.Point(22, 16);
            capSnils.Name = "capSnils";
            capSnils.Size = new System.Drawing.Size(39, 13);
            capSnils.TabIndex = 2;
            capSnils.Text = "СНИЛС:";
            capSnils.Visible = false;
            // 
            // teSnils
            // 
            teSnils.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            teSnils.Location = new System.Drawing.Point(153, 13);
            teSnils.Name = "teSnils";
            teSnils.Size = new System.Drawing.Size(383, 20);
            teSnils.TabIndex = 3;
            teSnils.Visible = false;
            // 
            // teFIO
            // 
            teFIO.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            teFIO.Location = new System.Drawing.Point(153, 54);
            teFIO.Name = "teFIO";
            teFIO.Size = new System.Drawing.Size(383, 20);
            teFIO.TabIndex = 5;
            teFIO.Visible = false;
            // 
            // capFIO
            // 
            capFIO.Location = new System.Drawing.Point(22, 57);
            capFIO.Name = "capFIO";
            capFIO.Size = new System.Drawing.Size(39, 13);
            capFIO.TabIndex = 4;
            capFIO.Text = "Ф.И.О.:";
            capFIO.Visible = false;
            // 
            // tsSelected
            // 
            tsSelected.Location = new System.Drawing.Point(22, 95);
            tsSelected.Name = "tsSelected";
            tsSelected.Size = new System.Drawing.Size(91, 13);
            tsSelected.TabIndex = 6;
            tsSelected.Text = "Выделен или нет:";
            tsSelected.Visible = false;
            // 
            // tsIsSelected
            // 
            tsIsSelected.Location = new System.Drawing.Point(155, 90);
            tsIsSelected.Name = "tsIsSelected";
            tsIsSelected.Properties.OffText = "   Не выделен";
            tsIsSelected.Properties.OnText = "   Выделен";
            tsIsSelected.Size = new System.Drawing.Size(222, 20);
            tsIsSelected.TabIndex = 7;
            tsIsSelected.Visible = false;
            // 
            // Panel
            // 
            Panel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            Panel.Location = new System.Drawing.Point(3, 9);
            Panel.Name = "Panel";
            Panel.Size = new System.Drawing.Size(549, 164);
            Panel.TabIndex = 8;
            // 
            // ucClientEditor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tsIsSelected);
            Controls.Add(tsSelected);
            Controls.Add(teFIO);
            Controls.Add(capFIO);
            Controls.Add(teSnils);
            Controls.Add(capSnils);
            Controls.Add(bCancel);
            Controls.Add(bOk);
            Controls.Add(Panel);
            Name = "ucClientEditor";
            Size = new System.Drawing.Size(565, 236);
            ((System.ComponentModel.ISupportInitialize)teSnils.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)teFIO.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tsIsSelected.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton bOk;
        private DevExpress.XtraEditors.SimpleButton bCancel;
        private DevExpress.XtraEditors.LabelControl capSnils;
        private DevExpress.XtraEditors.TextEdit teSnils;
        private DevExpress.XtraEditors.TextEdit teFIO;
        private DevExpress.XtraEditors.LabelControl capFIO;
        private DevExpress.XtraEditors.LabelControl tsSelected;
        private DevExpress.XtraEditors.ToggleSwitch tsIsSelected;
        private DevExpress.XtraEditors.XtraScrollableControl Panel;
    }
}
