using Common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Policy;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;

namespace CredentialStoreProject
{
    class Program
    {
        static void Main(string[] args)
        {

           

            NetTcpBinding binding = new NetTcpBinding();
            ServiceHost host1 = new ServiceHost(typeof(CredentialService));
            host1.AddServiceEndpoint(typeof(IAccountManagement), binding,string.Format(ServiceAddresses.CredentialServiceAddress,"localhost"));

            

            host1.Authorization.ServiceAuthorizationManager = new CustomAuthorizationManager();
            
            List<IAuthorizationPolicy> policies = new List<IAuthorizationPolicy>();
            policies.Add(new CustomAuthorizationPolicy());
            host1.Authorization.ExternalAuthorizationPolicies = policies.AsReadOnly();
            host1.Authorization.PrincipalPermissionMode = System.ServiceModel.Description.PrincipalPermissionMode.Custom;

            host1.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            host1.Description.Behaviors.Add(new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });


            ServiceSecurityAuditBehavior newAudit = new ServiceSecurityAuditBehavior();
            newAudit.AuditLogLocation = AuditLogLocation.Application;
            newAudit.ServiceAuthorizationAuditLevel = AuditLevel.SuccessOrFailure;
            newAudit.SuppressAuditFailure = true;

            host1.Description.Behaviors.Remove<ServiceSecurityAuditBehavior>();
            host1.Description.Behaviors.Add(newAudit);

            host1.Open();
   
        
             Console.WriteLine("CredentialStore service started at {0}",Functions.GetLocalIPAddress());

  


            ServiceHost host2 = new ServiceHost(typeof(CAService));
            host2.AddServiceEndpoint(typeof(IAuthentificationService), binding,string.Format( ServiceAddresses.CA,"localhost"));
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;

            host2.Credentials.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.Custom;
            host2.Credentials.ClientCertificate.Authentication.CustomCertificateValidator = new ServiceCertValidator();

            host2.Credentials.ClientCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;
            host2.Credentials.ServiceCertificate.Certificate = CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, "credentialstore");

            newAudit = new ServiceSecurityAuditBehavior();
            newAudit.AuditLogLocation = AuditLogLocation.Application;
            newAudit.ServiceAuthorizationAuditLevel = AuditLevel.SuccessOrFailure;
            newAudit.SuppressAuditFailure = true;

            host2.Description.Behaviors.Remove<ServiceSecurityAuditBehavior>();
            host2.Description.Behaviors.Add(newAudit);

            host2.Open();
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
            

            host1.Close();
            host2.Close();

           
            


        }
    }
}
