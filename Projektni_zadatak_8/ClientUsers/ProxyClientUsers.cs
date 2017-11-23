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

        byte[] key;
        IAuthentificationService factory;

        public ProxyClientUsers(NetTcpBinding binding, string address) : base(binding, address)

        {
            factory = this.CreateChannel();

            RSACryptoServiceProvider rsa =(RSACryptoServiceProvider) GetCertificate().Key;
            new RNGCryptoServiceProvider().GetBytes(key = new byte[20]);
            byte[] encrypted_key = rsa.Encrypt(key,false);
            SendKey(encrypted_key);
         
        }

        public PublicKey GetCertificate()
        {
            try
            {
                PublicKey result = factory.GetCertificate();
                if (result!=null)
                    Console.WriteLine("Get public key successful");
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                return null;
            }
        }

        public bool Login(string username, string password)
        {
            bool result;
            
                try
                {
                    result = factory.Login(username, password);
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
                result = factory.Logout(username);
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
