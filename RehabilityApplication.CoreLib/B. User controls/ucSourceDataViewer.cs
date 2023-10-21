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
    public partial class ucSourceDataViewer : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSourceDataViewer()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }
    }
}
