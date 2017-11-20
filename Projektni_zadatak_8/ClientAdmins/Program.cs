using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace ClientAdmins
{
    class Program
    {
        static void Main(string[] args)
        {
            NetTcpBinding tb = new NetTcpBinding();



            using (ProxyClientAdmins p = new ProxyClientAdmins(tb, ServiceAddresses.CredentialServiceAddress))
            {

<<<<<<< HEAD
=======
                p.CreateAccount("user1","123");

>>>>>>> fd0d138cd22cecc452e471047c780443175f2704
                Console.ReadKey();
            }


        }
    }
}
