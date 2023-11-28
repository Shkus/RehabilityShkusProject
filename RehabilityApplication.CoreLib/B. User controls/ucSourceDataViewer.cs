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

            CoreGlobalCommandManager.CommandInitialized += (s, e) =>
            {
                if(e.Command is SourceDataCommandType.ShowAsTreeList)
                {
                    TL.BringToFront();
                    TL.DataSource = ExcelFileManager.Data;
                }

                if(e.Command is SourceDataCommandType.ShowAsExcelView)
                {
                    Table.BringToFront();
                    List<ExcelRowItem> data = ExcelFileManager.Data;

                    Table.ActiveWorksheet.Cells[0, 0].Value = "Дата";
                    Table.ActiveWorksheet.Cells[0, 1].Value = "СНИЛС";
                    Table.ActiveWorksheet.Cells[0, 2].Value = "ФИО";
                    Table.ActiveWorksheet.Cells[0, 3].Value = "Палиатив";
                    Table.ActiveWorksheet.Cells[0, 4].Value = "Дата контракта";
                    Table.ActiveWorksheet.Cells[0, 5].Value = "Номер контракта";
                    Table.ActiveWorksheet.Cells[0, 6].Value = "Напраление - дата";
                    Table.ActiveWorksheet.Cells[0, 7].Value = "Направление - номер";
                    Table.ActiveWorksheet.Cells[0, 8].Value = "Адрес";

                    int currentIndex = 1;

                    foreach(var item in data)
                    {
                        Table.ActiveWorksheet.Cells[currentIndex, 0].Value = item.Date;
                        Table.ActiveWorksheet.Cells[currentIndex, 1].Value = item.Snils;
                        Table.ActiveWorksheet.Cells[currentIndex, 2].Value = item.FIO;
                        Table.ActiveWorksheet.Cells[currentIndex, 3].Value = item.IsPaliative;
                        Table.ActiveWorksheet.Cells[currentIndex, 4].Value = item.ContractStartDate;
                        Table.ActiveWorksheet.Cells[currentIndex, 5].Value = item.ContractNumber;
                        Table.ActiveWorksheet.Cells[currentIndex, 6].Value = item.DirectionDate;
                        Table.ActiveWorksheet.Cells[currentIndex, 7].Value = item.DirectionNumber;
                        Table.ActiveWorksheet.Cells[currentIndex, 8].Value = item.Address;

                        currentIndex++;
                    }

                    for(int i = 0; i < 9; i++)
                    {
                        Table.ActiveWorksheet.Columns[i].AutoFit();
                    }

                }
            };
        }

    }
}
