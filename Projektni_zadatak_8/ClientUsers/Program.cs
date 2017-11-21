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


            using (ProxyClientUsers p = new ProxyClientUsers(tb, ServiceAddresses.AuthentificationServiceAddress))
            {

                string LoggedIn = string.Empty;

                Console.WriteLine("**************************");
                Console.WriteLine("Options:");
                Console.WriteLine("1.Login:");
                Console.WriteLine("2.Logout:");
                Console.WriteLine("**************************");

                int choice = Convert.ToInt32(Console.ReadLine());



            
                

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter username: ");
                        string a = Console.ReadLine();
                        Console.WriteLine("Enter password: ");
                        string b = Console.ReadLine();
                        
                        if (p.Login(a, b))
                        {
                            LoggedIn = a;
                            Console.WriteLine("User logged in successfully.");
                            break;
                        }
                        else
                        {
                            LoggedIn = "";
                            Console.WriteLine("User login failed.");
                            break;
                        }
   
                    case 2:

                        if (p.Logout(LoggedIn))
                        {
                            Console.WriteLine("User logged out successfully.");
                            LoggedIn = "";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("User logout failed.");
                            break;
                        }

                    default:
                        break;


                }


                Console.ReadKey();
            }
        }
    }
}
