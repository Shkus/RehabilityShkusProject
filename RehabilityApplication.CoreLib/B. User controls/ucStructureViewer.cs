using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Import.Doc;
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
    public partial class ucStructureViewer : DevExpress.XtraEditors.XtraUserControl
    {
        public ucStructureViewer()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            CoreGlobalCommandManager.CommandDataReceivingInitialized += (s, e) =>
            {
                if (e.Command is YandexDiskManagerCommandType.FolderStructureWasReaded)
                {
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        TL.DataSource = e.Data;
                        TL.RefreshDataSource();
                    }));
                }
            };
        }
    }
}
