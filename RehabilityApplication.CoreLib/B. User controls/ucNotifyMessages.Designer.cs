namespace RehabilityApplication.CoreLib
{
    partial class ucNotifyMessages
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
            tlNotifyMessageList = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)tlNotifyMessageList).BeginInit();
            SuspendLayout();
            // 
            // tlNotifyMessageList
            // 
            tlNotifyMessageList.Dock = System.Windows.Forms.DockStyle.Fill;
            tlNotifyMessageList.Location = new System.Drawing.Point(0, 0);
            tlNotifyMessageList.Name = "tlNotifyMessageList";
            tlNotifyMessageList.Size = new System.Drawing.Size(470, 319);
            tlNotifyMessageList.TabIndex = 0;
            // 
            // ucNotifyMessages
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tlNotifyMessageList);
            Name = "ucNotifyMessages";
            Size = new System.Drawing.Size(470, 319);
            ((System.ComponentModel.ISupportInitialize)tlNotifyMessageList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraTreeList.TreeList tlNotifyMessageList;
    }
}
