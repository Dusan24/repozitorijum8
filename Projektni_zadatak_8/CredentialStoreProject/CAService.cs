using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace CredentialStoreProject
{


    class CAService : IAuthentificationService
    {


        public bool Login(string username, string password)
        {
            User us;

            if (CredentialService.users.TryGetValue(username, out us))
            {
                if (us.Enabled)
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
                            Console.WriteLine("Login failed.");
                            if (us.Count >= 5)

                            {

                                Audit.WriteEntry2(String.Format(("Locking the account{0}"), us.Username));
                                us.Locked = true;
                                
                                Task t = new Task(() =>
                                {
                                    Thread.Sleep(300000);
                                    us.Locked = false;

                                });
                                t.Start();


                            }
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("[LOGIN]User is locked!");
                        Audit.WriteEntry2("[LOGIN]Attempting to login into locked account!");
                        return false;
                    }

                }
                else
                {
                    Console.WriteLine("[LOGIN]User is disabled!");
                    Audit.WriteEntry2("[LOGIN]Attempting to login into disabled account!");
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
                Audit.WriteEntry1("[LOGOUT]Logout successful");
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