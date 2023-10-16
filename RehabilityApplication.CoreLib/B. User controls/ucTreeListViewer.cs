using System.Windows.Forms;

namespace RehabilityApplication.CoreLib
{
    /// <summary>
    /// Класс слоя для отображения табличных данных.
    /// </summary>
    public partial class ucTreeListViewer : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// Тип данных для отображения.
        /// </summary>
        private SourceDataType _tableType;

        /// <summary>
        /// Конструктор элемент управления для отображения данных из БД.
        /// </summary>
        /// <param name="dataType">Тип данных.</param>
        public ucTreeListViewer(SourceDataType dataType)
        {
            InitializeComponent();
            _tableType = dataType;
            this.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Устанавливает данные в таблицу.
        /// </summary>
        /// <param name="data">Данные.</param>
        public void SetData(dynamic data)
        {
            this.TL.DataSource = data;
        }
    }
}
