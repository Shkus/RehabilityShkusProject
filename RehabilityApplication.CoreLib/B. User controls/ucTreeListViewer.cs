using System.Collections.Generic;
using System.Linq;
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


            this.HandleCreated += (s, e) =>
            {


                CoreGlobalCommandManager.CommandInitialized += (s, e) =>
                {
                    if (dataType == SourceDataType.Clients)
                    {
                        if (e.Command is DatabaseCommandType.DatabaseWasInitializated)
                        {
                            BeginInvoke(new MethodInvoker(delegate
                            {
                                TL.DataSource = GlobalDatabaseManager.clients;
                            }));

                            AfterDatabaseInit();
                        }

                        if (e.Command is DatabaseCommandType.ClearClients)
                        {
                            BeginInvoke(new MethodInvoker(delegate
                            {
                                TL.Nodes.Clear();
                            }));
                        }

                        if (e.Command is YandexDiskManagerCommandType.DownloadDatabaseComplete)
                        {
                            BeginInvoke(new MethodInvoker(delegate
                            {
                                GlobalDatabaseManager.clients = (List<dbClient>)ClassObject.Deserialize(GlobalDatabaseManager.clients, "clients_.xml");
                                TL.DataSource = GlobalDatabaseManager.clients;
                                TL.RefreshDataSource();
                            }));
                        }
                    };
                };


            };
        }

        void AfterDatabaseInit()
        {
            CoreGlobalCommandManager.CommandDataReceivingInitialized += (s, e) =>
            {
                if (_tableType == SourceDataType.Clients)
                {
                    if (e.Command is DatabaseCommandType.AddNewClientInit)
                    {
                        BeginInvoke(new MethodInvoker(delegate
                        {
                            var existClient = GlobalDatabaseManager.clients.Where(t => t.Snils == e.Data[0]).FirstOrDefault();

                            if (existClient != null)
                            {
                                CoreGlobalCommandManager.StartReceiveDataCommand(ResponseCommandType.ClientAlreadyExist, e.Data);
                                return;
                            }

                            GlobalDatabaseManager.clients.Add(new dbClient { Snils = e.Data[0] });
                            TL.DataSource = GlobalDatabaseManager.clients;
                            TL.RefreshDataSource();
                        }));
                    }

                    if (e.Command is DatabaseCommandType.RemoveClient)
                    {
                        BeginInvoke(new MethodInvoker(delegate
                        {
                            var existClient = GlobalDatabaseManager.clients.Where(t => t.Snils == e.Data[0]).FirstOrDefault();

                            if (existClient != null)
                            {
                                GlobalDatabaseManager.clients.Remove(existClient);
                            }
                            else
                            {
                                CoreGlobalCommandManager.StartReceiveDataCommand(ResponseCommandType.ClientIsNotExist, e.Data);
                            }

                            TL.DataSource = GlobalDatabaseManager.clients;
                            TL.RefreshDataSource();
                        }));
                    }

                    if (e.Command is DatabaseCommandType.editDataClient)
                    {
                        BeginInvoke(new MethodInvoker(delegate
                        {

                            var existClient = GlobalDatabaseManager.clients.Where(t => t.Snils == e.Data[0]).FirstOrDefault();

                            if (existClient != null)
                            {
                                int indexClient = GlobalDatabaseManager.clients.IndexOf(existClient);
                                existClient.Snils = e.Data[1];
                                GlobalDatabaseManager.clients[indexClient] = existClient;

                            }
                            else
                            {
                                CoreGlobalCommandManager.StartReceiveDataCommand(ResponseCommandType.ClientIsNotExist, e.Data);
                            }

                            TL.DataSource = GlobalDatabaseManager.clients;
                            TL.RefreshDataSource();
                        }));
                    }

                }
            };
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
