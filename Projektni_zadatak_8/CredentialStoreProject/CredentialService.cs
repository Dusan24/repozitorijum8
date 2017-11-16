using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace CredentialStoreProject
{
    public class CredentialService : IAccountManagement
    {
        public Dictionary<string, User> users = new Dictionary<string, User>();

        public bool CreateAccount(string username, string password)
        {

            if (!users.ContainsKey(username))
            {
                User a = new User(username, password);
                users.Add(username,a);
                return true;
            }
            else
            {

                return false;
            }
        }

        public bool DeleteAccount(string username)
        {
            throw new NotImplementedException();
        }

        public bool DisableAccount(string username)
        {
            throw new NotImplementedException();
        }

        public bool EnableAccount(string username)
        {
            throw new NotImplementedException();
        }

        public bool LockAccount(string username)
        {
            throw new NotImplementedException();
        }
    }
}
