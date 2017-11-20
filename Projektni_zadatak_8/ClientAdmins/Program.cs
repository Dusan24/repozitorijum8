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

                p.CreateAccount("user1","123");

                Console.ReadKey();
            }


        }
    }
}
