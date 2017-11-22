using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;
using System.ServiceModel.Description;

namespace AutentificationServiceProject
{
    class Program
    {
        static void Main(string[] args)
        {


            NetTcpBinding binding = new NetTcpBinding();
            



            string address = ServiceAddresses.AuthentificationServiceAddress;



            ServiceHost host = new ServiceHost(typeof(AuthentificationService));
            host.AddServiceEndpoint(typeof(IAuthentificationService), binding, address);

            ServiceSecurityAuditBehavior newAudit = new ServiceSecurityAuditBehavior();
            newAudit.AuditLogLocation = AuditLogLocation.Application;
            newAudit.ServiceAuthorizationAuditLevel = AuditLevel.SuccessOrFailure;
            newAudit.SuppressAuditFailure = true;

            host.Description.Behaviors.Remove<System.ServiceModel.Description.ServiceSecurityAuditBehavior>();
            host.Description.Behaviors.Add(newAudit);

            host.Open();

            Console.ReadLine();

            host.Close();

        }
    }
}
