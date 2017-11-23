﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.ServiceModel;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Security.Cryptography;

namespace AutentificationServiceProject
{
    class AuthentificationService : IAuthentificationService
    {
        byte[] rc4key;
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

        public RSACryptoServiceProvider GetPublicKey()
        {
            return (RSACryptoServiceProvider)CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, "authentificationservice").PublicKey.Key;
        }

        public bool Login(string username, string password)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            bool result = false;

            if (principal.IsInRole(Permissions.Login.ToString()))
            {

                result = p.Login(username, password);
            }
            else
            {
                Console.WriteLine("User not authorized!");
                result = false;
            }

            return result;
        }

        public bool Logout(string username)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            bool result = false;

            if (principal.IsInRole(Permissions.Logout.ToString()))
            {

                result =  p.Logout(username);

            }
            else
            {
                Console.WriteLine("User not authorized!");
                result = false;
            }
            return result;
        }

        public bool SendKey(byte[] key)
        {
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, "authentificationservice").PrivateKey;
            rc4key = rsa.Decrypt(key,false);
            return true;
        }
    }
}
