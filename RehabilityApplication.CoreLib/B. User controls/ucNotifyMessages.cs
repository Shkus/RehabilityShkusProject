using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RehabilityApplication.CoreLib
{
    public partial class ucNotifyMessages : DevExpress.XtraEditors.XtraUserControl
    {
        private List<MessageItem> messages = new List<MessageItem>();
        public ucNotifyMessages()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;

            this.HandleCreated += (s, e) =>
            {
                CoreGlobalCommandManager.CommandInitialized += (s, e) =>
                {
                    messages.Add(new MessageItem { Text = e.Text });

                    SplashScreenManager.Default.SetWaitFormDescription(e.Text);

                    //Application.DoEvents();

                    BeginInvoke(new MethodInvoker(delegate
                    {
                        //tlNotifyMessageList.SuspendLayout();
                        tlNotifyMessageList.DataSource = messages;
                        tlNotifyMessageList.RefreshDataSource();
                        //tlNotifyMessageList.ResumeLayout();
                    }));
                };
            };

            tlNotifyMessageList.DataSource = messages;
        }
    }

    public class MessageItem
    {
        [DisplayName("Сообщение от бота")]
        public string Text { get; set; }

    }
}
