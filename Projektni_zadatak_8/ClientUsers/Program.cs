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
				while (true)
				{
					string LoggedIn = string.Empty;





					Console.WriteLine("**************************");
					Console.WriteLine("Options:");
					Console.WriteLine("1.Login:");
					Console.WriteLine("2.Logout:");
					Console.WriteLine("3.EXIT");
					Console.WriteLine("**************************");

					int choice = Convert.ToInt32(Console.ReadLine());
					if (choice == 3)
					{

						break;
					}



					p.Login("user1", "pas1");
					p.Logout("user1");

					switch (choice)
					{
						case 1:
							Console.WriteLine("Enter username: ");
							string a = Console.ReadLine();
							Console.WriteLine("Enter password: ");
							string b = Console.ReadLine();

							if (p.Login(a, b) == true)
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

							if (p.Logout(LoggedIn) == true)
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

				}

                
            }
        }
    }
}
