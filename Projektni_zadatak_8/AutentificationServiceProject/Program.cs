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
            
            string address = "net.tcp://localhost:9999/AuthentificationService";

            ServiceHost host = new ServiceHost(typeof(AuthentificationService));
            host.AddServiceEndpoint(typeof(IAuthentificationService), binding, address);


            host.Open();

            Console.ReadLine();


            host.Close();

        }
    }
}
