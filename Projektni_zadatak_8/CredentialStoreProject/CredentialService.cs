using System.Collections.Generic;
using Common;
using System.Resources;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace CredentialStoreProject
{
    public class CredentialService : IAccountManagement
    {
        const string file_name = "data";
        string rc4key;
        public static Dictionary<string, User> users = Load();

        private static Dictionary<string, User> Load()
        {
            if (!File.Exists(file_name))
            {
                return new Dictionary<string, User>();
            }

            FileStream fs = new FileStream(file_name, FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            object obj = bf.Deserialize(fs);
            if (obj.GetType().Equals(typeof(Dictionary<string, User>)))
            {
                fs.Close();
                return (Dictionary<string, User>)obj;
            }
            else
            {

                fs.Close();




                return new Dictionary<string, User>();

            }


        }


        public bool CreateAccount(string username, string password)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;

            string _username = RC4.Decrypt(rc4key, username);
            string _password = RC4.Decrypt(rc4key, password);


            if (principal.IsInRole(Permissions.CreateAccount.ToString()))
            {
                if (!users.ContainsKey(_username))
                {

                    User a = new User(_username, _password);
                    users.Add(a.Username, a);
                    FileStream fs = new FileStream(file_name, FileMode.OpenOrCreate);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, users);
                    fs.Close();
                    return true;
                }
                else
                {
                    Console.WriteLine("User already exists.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Current user not authorized!");
                return false;
            }
        }

        public bool DeleteAccount(string username)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            string _username = RC4.Decrypt(rc4key, username);

            if (principal.IsInRole(Permissions.DeleteAccount.ToString()))
            {
                if (users.ContainsKey(_username))
                {
                    users.Remove(_username);
                    FileStream fs = new FileStream(file_name, FileMode.OpenOrCreate);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, users);
                    fs.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Current user not authorized!");
                return false;
            }
        }

        public bool DisableAccount(string username)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            string _username = RC4.Decrypt(rc4key, username);

            if (principal.IsInRole(Permissions.DisableAccount.ToString()))
            {
                if (users.ContainsKey(_username))
                {
                    if (users[_username].Enabled == true)
                    {
                        users[_username].Enabled = false;
                        FileStream fs = new FileStream(file_name, FileMode.OpenOrCreate);
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, users);
                        fs.Close();
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {

                    return false;
                }
            }
            else
            {
                Console.WriteLine("Current user not authorized!");
                return false;
            }
        }

        public bool EnableAccount(string username)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            string _username = RC4.Decrypt(rc4key, username);

            if (principal.IsInRole(Permissions.EnableAccount.ToString()))
            {
                if (users.ContainsKey(_username))
                {
                    if (users[_username].Enabled == false)
                    {
                        users[_username].Enabled = true;
                        FileStream fs = new FileStream(file_name, FileMode.OpenOrCreate);
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, users);
                        fs.Close();
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {

                    return false;
                }
            }

            else
            {
                Console.WriteLine("Current user not authorized!");
                return false;
            }
        }


    public bool LockAccount(string username)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            string _username = RC4.Decrypt(rc4key, username);



            if (principal.IsInRole(Permissions.LockAccount.ToString()))
            {
                if (users.ContainsKey(_username))
                {
                    if (users[_username].Locked == false)
                    {
                        users[_username].Locked = true;
                        FileStream fs = new FileStream(file_name, FileMode.OpenOrCreate);
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, users);
                        fs.Close();
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {

                    return false;
                }
            }
            else
            {
                Console.WriteLine("Current user not authorized!");
                return false;
            }
        }

        public bool SendKey(byte[] key)
        {
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, "credentialstore").PrivateKey;
            rc4key = Convert.ToBase64String(rsa.Decrypt(key, false));

            return true;
        }
    }
}
