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
            NetTcpBinding tb = new NetTcpBinding();


            using (ProxyClientUsers p = new ProxyClientUsers(tb,ServiceAddresses.AuthentificationServiceAddress))
            {
<<<<<<< HEAD
<<<<<<< HEAD
=======
                p.Login("user1","pas1");
                p.Logout("user1");
>>>>>>> f403349710b781f74f2a0c8c1800f8086db60e81
<<<<<<< HEAD

                Console.WriteLine("Unesite korisnicko ime: ");
                string a = Console.ReadLine();
                Console.WriteLine("Unesite lozinku: ");
                string b = Console.ReadLine();

                p.Login(a,b);


=======
=======
            
                p.Login("user1","pas1");
                p.Logout("user1");
>>>>>>> parent of f1ae893... Logovanje klijenta
>>>>>>> 634f1cdeb83fd7a18c21cdd9bac4247a4b2ba2ff
                Console.ReadKey();
            }
        }
    }
}
