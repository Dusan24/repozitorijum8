using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.ServiceModel;
using System.Security.Cryptography.X509Certificates;

namespace AutentificationServiceProject
{
    class AuthentificationService : IAuthentificationService
    {

        ProxyClientUsers2 p = StartProxy();
        Dictionary<string, User> users = new Dictionary<string, User>();

        static ProxyClientUsers2 StartProxy()
        {
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;
            X509Certificate2 srvCert = CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, "credentialstore");
            EndpointAddress address = new EndpointAddress(new Uri(ServiceAddresses.CA),
                                      new X509CertificateEndpointIdentity(srvCert));
            return new ProxyClientUsers2(binding, address);
            
        }

        public bool Login(string username, string password)
        {
            return p.Login(username,password);
        }

        public bool Logout(string username)
        {


            return p.Logout(username);
        }

        
    }
}
