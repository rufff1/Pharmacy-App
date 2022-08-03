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
    public class DrugController
    {
        private DrugRepository _drugRepository;
        private DrugStoreRepository _drugStoreRepository;
        public DrugController()
        {
            _drugStoreRepository = new DrugStoreRepository();
            _drugRepository = new DrugRepository();
        }

        #region CreateDrug
        public void CreateDrug()
        {
            var drugStories = _drugStoreRepository.GetAll();

            if (drugStories.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Drug Name:");
                string drugName = Console.ReadLine();
            drugPrice: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Drug Price:");
                string priceDrug = Console.ReadLine();
                double price;
                bool result = double.TryParse(priceDrug, out price);
            drugCount: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Drug Count:");
                string countDrug = Console.ReadLine();
                int count;
                result = int.TryParse(countDrug, out count);

                if (result)
                {
                    if (result)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All DrugStories:");
                        foreach (var drugstore in drugStories)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"ID:{drugstore.Id}, Name:{drugstore.Name}, Adress:{drugstore.Adresss}, ContactNumber:{drugstore.ContactNumber} ");
                        }
                    DrugStoreID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please enter DrugStore ID");
                        string storeId = Console.ReadLine();
                        int id;
                        result = int.TryParse(storeId, out id);
                        if (result)
                        {
                            var drugStore = _drugStoreRepository.Get(d => d.Id == id);
                            if (drugStore != null)
                            {
                                var drug = new Drug
                                {
                                    Name = drugName,
                                    Price = price,
                                    Count = count,
                                    DrugStores = drugStore,
                                };
                                _drugRepository.Create(drug);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{drugName}, Price:{priceDrug}, Count:{countDrug} DrugStore:{drug.DrugStores.Name}is successfully created drug");

                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This Id DrugStore is Empty");
                                goto DrugStoreID;
                            }


                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format Id");
                            goto DrugStoreID;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format drug count");
                        goto drugCount;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format drug price");
                    goto drugPrice;
                }


            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any DrugStore");
            }
        }


        #endregion

        #region UpdateDrug
        public void UpadateDrug()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Drugs:");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drug.Id} Name:{drug.Name} Price:{drug.Price} Count:{drug.Count} DrugStore:{drug.DrugStores.Name}");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Drug Id:");
                string drugId = Console.ReadLine();
                int id;
                bool result = int.TryParse(drugId, out id);
                if (result)
                {
                    var drug = _drugRepository.Get(d => d.Id == id);
                    if (drug != null)
                    {
                        string oldname = drug.Name;
                        double oldprice = drug.Price;
                        int oldcount = drug.Count;
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new drug name:");
                        string newName = Console.ReadLine();
                    price: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new drug Price:");
                        string newPrice = Console.ReadLine();
                        double price;
                        result = double.TryParse(newPrice, out price);
                        if (result)
                        {
                        count: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new drug count");
                            string newCount = Console.ReadLine();
                            int count;
                            result = int.TryParse(newCount, out count);
                            if (result)
                            {
                                var newDrug = new Drug
                                {
                                    Name = newName,
                                    Price = price,
                                    Count = count,
                                };
                                _drugRepository.Update(drug);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"OldName:{oldname} OldPrice:{oldprice} OldCount:{oldcount} is drug successfully update: Name:{newName} Price:{newPrice} Count:{newCount}");

                            }
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format count");
                            goto count;
                        }
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format Price");
                        goto price;
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drug doesn't exist");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugs");
            }
        }

        #endregion

        #region DeleteDrug
        public void DeleteDrug()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
            all: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Drugs:");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drug.Id} Name:{drug.Name} Price:{drug.Price} Count:{drug.Count} DrugStore:{drug.DrugStores.Name}");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Drug Id:");
                string drugId = Console.ReadLine();
                int id;
                bool result = int.TryParse(drugId, out id);
                if (result)
                {
                    var drug = _drugRepository.Get(d => d.Id == id);
                    if (drug != null)
                    {
                        _drugRepository.Delete(drug);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id{drug.Id} Name:{drug.Name} This drug is successfully deleted");
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

        #region  GetAllDrugByStore
        public void GetAllDrugByStore()
        {
            var drugstores = _drugStoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
            all: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All drugstore:");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drugstore.Id} Name:{drugstore.Name} Adress:{drugstore.Adresss} ContactNumber:{drugstore.ContactNumber}");
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
                        var drugs = _drugRepository.GetAll(d => d.DrugStores != null ? d.DrugStores.Id == drugstore.Id : false);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "The drugs of drugsore:");
                        foreach (var drug in drugs)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drug.Id} Name:{drug.Name} Price:{drug.Price} Count:{drug.Count}");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drugstore doesn't exist");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugstores");
            }
        }
        #endregion

        #region DrugFilter
        public void DrugFilter()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
            price: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please enter filter price:");
                string filterprice = Console.ReadLine();
                double price;
                bool result = double.TryParse(filterprice, out price);
                if (result)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Drugs:");
                    foreach (var drug in drugs)
                    {
                        if (drug.Price<price)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drug.Id} Name:{drug.Name} Price:{drug.Price} Count:{drug.Count}");
                        }
                    
                    
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "please enter correct format price");
                    goto price;
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
