using DevExpress.XtraEditors;
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
    public partial class ucOkDialog : DevExpress.XtraEditors.XtraUserControl
    {
        public ucOkDialog(string message)
        {
            InitializeComponent();
            bOk.DialogResult = DialogResult.OK;
            labMessage.Text = message;
        }
    }
}
