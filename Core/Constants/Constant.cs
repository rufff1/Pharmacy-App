using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
   public enum AdminOptions
    {
        Logout = 1,
        BackMainMenu = 0,
    }
    public enum DrugOptions
    {
        CreateDrug = 1,
        UpdateDrug,
        DeleteDrug,
        GetAllDrugByStore,
        GetDrugByStore,
        DrugFilter,
        BackMainMenu = 0,
    }

    public enum DruggistOptions
    {
        CreateDruggist = 1,
        UpdateDruggist,
        DeleteDruggist,
        GetAllDruggist,
        GetAllDruggistByDrugStore,
        BackToMainMenu = 0,
    }

    public enum DrugStoreOptions
    {
        CreateDrugStore = 1,
        UpdateDrugStore,
        DeleteDrugStore,
        GetAllDrugStore,
        GetAllDrugStoreByOwner,
        Sale,
        BackToMainMenu = 0,
    }
    public enum OwnerOptions
    {
        CreateOwner = 1,
        UpdateOwner,
        DeleteOwner,
        GetAllOwner,
        BackToMainMenu = 0,
    }

  
}

