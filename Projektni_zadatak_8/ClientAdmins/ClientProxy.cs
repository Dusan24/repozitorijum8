using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.ServiceModel;

namespace ClientAdmins
{
    public class ClientProxy : ChannelFactory<IAuthentificationService>, IAuthentificationService
    {
        IAuthentificationService factory;

        public ClientProxy(NetTcpBinding binding, string address) : base(binding, address)
        {
            factory = this.CreateChannel();
        }
        public bool Login(string username, string password)
        {
            bool result;
            try
            {
                result=factory.Login(username, password);
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
