using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AutentificationServiceProject
{

    public class ProxyClientUsers2 : ChannelFactory<IAuthentificationService>, IAuthentificationService
    {

       
        IAuthentificationService factory;

        public ProxyClientUsers2(NetTcpBinding binding, EndpointAddress address) : base(binding, address)

        {
            this.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.Custom;
            this.Credentials.ServiceCertificate.Authentication.CustomCertificateValidator = new ClientCertValidator();
            this.Credentials.ServiceCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;

            this.Credentials.ClientCertificate.Certificate = CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, "authentificationservice");

            factory = this.CreateChannel();

        }

        public RSACryptoServiceProvider GetCertificate()
        {
            throw new NotImplementedException();
        }

        public bool Login(string username, string password)
        {
            bool result;
            try
            {
                result = factory.Login(username, password);
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
            throw new NotImplementedException();
        }
    }
}
