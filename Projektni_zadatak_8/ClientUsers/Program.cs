using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;
namespace ClientUsers
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
=======


>>>>>>> a943e8219b48bc4efd4a597cc836d34eb705357e
            NetTcpBinding tb = new NetTcpBinding();


            using (ProxyClientUsers p = new ProxyClientUsers(tb,ServiceAddresses.AuthentificationServiceAddress))
            {
            
                p.Login("user1","pas1");
                p.Logout("user1");
                Console.ReadKey();
            }
<<<<<<< HEAD
=======


>>>>>>> a943e8219b48bc4efd4a597cc836d34eb705357e
        }
    }
}
