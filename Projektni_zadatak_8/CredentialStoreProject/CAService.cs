using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CredentialStoreProject
{
	class CAService : IAuthentificationService
	{
        public RSACryptoServiceProvider GetPublicKey()
        {
            throw new NotImplementedException();
        }

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
    class CAService : IAuthentificationService
    {



        public bool Login(string username, string password)
        {
            User us;
            if (CredentialService.users.TryGetValue(username, out us))
            {
                if (!us.Locked)
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
                        Audit.WriteEntry1("[LOGIN]Wrong password!");
                        Console.WriteLine("Login not successful.");
                        if (us.Count >= 2)
                        {

                            us.Locked = true;
                            Audit.WriteEntry1("[LOGIN]User is locked");
                            Console.WriteLine("User is locked");
                            Task t = new Task(() =>
                            {
                                Console.WriteLine("hey1");
                                Thread.Sleep(10000);
                                us.Locked = false;
                                Console.WriteLine("hey2");

                            });
                            t.Start();

                            return false;
                        }
                        return false;
                    }
                }
                else
                {

                    /*  Audit.WriteEntry1("[LOGIN]User is locked!");
                      Task t = new Task(() =>
                      {
                          Console.WriteLine("hey3");
                          Thread.Sleep(1000);
                          us.Locked = false;
                          Console.WriteLine("hey4");
                      });
                      t.Start();
                      */
                    return false;
                }
            }
            else
            {
                Console.WriteLine("[LOGIN]User doesn't exist.");
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
                Console.WriteLine("[LOGOUT]User doesnt exist.");
                return false;
            }


		}

        public bool SendKey(byte[] key)
        {
            throw new NotImplementedException();
        }
    }
	}
        }
    }
}
	

