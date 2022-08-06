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
            _drugRepository = new DrugRepository();
        }

        #region CreateDrugStore
        public void CreateDrugStore()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Drugstore Name:");
                string name = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Drugstore Adress:");
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
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{drugstore.Id} Name:{drugstore.Name} Adress:{drugstore.Adresss} ContactNumber:{drugstore.ContactNumber} Owner:{drugstore.Owner.Name} DrugStore is successfully created");
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
        //update bax
        #region UpdateDrugstore
        public void UpdateDrugstore()
        {
            var drugstores = _drugStoreRepository.GetAll();
            var owners = _ownerRepository.GetAll();

            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All DrugStores:");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drugstore.Id} Name:{drugstore.Name} Adress:{drugstore.Adresss} ContactNumber:{drugstore.ContactNumber} Owner:{drugstore.Owner.Name}");
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
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Owner:");
                        foreach (var owner in owners)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{owner.Id} Name:{owner.Name} Surname:{owner.Surname}");
                        }
                    owid: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new drugstore owner Id:");
                        string newOwnerId = Console.ReadLine();
                        int newId;
                        result = int.TryParse(newOwnerId, out newId);
                        if (result)
                        {
                            var newowner = _ownerRepository.Get(o => o.Id == id);
                            if (newowner != null)
                            {
                                var newDrugstore = new DrugStore
                                {
                                    Id = drugstore.Id,
                                    Name = newName,
                                    Adresss = newAdress,
                                    ContactNumber = newContactName,
                                    Owner = newowner

                                };
                                _drugStoreRepository.Update(newDrugstore);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"OldName:{oldname} OldAdress:{oldadress} OldContactNumber:{oldcontactnumber} Drugstore is successfully update: ID:{drugstore.Id} Name:{newDrugstore.Name} Adress:{newDrugstore.Adresss} ContactNumber:{newDrugstore.ContactNumber} Owner ID:{newowner.Id} name:{newowner.Name} ");


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
            alldrugstore: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All DrugStores:");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drugstore.Id} Name:{drugstore.Name} Adress:{drugstore.Adresss} Owner:{drugstore.Owner.Name}");
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
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
            all: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Owners");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{owner.Id} Name:{owner.Name} Surname:{owner.Surname} DrugStores:{owner.Drugstores}");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please Enter Owner Id:");
                string ownerId = Console.ReadLine();
                int id;
                bool result = int.TryParse(ownerId, out id);
                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == id);
                    if (owner != null)
                    {
                        var drugstores = _drugStoreRepository.GetAll(d => d.Owner != null ? d.Owner.Id == owner.Id : false);
                        if (drugstores.Count > 0)
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
        //sale bax
        #region Sale
        public void Sale()
        {
            var drugstores = _drugStoreRepository.GetAll();

            if (drugstores.Count > 0)
            {


            drugstoreall: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All DrugStore:");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drugstore.Id} Name:{drugstore.Name} Adress:{drugstore.Adresss} Owner:{drugstore.Owner.Name}");
                }



            id1: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please Enter DrugStore Id:");
                string drugstoreId = Console.ReadLine();
                int id1;
                bool result = int.TryParse(drugstoreId, out id1);
                if (result)
                {
                    var drugstore = _drugStoreRepository.Get(d => d.Id == id1);
                    if (drugstore != null)
                    {
                        var drugstoreDrugs = _drugRepository.GetAll(d => d.DrugStores.Id == drugstore.Id);
                        if (drugstoreDrugs.Count > 0)
                        {

                        all: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Drugs:");
                            foreach (var drugstoredrug in drugstoreDrugs)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drugstoredrug.Id} Name:{drugstoredrug.Name} Price:{drugstoredrug.Price} Count:{drugstoredrug.Count}");
                            }
                        id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please Enter Drugs Id:");
                            string drugId = Console.ReadLine();
                            int id;
                            result = int.TryParse(drugId, out id);
                            if (result)
                            {
                                var drug = _drugRepository.Get(d => d.Id == id);
                                if (drug != null)
                                {
                                count: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please enter drug count:");
                                    string drugCount = Console.ReadLine();
                                    int count;
                                    result = int.TryParse(drugCount, out count);
                                    if (result)
                                    {
                                        double SumPrice = drug.Price * count;
                                        if (count <= drug.Count)
                                        {
                                            drug.Count = drug.Count - count;

                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "This drug is available in the pharmacy.Do you want to buy??? (yes or no)");
                                            string text = Console.ReadLine();
                                            if (text == "yes".ToLower())
                                            {
                                            pay: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"The Pay to be Paid:{SumPrice}:");
                                                string pay = Console.ReadLine();
                                                double Pay;
                                                result = double.TryParse(pay, out Pay);
                                                if (result)
                                                {
                                                    if (SumPrice == Pay)
                                                    {
                                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{drug.Id} Name:{drug.Name} Pay:{SumPrice}---- DrugStore--> Id:{drug.Id} Name:{drug.Name} DrugCount:{drug.Count}");
                                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Thank you ser");
                                                    }
                                                    else
                                                    {
                                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"Please make the payment correctly, The Pay to be Paid:{SumPrice}");
                                                        goto pay;
                                                    }
                                                }
                                                else
                                                {
                                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct pay");
                                                    goto pay;
                                                }


                                            }
                                            else if (text == "no".ToLower())
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
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no drug in the drugstore");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This id doesn't drugstore");
                        goto drugstoreall;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format id");
                    goto id1;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugstore");   
            }    
        }
        






        #endregion





    }
}
