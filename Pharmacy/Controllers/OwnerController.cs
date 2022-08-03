using Core.Entities;
using Core.Helpers;
using DataAccess.Contexts;
using DataAccess.Impelementations;
using DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    public class OwnerController
    {


        private OwnerRepository _ownerRepository;

        public OwnerController()
        {
            _ownerRepository = new OwnerRepository();
        }


        #region CreateOwner
        public void CreateOwner()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Owner Name:");
            string name = Console.ReadLine();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Owner Surname:");
            string surname = Console.ReadLine();

            var owner = new Owner
            {
                Name = name,
                Surname = surname
            };
            var createdOwner = _ownerRepository.Create(owner);
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{owner.Id} Name:{owner.Name} Surname:{owner.Surname} Owner Successfully Created...");
        }
        #endregion

        #region UpdateOwner
        public void UpdateOwner()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
              all:  ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Owner:");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{owner.Id} Name:{owner.Name} Surname:{owner.Surname}");
                }

               id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please Enter Owner Id");
                string ownerId = Console.ReadLine();
                int id;
                bool result = int.TryParse(ownerId, out id);
                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == id);
                    if (owner != null)
                    {
                        string oldName = owner.Name;
                        string oldSurname = owner.Surname;
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please enter new owner name:");
                        string newName = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please enter new owner surname:");
                        string newsurname = Console.ReadLine();

                        var newOwner = new Owner()
                        {

                            Name = newName,
                            Surname = newsurname,
                        };
                        _ownerRepository.Update(owner);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"OldName:{oldName} OldSurname:{oldSurname}, Owner Successfully Update: NewName:{newOwner.Name} NewSurname:{newOwner.Surname}  ");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This owner doesn't exist");
                        goto all;
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any owner");
            }


        }
        #endregion

        #region DeleteOwner
        public void DeleteOwner()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
            all: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Owners:");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{owner.Id} Name:{owner.Name} Surname:{owner.Surname}");
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
                        _ownerRepository.Delete(owner);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{id} Name:{owner.Name} Surname:{owner.Surname} - This  owner is deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This Owner doesn't exist");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any owner");
            }
        }
        #endregion

        #region GetAll
        public void GetAll()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Owner:");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{owner.Id} Name:{owner.Name} Surname:{owner.Surname}");
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any owner");
            }
        }
        #endregion
    }
}