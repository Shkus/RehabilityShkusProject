using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RehabilityApplication.CoreLib
{
    public partial class ucClientEditor : DevExpress.XtraEditors.XtraUserControl
    {
        //private dbClient myCurrentClient = null;
        //private dbClient myClonedClient = null; // Middle


        // Senior try
        object template;

        public ucClientEditor(object anyObject, int height = 300)
        {
            InitializeComponent();

            template = anyObject;

            // Junior
            //if(client != null)
            //{
            //    myCurrentClient = client;
            //    // Джуниорский способ
            //    teFIO.Text = client.FIO;
            //    teSnils.Text = client.Snils;
            //    tsIsSelected.IsOn = client.IsSelected;
            //}

            ////////////////////// Middle
            ////////////////////this.myCurrentClient =  client;
            ////////////////////dbClient clonedClient = new dbClient(client);
            ////////////////////this.myClonedClient = clonedClient;
            //////////////////////teFIO.DataBindings.Add(new Binding("Text", clonedClient, "FIO"));
            //////////////////////teSnils.DataBindings.Add(new Binding("Text", clonedClient, "Snils"));
            //////////////////////tsIsSelected.DataBindings.Add(new Binding("IsOn", clonedClient, "IsSelected"));
            ////////////////////teFIO.DataBindings.Add(new Binding("Text", clonedClient, nameof(clonedClient.FIO)));
            ////////////////////teSnils.DataBindings.Add(new Binding("Text", clonedClient, nameof(clonedClient.Snils)));
            ////////////////////tsIsSelected.DataBindings.Add(new Binding("IsOn", clonedClient, nameof(clonedClient.IsSelected)));
            ///
            this.Load += (s, e) =>
            {
                this.Height = height;
            };
            // Senior
            this.Panel.Build(anyObject);
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            string type = template.GetType().Name;


            ////////////if(myCurrentClient != null)
            ////////////{
            ////////////    //// Junior
            ////////////    //myCurrentClient.FIO = teFIO.Text;
            ////////////    //myCurrentClient.IsSelected = tsIsSelected.IsOn;
            ////////////    //myCurrentClient.Snils = teSnils.Text;
            ////////////    //CoreGlobalCommandManager.StartReceiveDataCommand(DatabaseCommandType.EditClientFromForm, myCurrentClient);

            ////////////    //////////////// Middle
            ////////////    //////////////myCurrentClient = myClonedClient;
            ////////////    //////////////CoreGlobalCommandManager.StartReceiveDataCommand(DatabaseCommandType.EditClientFromForm, myCurrentClient);
            ////////////}
            ////////////else
            ////////////{

            ////////////    //// Junior
            ////////////    //dbClient newClient = new dbClient()
            ////////////    //{
            ////////////    //    FIO = teFIO.Text,
            ////////////    //    IsSelected = tsIsSelected.IsOn,
            ////////////    //    Snils = teSnils.Text
            ////////////    //};
            ////////////    //CoreGlobalCommandManager.StartReceiveDataCommand(DatabaseCommandType.AddNewClientFromForm, newClient);

            ////////////    //////////////// Middle
            ////////////    //////////////CoreGlobalCommandManager.StartReceiveDataCommand(DatabaseCommandType.AddNewClientFromForm, myClonedClient);
            ////////////}


        }
    }
}
