using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public enum OwnertOptions
    {

        Create = 1,
        Update,
        Delete,
        GetAll,
        BackToMainMenu,

    }
    public enum DrugOptions
    {
        CreateDrug = 1,
        UpdateDrug,
        DeleteDrug,
        GetAllDrugByStore,
        GetDrugByStore,
        BackMainMenu,
    }

    public enum DruggistOptions
    {
        Create = 1,
        Update,
        Delete,
        GetAll,
        GetAllDruggistByDrugStore,
        BackToMainMenu,
    }

    public enum DrugStoreOptions
    {
        Create = 1,
        Update,
        Delete,
        GetAll,
        GetAllDrugStoreByOwner,
        Sale,
        BackToMainMenu,
    }
    public enum OwnerOptions
    {
        Create = 1,
        Update,
        Delete,
        GetAll,
        BackToMainMenu,
    }

}

