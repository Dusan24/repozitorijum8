using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace AutentificationServiceProject
{
    class AuthentificationService : IAuthentificationService
    {
        public bool Login(string username, string password)
        {
            Console.WriteLine("Hello.");
            return true;
        }

        public bool Logout(string username)
        {
            Console.WriteLine("Hello.");
            return true;
        }

        
    }
}
