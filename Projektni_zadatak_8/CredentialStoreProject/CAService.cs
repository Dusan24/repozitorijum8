﻿using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CredentialStoreProject
{
    class CAService: IAuthentificationService
    {
      
        

        public bool Login(string username, string password)
        {
            User us;
           if( CredentialService.users.TryGetValue(username,out us))
            {
                if (SecurePasswordHasher.Verify(password, us.Password))
                {
                    Console.WriteLine("Login successful.");
                    us.Loged = true;
                    return true;
                }
                else
                {
                    Console.WriteLine("Login not successful.");
                    return false;
                }
            }
           else
            {
                throw new Exception("User doesnt exist.");
            }
        }

        public bool Logout(string username)
        {
            User us;
            if (CredentialService.users.TryGetValue(username, out us))
            {
                us.Loged = true;
                return true;
            }
            else
            {
                throw new Exception("User doesnt exist.");
            }


        }


    }
}
