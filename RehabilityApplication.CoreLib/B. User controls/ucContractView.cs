using DevExpress.CodeParser;
using DevExpress.XtraReports.Serialization;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Forms;

namespace RehabilityApplication.CoreLib
{
    public partial class ucContractView : DevExpress.XtraEditors.XtraUserControl
    {
        public ucContractView()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;

            if(GlobalDatabaseManager.contracts.Count == 0)
            {
                GlobalDatabaseManager.Init();
            }

            TL.DataSource = GlobalDatabaseManager.treeListItems;
            TL.RefreshDataSource();

            //TL.CustomDrawNodeButton += (s, e) =>
            //{
            //    Rectangle rect = Rectangle.Inflate(e.Bounds, 0, -1);
            //    System.Drawing.Image img;

            //    ITree myNode = (ITree)TL.GetDataRecordByNode(e.Node);

            //    if (myNode is dbContract)
            //    {
            //        img = Properties.Resources.bag;
            //    }
            //    else
            //    {
            //        img = Properties.Resources.list;
            //    }

            //    e.Graphics.DrawImage(img, rect);
            //    e.Handled = true;
            //};

            TL.CustomDrawNodeIndent += (s, e) =>
            {

                ITree myNode = (ITree)TL.GetDataRecordByNode(e.Node);

                if(myNode is dbContract)
                {
                    Rectangle rect = Rectangle.Inflate(e.Bounds, 0, -1);
                    System.Drawing.Image img;
                    img = Properties.Resources.bag;

                    e.Graphics.DrawImage(img, rect);
                    e.Handled = true;
                }
                else if(myNode is dbContractList)
                {
                    Rectangle rect = Rectangle.Inflate(e.Bounds, -6, 0);
                    System.Drawing.Image img;
                    img = Properties.Resources.list;

                    e.Graphics.DrawImage(img, rect);
                    e.Handled = true;
                }
                else if(myNode is dbReestr)
                {
                    Rectangle rect = Rectangle.Inflate(e.Bounds, (-6 -16), 0) ;
                    System.Drawing.Image img;
                    img = Properties.Resources.list;

                    e.Graphics.DrawImage(img, rect);
                    e.Handled = true;
                }
                //else if(myNode is dbClientInReestr)
                {
                    Rectangle rect = Rectangle.Inflate(e.Bounds, (-6 -26), 0);
                    System.Drawing.Image img;
                    img = Properties.Resources.list;

                    e.Graphics.DrawImage(img, rect);
                    e.Handled = true;
                }

            };
        }
    }
}
