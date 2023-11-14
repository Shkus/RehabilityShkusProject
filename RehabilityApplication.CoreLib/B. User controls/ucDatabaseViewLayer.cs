using System.Windows.Forms;


namespace RehabilityApplication.CoreLib
{
    /// <summary>
    /// Класс слоя для отображения данных из БД.
    /// </summary>
    public partial class ucDatabaseViewLayer : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// Слой отображения получателей.
        /// </summary>
        ucTreeListViewer clientsView = new ucTreeListViewer(SourceDataType.Clients);

        /// <summary>
        /// Слой отображения документов, удостоверяющих личность.
        /// </summary>
        ucTreeListViewer passportsView = new ucTreeListViewer(SourceDataType.Passports);

        /// <summary>
        /// Слой отображения товаров получателя.
        /// </summary>
        ucTreeListViewer productsInClientView = new ucTreeListViewer(SourceDataType.ProductsInClient);

        /// <summary>
        /// Слой отображения информации о звонках.
        /// </summary>
        ucTreeListViewer callsView = new ucTreeListViewer(SourceDataType.Calls);
        public ucDatabaseViewLayer()
        {
            InitializeComponent();

            this.dpClients.Controls.Add(this.clientsView);
            this.dpPassports.Controls.Add(this.passportsView);
            this.dpProductsInClient.Controls.Add(this.productsInClientView);
            this.dpCalls.Controls.Add(this.callsView);

            this.Dock = DockStyle.Fill;

            CoreGlobalCommandManager.CommandInitialized += (s, e) =>
            {
                if(e.Command is EnumLanguageType.Russian || e.Command is EnumLanguageType.English)
                {
                    ReLanguageUI();
                }
            };
        }
        private void ReLanguageUI()
        {
            dpCalls.SetResourceString();
            dpClients.SetResourceString();
            dpPassports.SetResourceString();
            dpProductsInClient.SetResourceString();

        }


    }
}
