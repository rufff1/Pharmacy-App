using Core.Constants;
using Core.Helpers;
using Pharmacy.Controllers;
using System;
namespace Pharmacy
{
    public class Pharmacy
    {
        public static void Main()
        {
            AdminController _adminController = new AdminController();
            DrugController _drugController = new DrugController();
            DruggistController _druggistController = new DruggistController();
            DrugStoreController _drugStoreController = new DrugStoreController();
            OwnerController _ownerController = new OwnerController();






        adminUserName: var admin = _adminController.Authenticate();
            if (admin != null)
            {

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Welcome {admin.UserName}");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Welcome My Pharmacy App");
                Console.WriteLine("----------------------------------------------------------");
                while (true)
                {
                mainMenu: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Main Menu:");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Admin Menu");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "2 - Drug Menu");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "3 - Druggist Menu");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "4 - DrugStore Menu");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "5 - Owner Menu");

                    Console.WriteLine("----------------------------------------------------------");

                selectNumber: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Select Number For Use:");
                    string number = Console.ReadLine();
                    int selectedNumber;
                    bool result = int.TryParse(number, out selectedNumber);

                    if (result)
                    {
                        if (selectedNumber == 1)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Logout UserName");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "0 - Back To Main Menu");

                        selectOp: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Select Options:");
                            number = Console.ReadLine();
                            result = int.TryParse(number, out selectedNumber);

                            if (selectedNumber >= 0 && selectedNumber <= 1)
                            {

                                switch (selectedNumber)
                                {
                                    case (int)AdminOptions.Logout:
                                        goto adminUserName;
                                        break;
                                    case (int)AdminOptions.BackMainMenu:
                                        goto mainMenu;
                                        break;
                                }

                            }

                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "The number you selected is not available");
                                goto selectOp;
                            }
                        }

                        else if (selectedNumber == 2)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Creat Drug");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update Drug");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "3 - Delete Drug");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "4 - Get All");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "5 - Get All Drug By Store");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "6 - Drug Filter");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "0 - Back To Main Menu");

                            Console.WriteLine("----------------------------------------------------------");


                        selectopp: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Select Options");
                            number = Console.ReadLine();

                            result = int.TryParse(number, out selectedNumber);

                            if (selectedNumber >= 0 && selectedNumber <= 6)
                            {
                                switch (selectedNumber)
                                {
                                    case (int)DrugOptions.CreateDrug:
                                        _drugController.CreateDrug();
                                        break;
                                    case (int)DrugOptions.UpdateDrug:
                                        _drugController.UpadateDrug();
                                        break;
                                    case (int)DrugOptions.DeleteDrug:
                                        _drugController.DeleteDrug();
                                        break;
                                    case (int)DrugOptions.GetAllDrug:
                                        _drugController.GetAllDrug();
                                        break;
                                    case (int)DrugOptions.GetAllDrugByStore:
                                        _drugController.GetAllDrugByStore();
                                        break;
                                    case (int)DrugOptions.DrugFilter:
                                        _drugController.DrugFilter();
                                        break;
                                    case (int)DrugOptions.BackMainMenu:
                                        goto mainMenu;
                                        break;

                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "The number you selected is not available");
                                goto selectopp;
                            }
                        }
                        else if (selectedNumber == 3)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Creat Druggist");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update Druggist");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "3 - Delete Druggist");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "4 - Get All Druggist");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "5 - Get Drugist By Store");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "0 - Back To Main Menu");

                            Console.WriteLine("----------------------------------------------------------");

                        oppp: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Select Options:");
                            number = Console.ReadLine();

                            result = int.TryParse(number, out selectedNumber);

                            if (selectedNumber >= 0 && selectedNumber <= 5)
                            {
                                switch (selectedNumber)
                                {
                                    case (int)DruggistOptions.CreateDruggist:
                                        _druggistController.CreateDruggist();
                                        break;
                                    case (int)DruggistOptions.UpdateDruggist:
                                        _druggistController.UpdateDruggist();
                                        break;
                                    case (int)DruggistOptions.DeleteDruggist:
                                        _druggistController.DeleteDruggist();
                                        break;
                                    case (int)DruggistOptions.GetAllDruggist:
                                        _druggistController.GetAllDruggist();
                                            break;
                                    case (int)DruggistOptions.GetAllDruggistByDrugStore:
                                        _druggistController.GetAllDruggistByDrugStore();
                                        break;
                                    case (int)DruggistOptions.BackToMainMenu:
                                        goto mainMenu;
                                        break;
                                        



                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "The number you selected is not available");
                                goto oppp;
                            }

                        }
                        else if (selectedNumber == 4)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Creat DrugStore");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update DrugStore");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "3 - Delete DrugStore");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "4 - Get All DrugStore");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "5 - Get All DrugStore By Owner");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "6 - Sale");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "0 - Back To Main Menu");

                            Console.WriteLine("----------------------------------------------------------");

                        opppp: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Select Options:");
                            number = Console.ReadLine();

                            result = int.TryParse(number, out selectedNumber);
                            if (selectedNumber >= 0 && selectedNumber <= 6)
                            {
                                switch (selectedNumber)
                                {
                                    case (int)DrugStoreOptions.CreateDrugStore:
                                        _drugStoreController.CreateDrugStore();
                                        break;
                                    case (int)DrugStoreOptions.UpdateDrugStore:
                                        _drugStoreController.UpdateDrugstore();
                                        break;
                                    case (int)DrugStoreOptions.DeleteDrugStore:
                                        _drugStoreController.DeleteDrugStore();
                                        break;
                                    case (int)DrugStoreOptions.GetAllDrugStore:
                                        _drugStoreController.GetAll();
                                        break;
                                    case (int)DrugStoreOptions.GetAllDrugStoreByOwner:
                                        _drugStoreController.GetAllDrugStoreByOwner();
                                        break;
                                    case (int)DrugStoreOptions.Sale:
                                        _drugStoreController.Sale();
                                        break;
                                    case (int)DrugStoreOptions.BackToMainMenu:
                                        goto mainMenu;
                                        break;

                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "The number you selected is not available");
                                goto opppp;
                            }
                        }
                        else if (selectedNumber == 5)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Creat Owner");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update Owner");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "3 - Delete Owner");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "4 - Get All Owner");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "0 - Back To Main Menu");

                            Console.WriteLine("----------------------------------------------------------");

                        oppppp: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Select Options:");
                            number = Console.ReadLine();

                            result = int.TryParse(number, out selectedNumber);

                            if (selectedNumber >= 0 && selectedNumber <= 4)
                            {
                                switch (selectedNumber)
                                {
                                    case (int)OwnerOptions.CreateOwner:
                                        _ownerController.CreateOwner();
                                        break;
                                    case (int)OwnerOptions.UpdateOwner:
                                        _ownerController.UpdateOwner();
                                        break;
                                    case (int)OwnerOptions.DeleteOwner:
                                        _ownerController.DeleteOwner();
                                        break;
                                    case (int)OwnerOptions.GetAllOwner:
                                        _ownerController.GetAll();
                                        break;
                                    case (int)OwnerOptions.BackToMainMenu:
                                        goto mainMenu;
                                        break;

                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "The number you selected is not available");
                                goto oppppp;
                            }
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format number");
                        goto selectNumber;
                    }

                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct password and username");
                goto adminUserName;
            }




















        }



    }
}