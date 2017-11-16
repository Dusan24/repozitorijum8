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
        public SecurePasswordHasher hasher = new SecurePasswordHasher();
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
            if (users.ContainsKey(username))
            {
                users.Remove(username);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DisableAccount(string username)
        {
            if(users.ContainsKey(username))
            {
                if(users[username].Enabled == true)
                {
                    users[username].Enabled = false;
                    return true;
                }
                else
                {
                    return true;
                }
            }
            else
            {

                return false;
            }
        }

        public bool EnableAccount(string username)
        {
            if (users.ContainsKey(username))
            {
                if (users[username].Enabled == false)
                {
                    users[username].Enabled = true;
                    return true;
                }
                else
                {
                    return true;
                }
            }
            else
            {

                return false;
            }
        }

        public bool LockAccount(string username)
        {
            if (users.ContainsKey(username))
            {
                if (users[username].Locked == false)
                {
                    users[username].Locked = true;
                    return true;
                }
                else
                {
                    return true;
                }
            }
            else
            {

                return false;
            }
        }
    }
}
