using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;

namespace AutentificationServiceProject
{
    class Program
    {
        static void Main(string[] args)
        {


            NetTcpBinding binding = new NetTcpBinding();

<<<<<<< HEAD
            string address = "net.tcp://localhost:9998/AuthentificationService";
=======
<<<<<<< HEAD
            string address = ServiceAddresses.AuthentificationServiceAddress;
=======
=======
>>>>>>> VV-
            string address = "net.tcp://localhost:9999/AuthentificationService";
>>>>>>> f403349710b781f74f2a0c8c1800f8086db60e81
>>>>>>> dfc009ac567ffc0b706f917df720d014f688a5de

            ServiceHost host = new ServiceHost(typeof(AuthentificationService));
            host.AddServiceEndpoint(typeof(IAuthentificationService), binding, address);


            host.Open();

            Console.ReadLine();

            host.Close();

        }
    }
}
