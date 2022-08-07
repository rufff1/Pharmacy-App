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
    public class DruggistController
    {
        private DruggistRepository _druggistRepository;
        private DrugStoreRepository _drugstoreRepository;
        public DruggistController()
        {
            _druggistRepository = new DruggistRepository();
            _drugstoreRepository = new DrugStoreRepository();

        }
        #region CreateDruggist
        public void CreateDruggist()
        {
            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please Enter Druggist Name:");
                string druggistName = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please Enter Druggist Surname:");
                string druggistSurname = Console.ReadLine();
            age: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please Enter Druggist Age:");
                string druggistAge = Console.ReadLine();
                byte age;
                bool result = byte.TryParse(druggistAge, out age);
                if (result)
                {
                experience: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please Enter Druggist Experience:");
                    string druggistExperience = Console.ReadLine();
                    double experience;
                    result = double.TryParse(druggistExperience, out experience);
                    if (age > experience)
                    {

                    if (result)
                    {
                    allstore: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All DrugStores:");
                        foreach (var drugstore in drugstores)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drugstore.Id} Name:{drugstore.Name} Owner:{drugstore.Owner.Name}");
                        }
                    id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please Enter DrugStore Id:");
                        string drugstoreId = Console.ReadLine();
                        int id;
                        result = int.TryParse(drugstoreId, out id);
                        if (result)
                        {
                            var drugstore = _drugstoreRepository.Get(d => d.Id == id);
                            if (drugstore != null)
                            {
                                var druggist = new Druggist()
                                {
                                    Name = druggistName,
                                    Surname = druggistSurname,
                                    Age = age,
                                    Experience = experience,
                                    DrugStore = drugstore,


                                };
                                drugstore.Druggists.Add(druggist);
                                _druggistRepository.Create(druggist);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{druggist.Id} Name:{druggist.Name} Age:{druggist.Age} Experience:{druggist.Experience} Drugstore:{druggist.DrugStore.Name}");

                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drugstore id doesn't exist");
                                goto allstore;
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
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format experience");
                        goto experience;
                    }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format experience");
                        goto experience;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please Enter correct format age");
                    goto age;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugstore");
            }
        }
        #endregion

        #region UpdateDruggist
        public void UpdateDruggist()
        {
            var druggists = _druggistRepository.GetAll();
            var drugstores = _drugstoreRepository.GetAll();
            if (druggists.Count > 0)
            {
            all: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Druggist:");
                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{druggist.Id} Name:{druggist.Name} Age:{druggist.Age} Experience:{druggist.Experience} ");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please Enter Druggist Id:");
                string druggistId = Console.ReadLine();
                int id;
                bool result = int.TryParse(druggistId, out id);
                if (result)
                {
                    var druggist = _druggistRepository.Get(d => d.Id == id);
                    if (druggist != null)
                    {
                        string oldname = druggist.Name;
                        string oldsurname = druggist.Surname;
                        byte oldage = druggist.Age;
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter New Druggist Name:");
                        string newName = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter New Druggist Surname:");
                        string newSurname = Console.ReadLine();
                    age: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter New Druggist Age:");
                        string newAge = Console.ReadLine();
                        byte age;
                        result = byte.TryParse(newAge, out age);
                        if (result)
                        {
                        experience: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter New Druggist Experience:");
                            string newExperience = Console.ReadLine();
                            double experience;
                            result = double.TryParse(newExperience, out experience);
                            if (age > experience)
                            {


                                if (result)
                                {
                                alll: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Drugstores");
                                    foreach (var drugstore in drugstores)
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drugstore.Id} Name:{drugstore.Name}");
                                    }
                                idd: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter DrugStore Id:");
                                    string drugstoreId = Console.ReadLine();
                                    int storeid;
                                    result = int.TryParse(drugstoreId, out storeid);
                                    if (result)
                                    {
                                        var drugstore = _drugstoreRepository.Get(d => d.Id == storeid);
                                        if (drugstore != null)
                                        {
                                            var newDruggist = new Druggist
                                            {
                                                Id = id,
                                                Name = newName,
                                                Surname = newSurname,
                                                Age = age,
                                                Experience = experience,
                                                DrugStore = drugstore,

                                            };

                                            _druggistRepository.Update(newDruggist);
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"OldName:{oldname} OldSurname:{oldsurname} OldAge:{oldage} IS Successfully Update to:Id:{id} NewName:{newDruggist.Name} NewSurname:{newDruggist.Surname} NewAge:{newDruggist.Age} NewExperience:{newDruggist.Experience} NewDrugstore:{newDruggist.DrugStore.Name}");
                                        }
                                        else
                                        {
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drugstore id doesn't exist");
                                            goto alll;
                                        }
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format id");
                                        goto idd;
                                    }

                                }

                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please enter correct format experience");
                                    goto experience;
                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please enter correct format experience");
                                goto experience;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please enter correct format age");
                            goto age;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This druggist doesn't exist");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any druggist");
            }
        }
        #endregion

        #region DeleteDruggist
        public void DeleteDruggist()
        {
            var druggists = _druggistRepository.GetAll();

            if (druggists.Count > 0)
            {
            all: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Druggist:");
                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{druggist.Id} Name:{druggist.Name} Surname:{druggist.Surname} Experience:{druggist.Experience}");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please Enter Druggist Id:");
                string druggistId = Console.ReadLine();
                int id;
                bool result = int.TryParse(druggistId, out id);
                if (result)
                {
                    var druggist = _druggistRepository.Get(d => d.Id == id);
                    if (druggist != null)
                    {
                        _druggistRepository.Delete(druggist);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{druggist.Id} is deleted.");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This druggist id doesn't exist");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any Druggist");
            }
        }
        #endregion

        #region  GetAllDruggist
        public void GetAllDruggist()
        {
            var druggists = _druggistRepository.GetAll();
            if (druggists.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Druggist:");
                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{druggist.Id} Name:{druggist.Name} Surname:{druggist.Surname} Age:{druggist.Age} Experience:{druggist.Experience} ");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any druggist");
            }
        }


        #endregion

        #region GetAllDruggistByDrugStore
        public void GetAllDruggistByDrugStore()
        {

            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
            all: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All DrugStores:");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drugstore.Id} Name:{drugstore.Name} Adress:{drugstore.Adresss} ContactNumber:{drugstore.ContactNumber} ");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please Enter Drugstore Id:");
                string drugstoreId = Console.ReadLine();
                int id;
                bool result = int.TryParse(drugstoreId, out id);
                if (result)
                {
                    var drugstore = _drugstoreRepository.Get(d => d.Id == id);
                    if (drugstore != null)
                    {
                        var druggists = _druggistRepository.GetAll(d => d.DrugStore.Id == drugstore.Id);
                        if (druggists.Count != 0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Druggist To DrugStore:");
                            foreach (var druggist in druggists)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{druggist.Id} Name:{druggist.Name} Surname:{druggist.Surname} Age:{druggist.Age}");
                            }

                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This Drugstore are not druggists");
                            goto all;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drugsore id doesn't exist");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any Drugstore");
            }
        }
        #endregion
    }



}
