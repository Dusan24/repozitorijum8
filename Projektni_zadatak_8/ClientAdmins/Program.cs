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


                while(true)

                {

                    Console.WriteLine("**********************");
                    Console.WriteLine("Enter options: ");
                    Console.WriteLine("1.CreateAccount");
                    Console.WriteLine("2.DeleteAccount");
                    Console.WriteLine("3.LockAccount");
                    Console.WriteLine("4.EnableAccount");
                    Console.WriteLine("5.DisableAccount");
                    Console.WriteLine("6.Finish application ");
                    Console.WriteLine("**********************");


                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 6)
                    {
                        break;
                    }
                    switch (choice)
                    {

                        case 1:
                            Console.WriteLine("Enter username");
                            string a1 = Console.ReadLine();
                            Console.WriteLine("Enter password");
                            string b1 = Console.ReadLine();

                            p.CreateAccount(a1, b1);
                            break;
                        case 2:
                            Console.WriteLine("Enter username");
                            string a2 = Console.ReadLine();


                            p.DeleteAccount(a2);

                            break;
                        case 3:
                            Console.WriteLine("Enter username");
                            string a3 = Console.ReadLine();


                            p.LockAccount(a3);
                            break;
                        case 4:

                            Console.WriteLine("Enter username");
                            string a4 = Console.ReadLine();

                            p.EnableAccount(a4);

                            break;

                        case 5:
                            Console.WriteLine("Enter username");
                            string a5 = Console.ReadLine();

                            p.DeleteAccount(a5);

                            break;
                        case 6:
                            break;

                        default:

                            break;
                    }
                } 

                
            }



        }
    }
}

