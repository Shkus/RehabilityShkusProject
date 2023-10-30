namespace RehabilityApplication.CoreLib
{
    partial class ucAuthorizationForm
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAuthorizationForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            bCheck = new DevExpress.XtraEditors.SimpleButton();
            txtLogin = new DevExpress.XtraEditors.TextEdit();
            txtPassword = new DevExpress.XtraEditors.ButtonEdit();
            capPassword = new DevExpress.XtraEditors.LabelControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)txtLogin.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).BeginInit();
            SuspendLayout();
            // 
            // bCheck
            // 
            bCheck.Location = new System.Drawing.Point(142, 158);
            bCheck.Name = "bCheck";
            bCheck.Size = new System.Drawing.Size(140, 31);
            bCheck.TabIndex = 0;
            bCheck.Text = "Проверка";
            bCheck.Click += simpleButton1_Click;
            // 
            // txtLogin
            // 
            txtLogin.Location = new System.Drawing.Point(145, 49);
            txtLogin.Name = "txtLogin";
            txtLogin.Properties.NullText = "Введите логин";
            txtLogin.Size = new System.Drawing.Size(211, 20);
            txtLogin.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.EditValue = "";
            txtPassword.Location = new System.Drawing.Point(145, 106);
            txtPassword.Name = "txtPassword";
            editorButtonImageOptions1.Image = (System.Drawing.Image)resources.GetObject("editorButtonImageOptions1.Image");
            txtPassword.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default), new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear) });
            txtPassword.Properties.NullText = "Введите пароль";
            txtPassword.Properties.PasswordChar = '•';
            txtPassword.Size = new System.Drawing.Size(211, 20);
            txtPassword.TabIndex = 2;
            txtPassword.ButtonClick += buttonEdit1_ButtonClick;
            txtPassword.ButtonPressed += buttonEdit1_ButtonPressed;
            // 
            // capPassword
            // 
            capPassword.Location = new System.Drawing.Point(53, 109);
            capPassword.Name = "capPassword";
            capPassword.Size = new System.Drawing.Size(86, 13);
            capPassword.TabIndex = 3;
            capPassword.Text = "Введите пароль:";
            // 
            // labelControl1
            // 
            labelControl1.Location = new System.Drawing.Point(53, 52);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(79, 13);
            labelControl1.TabIndex = 4;
            labelControl1.Text = "Введите логин:";
            // 
            // ucAuthorizationForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(labelControl1);
            Controls.Add(capPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Controls.Add(bCheck);
            Name = "ucAuthorizationForm";
            Size = new System.Drawing.Size(421, 207);
            ((System.ComponentModel.ISupportInitialize)txtLogin.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton bCheck;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
        private DevExpress.XtraEditors.LabelControl capPassword;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtLogin;
        private DevExpress.XtraEditors.ButtonEdit txtPassword;
    }
}
