using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ClientUsers
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD


            NetTcpBinding tb = new NetTcpBinding();


            using (ProxyClientUsers p = new ProxyClientUsers(tb, "net.tcp://localhost:9999/AuthentificationService"))
            {
            
                p.Login("user1","pas1");
                p.Logout("user1");
                Console.ReadKey();
            }

=======

>>>>>>> origin/UN95_1

        }
    }
}
