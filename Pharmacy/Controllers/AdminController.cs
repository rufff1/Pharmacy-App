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
    public class AdminController
    {
        private AdminRepository _adminRepositories;
        public AdminController()
        {
            _adminRepositories = new AdminRepository();
        }

        #region Authenticate
        public Admin Authenticate()
        {
           
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "enter admin username:");
            string userName = Console.ReadLine();

            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "enter admin password:");
            string password = Console.ReadLine();

            var admin = _adminRepositories.Get(a => a.UserName.ToLower() == userName.ToLower()
                                             && PasswordHasher.Decrypt(a.Password) == password);
            return admin;
        

        }


        #endregion




    }
}
