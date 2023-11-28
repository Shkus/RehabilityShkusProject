using System;
using System.Collections.Generic;
using System.ComponentModel;
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




    public enum DevelopersType
    {
        [Description("Выбрать...")]
        NotSelected,
        [Description("Джуниор")]
        Junior,
        [Description("Старший джун")]
        JuniorPlus,
        [Description("Младший мидл")]
        MiddleMinus,
        [Description("Мидл")]
        Middle,
        [Description("Старший мидл")]
        MiddlePlus,
        [Description("Сеньор")]
        Senior,
        [Description("Старший сеньор")]
        SeniorPlus,
        [Description("Эксперт")]
        SeniorOverFlow,
    }
}
