using Core.Entities;
using Core.Helpers;
using DataAccess.Impelementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    public class DrugStoreController
    {
        private DrugStoreRepository _drugStoreRepository;
        private OwnerRepository _ownerRepository;
        private DruggistRepository _druggistRepository;
        private DrugRepository _drugRepository;    

        public DrugStoreController()
        {
            _drugStoreRepository = new DrugStoreRepository();
            _ownerRepository = new OwnerRepository();
            _druggistRepository = new DruggistRepository();
            _drugRepository=new DrugRepository();
        }

        #region CreateDrugStore
        public void CreateDrugStore()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Drugstore Name:");
                string name = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Drugstore Adress");
                string adress = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Drugstore ContactNumber:");
                string contactNumber = Console.ReadLine();





            allowner: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Owner:");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{owner.Id} Name:{owner.Name} Surname:{owner.Surname} ");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Owner Id:");
                string ownerId = Console.ReadLine();
                int id;
                bool result = int.TryParse(ownerId, out id);
                if (result)
                {

                    var owner = _ownerRepository.Get(o => o.Id == id);
                    if (owner != null)
                    {
                        var drugstore = new DrugStore()
                        {
                            Name = name,
                            Adresss = adress,
                            ContactNumber = contactNumber,
                            Owner = owner,

                        };
                        _drugStoreRepository.Create(drugstore);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{drugstore.Id} Adress:{drugstore.Adresss} ContactNumber:{drugstore.ContactNumber} Owner:{drugstore.Owner.Name} DrugStore is successfully created");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This Owner id doesn't exist");
                        goto allowner;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format id");
                    goto id;
                }





            }

            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please firstly create owner");
            }
        }
        #endregion

        #region UpdateDrugstore
        public void UpdateDrugstore()
        {
            var drugstores = _drugStoreRepository.GetAll();

            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All DrugStores:");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drugstore.Id} Name:{drugstore.Name} Adress:{drugstore.Adresss} ContactNumber:{drugstore.ContactNumber} Owner:{drugstore.Owner}");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter DrugStore Id:");
                string drugstoreId = Console.ReadLine();
                int id;
                bool result = int.TryParse(drugstoreId, out id);
                if (result)
                {
                    var drugstore = _drugStoreRepository.Get(d => d.Id == id);
                    if (drugstore != null)
                    {
                        string oldname = drugstore.Name;
                        string oldadress = drugstore.Adresss;
                        string oldcontactnumber = drugstore.ContactNumber;

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new drugstore name:");
                        string newName = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new drugstore adress:");
                        string newAdress = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new drugstore contactnumber:");
                        string newContactName = Console.ReadLine();
                    owid: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new drugstore owner Id:");
                        string newOwner = Console.ReadLine();
                        int newId;
                        result = int.TryParse(newAdress, out newId);
                        if (result)
                        {
                            var NewOwner = _ownerRepository.Get(o => o.Id == id);
                            if (newOwner != null)
                            {
                                var newdrugstore = new DrugStore
                                {
                                    Id = drugstore.Id,
                                    Name = newName,
                                    Adresss = newAdress,
                                    ContactNumber = newContactName,
                                    Owner = NewOwner,

                                };
                                _drugStoreRepository.Update(drugstore);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"OldName:{oldname} OldAdress:{oldadress} OldContactNumber:{oldcontactnumber} Drugstore is successfully update: ID:{drugstore.Id} Name:{newName} Adress:{newAdress} ContactNumber:{newContactName} Owner:{newOwner} ");


                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This owner doesn't exist");

                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct owner id");
                            goto owid;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This Id drugstore doesn't exist");
                        goto id;
                    }

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format id");
                    goto id;
                }



            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugstore");
            }




        }

        #endregion

        #region DeleteDrugStore
        public void DeleteDrugStore()
        {
            var drugstores = _drugStoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All DrugStores:");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drugstore.Id} Name:{drugstore.Name} Adress:{drugstore.Adresss} Owner:{drugstore.Owner}");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter DrugStore Id:");
                string drugstoreId = Console.ReadLine();
                int id;
                bool result = int.TryParse(drugstoreId, out id);
                if (result)
                {
                    var drugstore = _drugStoreRepository.Get(d => d.Id == id);
                    if (drugstore != null)
                    {
                        _drugStoreRepository.Delete(drugstore);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{drugstore.Id} Name:{drugstore.Name} Is Successfully Deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drugstore doesn't exist");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format id");
                    goto id;
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any Drugstore");
            }

        }


        #endregion

        #region GetAll
        public void GetAll()
        {
            var drugstores = _drugStoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
            alldrugstore: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "All DrugStores:");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drugstore.Id} Name:{drugstore.Name} Adress:{drugstore.Adresss}");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please Enter DrugStore Id:");
                string drugstoreId = Console.ReadLine();
                int id;
                bool result = int.TryParse(drugstoreId, out id);
                if (result)
                {
                    var drugstore = _drugStoreRepository.Get(d => d.Id == id);
                    if (drugstore != null)
                    {
                        _drugStoreRepository.Delete(drugstore);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{drugstore.Id} Name:{drugstore.Name} Adress:{drugstore.Adresss} is successfully deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This Drugstore Id doesn't exist");
                        goto alldrugstore;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format Id");
                    goto id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugstore");
            }
        }

        #endregion

        #region GetAllDrugStoreByOwner
       public void GetAllDrugStoreByOwner()
        {
            var owners=_ownerRepository.GetAll();
            if (owners.Count>0)
            {
              all:  ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Owners");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{owner.Id} Name:{owner.Name} Surname:{owner.Surname} DrugStores:{owner.Drugstores}");
                }
              id:  ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please Enter Owner Id:");
                string ownerId = Console.ReadLine();
                int id;
                bool result = int.TryParse(ownerId, out id);
                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == id);
                    if (owner!=null)
                    {
                        var drugstores = _drugStoreRepository.GetAll(d => d.Owner != null ? d.Owner.Id == owner.Id : false);
                        if (drugstores.Count>0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "The DrugStores of Owner:");
                            foreach (var drugstore in drugstores)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{drugstore.Id} Name:{drugstore.Name} Adress:{drugstore.Adresss}");
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Owner has not Drugstore");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This owner doesn't exist");
                        goto all;
                    }

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter corred format id");
                    goto id;
                }
            
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any owner");
            }
        }

        #endregion

        #region Sale
        public void Sale()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count>0)
            {
              all:  ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Drugs:");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drug.Id} Name:{drug.Name} Price:{drug.Price} Count:{drug.Count}");
                }
               id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please Enter Drugs Id:");
                string drugId=Console.ReadLine();
                int id;
                bool result = int.TryParse(drugId, out id);
                if (result)
                {
                    var drug = _drugRepository.Get(d => d.Id == id);
                    if (drug!=null)
                    {
                      count:  ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please enter drug count:");
                        string drugCount = Console.ReadLine();
                        int count;
                        result=int.TryParse(drugCount,out count);
                        if (result)
                        {
                            if (count<drug.CurrentCount)
                            {

                                drug.CurrentCount = drug.CurrentCount - count;
                               double SumPrice= drug.Price * count;
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "This drug is available in the pharmacy.Do you want to buy??? (yes or no)");
                                string text=Console.ReadLine();
                                if (text=="yes".ToLower())
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{drug.Id} Name:{drug.Name} SumPrice:{SumPrice}---- DrugStore--> Id:{drug.Id} Name:{drug.Name} DrugCount:{drug.CurrentCount}");
                                }
                                else if (text=="no".ToLower())
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Thank you ser");
                                }
                              
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Unfortunately, this amount of drug is not available in the pharmacy");
                                goto count; 
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format count");
                            goto count;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drug doesn't exist");
                        goto all;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format id");
                    goto id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drug");
            }
        }

        #endregion
    }
}
