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
                bool result1 = int.TryParse(countDrug, out count);
                if (result)
                {
                    if (result1)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All DrugStories:");
                        foreach (var drugstore in drugStories)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"ID:{drugstore.Id}, Name:{drugstore.Name}, Adress:{drugstore.Adresss}, ContactNumber:{drugstore.ContactNumber} ");
                        }
                        DrugStoreID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please enter DrugStore ID");
                        string storeId=Console.ReadLine();
                        int id;
                        result = int.TryParse(storeId, out id);
                        if (result)
                        {
                            var drugStore = _drugStoreRepository.Get(d=> d.Id==id);
                            if (drugStore!=null)
                            {
                                var drug = new Drug
                                {
                                    Name=drugName,
                                    Price=price,
                                    Count=count,




                                };
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{drugName}, Price:{priceDrug}, Count:{countDrug} is successfully created drug ");

                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This Id DrugStore is Empty");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any DrougStore");
            }
        }


        #endregion





    }
}
