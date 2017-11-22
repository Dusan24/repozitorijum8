﻿using System.Collections.Generic;
using Common;
using System.Resources;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace CredentialStoreProject
{
    public class CredentialService : IAccountManagement
    {
        const string file_name = "data";
        public static Dictionary<string, User> users = Load();

        private static Dictionary<string, User> Load()
        {
            if(!File.Exists(file_name))
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


            if (principal.IsInRole(Permissions.CreateAccount.ToString()))
            {
                if (!users.ContainsKey(username))
                {

                    User a = new User(username, password);
                    users.Add(a.Username, a);
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

        public bool DeleteAccount(string username)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;


            if (principal.IsInRole(Permissions.DeleteAccount.ToString()))
            {
                    if (users.ContainsKey(username))
                    {
                        users.Remove(username);
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


            if (principal.IsInRole(Permissions.DisableAccount.ToString()))
            {
                if (users.ContainsKey(username))
                {
                    if(users[username].Enabled == true)
                    {
                        users[username].Enabled = false;
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


            if (principal.IsInRole(Permissions.EnableAccount.ToString()))
            {
                if (users.ContainsKey(username))
                {
                    if (users[username].Enabled == false)
                    {
                        users[username].Enabled = true;
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


            if (principal.IsInRole(Permissions.LockAccount.ToString()))
            {
                if (users.ContainsKey(username))
                {
                    if (users[username].Locked == false)
                    {
                        users[username].Locked = true;
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
    }
}
