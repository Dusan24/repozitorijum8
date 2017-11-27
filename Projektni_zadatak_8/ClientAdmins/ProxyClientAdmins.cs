using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientAdmins
{
    public class ProxyClientAdmins : ChannelFactory<IAccountManagement>, IAccountManagement
    {
        IAccountManagement factory;
        string key;

        public ProxyClientAdmins(NetTcpBinding binding, string address) : base(binding, address)
        {
            
            factory = this.CreateChannel();

            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, "credentialstore").PublicKey.Key;
            byte[] byte_key;
            new RNGCryptoServiceProvider().GetBytes(byte_key = new byte[20]);
            byte[] encrypted_key = rsa.Encrypt(byte_key, false);
            SendKey(encrypted_key);
            key = Convert.ToBase64String(byte_key);
            
        }

        public bool CreateAccount(string username, string password)
        {
            bool result;
            try
            {
                string username1 = RC4.Encrypt(key, username);
                string password1 = RC4.Encrypt(key, password);
                result = factory.CreateAccount(username1,password1);
                if (result)
                {
                    Console.WriteLine("Account created succesfully");
                    Audit.WriteEntry1("Account created succesfully");
                }
                return result;
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Account not created succesfully: {0}", e.Message);
                return false;
            }
        }

        public bool DeleteAccount(string username)
        {
            bool result;
            try
            {
                result = factory.DeleteAccount(RC4.Encrypt(key, username));
                if (result)
                    Console.WriteLine("Account deleted succesfully");
                return result;
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Account not delete succesfully: {0}", e.Message);
                return false;
            }
        }


 

        public bool LockAccount(string username)
        {
            bool result;
            try
            {
                
                    result = factory.LockAccount(RC4.Encrypt(key, username));
                if (result)
                    Console.WriteLine("Account locked succesfully");
                return result;
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Account not locked succesfully: {0}", e.Message);
                return false;
            }
        }

        public bool EnableAccount(string username)
        {
            bool result;
            try
            {
                
                    result = factory.EnableAccount(RC4.Encrypt(key, username));
                if (result)
                    Console.WriteLine("Account enabled succesfully");
                return result;
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Account not enabled succesfully: {0}", e.Message);
                return false;
            }
        }

       
        public bool DisableAccount(string username)

        {
            bool result;
            try
            {

                
                    result = factory.DisableAccount(RC4.Encrypt(key, username));
                if (result)
                    Console.WriteLine("Account disabled successfully");
                return result;

                
            }
            catch (Exception e)
            {
                Console.WriteLine("Account not disabled successfully: {0}", e.Message);
                return false;
            }
        }

        public bool SendKey(byte[] key)
        {
            bool result;
            try
            {
                result = factory.SendKey(key);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                return false;
            }
        }
    }
}
