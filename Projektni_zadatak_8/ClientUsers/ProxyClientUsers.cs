using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace ClientUsers
{

    public class ProxyClientUsers : ChannelFactory<IAuthentificationService>, IAuthentificationService
    {

        string key;
        IAuthentificationService factory;

        public ProxyClientUsers(NetTcpBinding binding, string address) : base(binding, address)

        {
           
            factory = this.CreateChannel();

            RSACryptoServiceProvider rsa =(RSACryptoServiceProvider)CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, "authentificationservice").PublicKey.Key;
            byte[] b;
            new RNGCryptoServiceProvider().GetBytes(b = new byte[20]);
            byte[] encrypted_key = rsa.Encrypt(b,false);
            SendKey(encrypted_key);
            key = Convert.ToBase64String(encrypted_key);
        }

      

        public bool Login(string username, string password)
        {
            bool result;
            
                try
                {


                    result = factory.Login(RC4.Encrypt(key, username), RC4.Encrypt(key, password));
                    if (result)
                        Console.WriteLine("Login successful");
                    return result;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: {0}", e.Message);
                    return false;
                }
            }
        

        public bool Logout(string username)
        {
            bool result;
            try
            {
                result = factory.Logout(RC4.Encrypt(key, username));
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
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
