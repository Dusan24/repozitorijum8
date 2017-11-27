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

            Console.WriteLine("Enter Server IP:");
            string ip = Console.ReadLine();
            using (ProxyClientUsers p = new ProxyClientUsers(tb,string.Format(ServiceAddresses.AuthentificationServiceAddress,ip)))
            {

                string LoggedIn = string.Empty;

                while (true)
                {
                   
                    Console.WriteLine("**************************");
                    Console.WriteLine("Options:");
                    Console.WriteLine("1.Login:");
                    Console.WriteLine("2.Logout:");
                    Console.WriteLine("3.Quit:");
                    Console.WriteLine("**************************");

                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 3)
                    {
                        break;
                    }

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
                                Console.WriteLine("User {0} logged in successfully.",LoggedIn);
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
                                Console.WriteLine("User {0} logged out successfully.",LoggedIn);
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
                }

                
            }
        }
    }
}
