using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace CredentialStoreProject
{
	class CAService : IAuthentificationService
	{



		public bool Login(string username, string password)
		{
			User us;
			if (CredentialService.users.TryGetValue(username, out us))
			{
				if (SecurePasswordHasher.Verify(password, us.Password))
				{
					Console.WriteLine("Login successful.");
					us.Loged = true;
                    us.Count = 0;
					return true;
				}
				else
				{
                    us.Count++;
					Console.WriteLine("Login not successful.");
                    if(us.Count >= 5)
                    {
                        us.Locked = true;
                        Console.WriteLine("User is locked");
                        Thread.Sleep(300000);
                    }
					return false;
				}
			}
			else
			{
				Console.WriteLine("User doesn't exist.");
				return false;
			}
		}

		public bool Logout(string username)
		{
			User us;
			if (CredentialService.users.TryGetValue(username, out us))
			{
				us.Loged = false;
				return true;
			}
			else
			{
				Console.WriteLine("User doesnt exist.");
				return false;
			}


		}
		}
	}

