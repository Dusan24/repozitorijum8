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
                Console.WriteLine("Account created succesfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Account not created succesfully: {0}", e.Message);
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
                Console.WriteLine("Account delete succesfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Account not delete succesfully: {0}", e.Message);
                return false;
            }
        }


 

        public bool LockAccount(string username)
        {
            bool result;
            try
            {

                result = factory.LockAccount(username);

                return result;
                Console.WriteLine("Account locked succesfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Account not locked succesfully: {0}", e.Message);
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
                Console.WriteLine("Account enabled succesfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Account not enabled succesfully: {0}", e.Message);
                return false;
            }
        }

       
        public bool DisableAccount(string username)

        {
            bool result;
            try
            {


                result = factory.DisableAccount(username);

                return result;

                Console.WriteLine("Account disabled successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Account not disabled successfully: {0}", e.Message);
                return false;
            }
        }
    }
}
