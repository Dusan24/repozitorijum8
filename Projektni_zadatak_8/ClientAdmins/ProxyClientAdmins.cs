using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientAdmins
{
    public class ProxyClientAdmins : ChannelFactory<IAccountManagement>, IAccountManagement
    {
        IAccountManagement factory;

        public ProxyClientAdmins(NetTcpBinding binding, string address) : base(binding, address)
<<<<<<< HEAD

=======
>>>>>>> VV-
        {
            factory = this.CreateChannel();
        }

        public bool CreateAccount(string username, string password)
        {
            bool result;
            try
            {
                result = factory.CreateAccount(username, password);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                return false;
            }
        }

        public bool DeleteAccount(string username)
        {
            bool result;
            try
            {
                result = factory.DeleteAccount(username);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                return false;
            }
        }

<<<<<<< HEAD
        public bool DisableAccount(string username)
=======
        public bool LockAccount(string username)
>>>>>>> VV-
        {
            bool result;
            try
            {
<<<<<<< HEAD
                result = factory.DisableAccount(username);
=======
                result = factory.LockAccount(username);
>>>>>>> VV-
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                return false;
            }
        }

        public bool EnableAccount(string username)
        {
            bool result;
            try
            {
                result = factory.EnableAccount(username);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                return false;
            }
        }

<<<<<<< HEAD
        public bool LockAccount(string username)
=======
        public bool DisableAccount(string username)
>>>>>>> VV-
        {
            bool result;
            try
            {
<<<<<<< HEAD
                result = factory.LockAccount(username);
=======
                result = factory.DisableAccount(username);
>>>>>>> VV-
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                return false;
            }
        }
    }
}
