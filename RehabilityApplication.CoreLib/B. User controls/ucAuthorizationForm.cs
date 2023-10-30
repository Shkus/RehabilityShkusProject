using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RehabilityApplication.CoreLib
{
    public partial class ucAuthorizationForm : DevExpress.XtraEditors.XtraUserControl
    {
        string fileName;
        public ucAuthorizationForm()
        {
            InitializeComponent();

            bCheck.DialogResult = DialogResult.OK;

            CoreGlobalCommandManager.CommandDataReceivingInitialized += ReceiveDataCommandEvent;
        }

        private void ReceiveDataCommandEvent(object sender, ReceiveDataCommandArgs e)
        {
            if (e.Command is YandexDiskManagerCommandType.FolderStructureWasReaded)
            {
                List<ITreeListItem> structure = e.Data;

                var files = structure.Where(t => t is HostFileItem).ToList();

                var mapFile = files.Any(t => t.Name == fileName);
                if (mapFile)
                {
                    //MessageBox.Show("Да, пользователь есть!");

                    CoreGlobalCommandManager.StartCommand(YandexDiskManagerCommandType.PleaseDownloadDatabase);
                }
                else
                {
                    //MessageBox.Show("Такого пользователя нет!");
                }
            }
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;

            fileName = $"{login}{password}.txt";

            bool isReady = YandexDiskManager.GetFolderStructure("/25-10-2023/Users/");

            CoreGlobalCommandManager.CommandDataReceivingInitialized -= ReceiveDataCommandEvent;
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                txtPassword.Text = "";
            }

            if (e.Button.Index == 0)
            {
                txtPassword.Properties.PasswordChar = '•';
            }
        }

        private void buttonEdit1_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                txtPassword.Properties.PasswordChar = '\0';
            }
        }
    }
}
