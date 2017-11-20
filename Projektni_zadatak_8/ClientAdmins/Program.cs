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


<<<<<<< HEAD
            using (ProxyClientAdmins p = new ProxyClientAdmins(tb, ServiceAddresses.CredentialServiceAddress))
            {
=======
            using (ProxyClientAdmins p = new ProxyClientAdmins(tb, "net.tcp://localhost:9999/CredentialService"))
            {


>>>>>>> VV-
                Console.ReadKey();
            }


        }
    }
}
