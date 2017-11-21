using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace CredentialStoreProject
{
    class Program
    {
        static void Main(string[] args)
        {

            NetTcpBinding binding = new NetTcpBinding();
            ServiceHost host1 = new ServiceHost(typeof(CredentialService));
            host1.AddServiceEndpoint(typeof(IAccountManagement), binding, ServiceAddresses.CredentialServiceAddress);
            
            host1.Authorization.ServiceAuthorizationManager = new CustomAuthorizationManager();
            host1.Open();



            ServiceHost host2 = new ServiceHost(typeof(CAService));
            host2.AddServiceEndpoint(typeof(IAuthentificationService), binding, ServiceAddresses.CA);
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;

            host2.Credentials.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.Custom;
            host2.Credentials.ClientCertificate.Authentication.CustomCertificateValidator = new ServiceCertValidator();

            host2.Credentials.ClientCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;
            host2.Credentials.ServiceCertificate.Certificate = CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, "credentialstore");

            host2.Open();

            Console.ReadLine();


            host1.Close();
            host2.Close();

        }
    }
}
