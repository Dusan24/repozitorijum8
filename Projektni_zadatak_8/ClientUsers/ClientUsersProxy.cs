using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientUsers
{
    public class ProxyClientUsers : ChannelFactory<IAuthentificationService>, IAuthentificationService
    {
        IAuthentificationService factory;

        public ProxyClientUsers(NetTcpBinding binding, string address) : base(binding, address)
        {
            factory = this.CreateChannel();
        }
        public bool Login(string username, string password)
        {
            bool result;
            try
            {
                result = factory.Login(username, password);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                return false;
            }
        }

        public bool Logout(string username)
        {
            bool result;
            try
            {
                result = factory.Logout(username);
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
