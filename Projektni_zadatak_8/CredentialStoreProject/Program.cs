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

            

            ServiceHost host = new ServiceHost(typeof(CredentialService));
            host.AddServiceEndpoint(typeof(IAccountManagement), binding, ServiceAddresses.CredentialServiceAddress);


            host.Open();

            Console.ReadLine();


            host.Close();

        }
    }
}
