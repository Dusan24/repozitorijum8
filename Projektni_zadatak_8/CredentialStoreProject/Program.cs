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
            
            List<IAuthorizationPolicy> policies = new List<IAuthorizationPolicy>();
            policies.Add(new CustomAuthorizationPolicy());
            host1.Authorization.ExternalAuthorizationPolicies = policies.AsReadOnly();
            host1.Authorization.PrincipalPermissionMode = System.ServiceModel.Description.PrincipalPermissionMode.Custom;

            host1.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            host1.Description.Behaviors.Add(new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });
            host1.Open();
            string rel_addr = "..\\..\\..\\..\\AutentificationServiceProject\\bin\\x86\\Debug\\AutentificationServiceProject.exe";

            Process pAtuh = new Process();
            pAtuh.StartInfo.UseShellExecute = false;
            System.Security.SecureString ss = new System.Security.SecureString();
            pAtuh.StartInfo.FileName = rel_addr;
            pAtuh.StartInfo.UserName = "Administrator";
            string pass = "student";
            for (int x = 0; x < pass.Length; x++)
            {
                ss.AppendChar(pass[x]);
            }
            pass = "";
            pAtuh.StartInfo.Password = ss;
            pAtuh.Start();
            //Start(rel_addr);
             Console.WriteLine("CredentialStore service started...");

            Process pAdmin = new Process();
            System.Security.SecureString ssPwd = new System.Security.SecureString();
            pAdmin.StartInfo.UseShellExecute = false;
            string rel_addr1 = "..\\..\\..\\..\\ClientAdmins\\bin\\x86\\Debug\\ClientAdmins.exe";
            pAdmin.StartInfo.UserName = "admin1";
            string password = "123456789";
            for (int x = 0; x < password.Length; x++)
            {
                ssPwd.AppendChar(password[x]);
            }
            pAdmin.StartInfo.FileName = rel_addr1;
            password = "";
            pAdmin.StartInfo.Password = ssPwd;
            pAdmin.Start();


            Process pUser = new Process();
            System.Security.SecureString ssPwd1 = new System.Security.SecureString();
            pUser.StartInfo.UseShellExecute = false;
            string rel_addr2 = "..\\..\\..\\..\\ClientUsers\\bin\\x86\\Debug\\ClientUsers.exe";
            pUser.StartInfo.UserName = "user1";
            string password1 = "123456789";
            for (int x = 0; x < password1.Length; x++)
            {
                ssPwd1.AppendChar(password1[x]);
            }
            pUser.StartInfo.FileName = rel_addr2;
            password1 = "";
            pUser.StartInfo.Password = ssPwd1;
            pUser.Start();

            ServiceHost host2 = new ServiceHost(typeof(CAService));
            host2.AddServiceEndpoint(typeof(IAuthentificationService), binding, ServiceAddresses.CA);
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;

            host2.Credentials.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.Custom;
            host2.Credentials.ClientCertificate.Authentication.CustomCertificateValidator = new ServiceCertValidator();

            host2.Credentials.ClientCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;
            host2.Credentials.ServiceCertificate.Certificate = CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, "credentialstore");

            host2.Open();
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
            

            host1.Close();
            host2.Close();

            pAtuh.Kill();
            pAdmin.Kill();
            pUser.Kill();
            


        }
    }
}
