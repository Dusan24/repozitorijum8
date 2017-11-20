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
                p.CreateAccount("user1","123");
=======

         

>>>>>>> 634f1cdeb83fd7a18c21cdd9bac4247a4b2ba2ff
                Console.ReadKey();
            }


        }
    }
}
