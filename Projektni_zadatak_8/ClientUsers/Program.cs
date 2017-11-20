﻿using System;
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

                p.Login("user1","123");
                p.Logout("user1");


                Console.WriteLine("Unesite korisnicko ime: ");
                string a = Console.ReadLine();
                Console.WriteLine("Unesite lozinku: ");
                string b = Console.ReadLine();

                p.Login(a,b);

            
                p.Login("user1","pas1");
                p.Logout("user1");

                Console.ReadKey();
            }
        }
    }
}
