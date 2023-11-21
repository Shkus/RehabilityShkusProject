using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehabilityApplication.CoreLib
{
    public enum PlanetEarthCommandType
    {
        SendMoney,
        SendPeople,
        SendWeapon,
        SendAnyMessage,
        HelloVasyok,
       
    }
    public enum RehabilityMarsCommand { 
        HiBraza,
    }

    public enum FoodDelivery
    { 
        Done,
        Wait,
        FotgetIt
    }

    public enum DatabaseCommandType
    {
        DatabaseWasInitializated,
        AddNewClientInit,
        AddNewClientFromForm,
        EditClientFromForm,
        RemoveClient,
        editDataClient,
        ClearClients,
        FocusedClientWasChangedPleaseShowPassports,
	    FocusedClientWasChangedPleaseShowProductsInClients,
        FocusedClientWasChangedPLeaseShowClient,
        FocusedClientWasChangedPLeaseShowInClientCall
    }

    public enum ResponseCommandType
    {
        ClientAlreadyExist,
        ClientIsNotExist
    }

    public enum YandexDiskManagerCommandType
    {
        CreateFolder,
        FolderStructureWasReaded,
        DatabaseUploaded,
        PleaseDownloadDatabase,
        DownloadDatabaseComplete

    }


    public enum SQLiteCommandType
    {
        LoadDataComplete,
        DeleteRecordPlease,
        DeleteRecordPleaseAsChange,
    }
}
