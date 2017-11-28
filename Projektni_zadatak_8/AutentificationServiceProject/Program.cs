using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;
using System.IdentityModel.Policy;
using System.ServiceModel.Description;
using System.Security.Cryptography.X509Certificates;

namespace AutentificationServiceProject
{
    class Program
    {
        static void Main(string[] args)
        {

            
            NetTcpBinding binding = new NetTcpBinding();

            string address =string.Format( ServiceAddresses.AuthentificationServiceAddress,"localhost");
            Console.WriteLine("Enter Server IP:");
            AuthentificationService.ip=Console.ReadLine();
            ServiceHost host = new ServiceHost(typeof(AuthentificationService));
            host.AddServiceEndpoint(typeof(IAuthentificationService), binding, address);

            

            ServiceSecurityAuditBehavior newAudit = new ServiceSecurityAuditBehavior();
            newAudit.AuditLogLocation = AuditLogLocation.Application;
            newAudit.ServiceAuthorizationAuditLevel = AuditLevel.SuccessOrFailure;
            newAudit.SuppressAuditFailure = true;

            host.Description.Behaviors.Remove<ServiceSecurityAuditBehavior>();
            host.Description.Behaviors.Add(newAudit);

            host.Authorization.ServiceAuthorizationManager = new CustomAuthorizationManager();

            List<IAuthorizationPolicy> policies = new List<IAuthorizationPolicy>();
            policies.Add(new CustomAuthorizationPolicy());
            host.Authorization.ExternalAuthorizationPolicies = policies.AsReadOnly();
            host.Authorization.PrincipalPermissionMode = PrincipalPermissionMode.Custom;

            host.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            host.Description.Behaviors.Add(new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });



            host.Open();
            Console.WriteLine("AuthenticationService started at {0}", Functions.GetLocalIPAddress());

            Console.ReadLine();

            host.Close();

        }
    }
}
