using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CredentialStoreProject
{
    class Program
    {
        static void Main(string[] args)
        {

            NetTcpBinding binding = new NetTcpBinding();
            ServiceHost host1 = new ServiceHost(typeof(CredentialService));
            host1.AddServiceEndpoint(typeof(IAccountManagement), binding, ServiceAddresses.CredentialServiceAddress);
            host1.Open();

            
            ServiceHost host2 = new ServiceHost(typeof(CAService));
            host2.AddServiceEndpoint(typeof(IAuthentificationService), binding, ServiceAddresses.CA);
            host2.Open();


            Console.ReadLine();


            host1.Close();

        }
    }
}
