using DevExpress.XtraBars;
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
    public partial class ucSQLiteViewer : DevExpress.XtraEditors.XtraUserControl
    {
        const string TableName = "Persons";

        public ucSQLiteViewer()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            CoreGlobalCommandManager.CommandDataReceivingInitialized += (s, e) =>
            {
                if(e.Command is SQLiteCommandType.LoadDataComplete)
                {
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        TL.DataSource = e.Data;
                    }));
                }
            };

            CoreGlobalCommandManager.CommandInitialized += (s, e) =>
            {
                if(e.Command is SQLiteCommandType.DeleteRecordPlease)
                {
                    if(TL.FocusedNode == null)
                    {
                        return;
                    }

                    var myNode = (DataRowView)TL.GetDataRecordByNode(TL.FocusedNode);

                    int indexId = TL.FocusedNode.TreeList.Columns.Where(t => t.FieldName == "Id").Select(t => t.AbsoluteIndex).FirstOrDefault();

                    var RowId = myNode.Row.ItemArray[indexId];

                    if(ApplicationSettings.TS.Checked == false)
                    {
                        SqliteManager.DeleteRecord(TableName, RowId);
                    }
                    else
                    {
                        SqliteManager.SaveDeleteChange(TableName, RowId);
                    }
                }
            };

            TL.CellValueChanged += (s, e) =>
            {
                string columnName = e.Column.FieldName;
                var newValue = e.Value;

                var myNode = (DataRowView)TL.GetDataRecordByNode(TL.FocusedNode);
                int indexId = TL.FocusedNode.TreeList.Columns.Where(t => t.FieldName == "Id").Select(t => t.AbsoluteIndex).FirstOrDefault();
                var RowId = myNode.Row.ItemArray[indexId];

                if(ApplicationSettings.TS.Checked == false)
                {
                    SqliteManager.UpdateRecord(TableName, columnName, RowId, newValue);
                }
                else
                {
                    SqliteManager.SaveUpdateChange(TableName, columnName, RowId, newValue);
                }
            };
        }
    }
}
