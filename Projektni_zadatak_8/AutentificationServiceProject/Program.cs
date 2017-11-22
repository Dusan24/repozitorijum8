﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;
using System.IdentityModel.Policy;
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

            host.Authorization.ServiceAuthorizationManager = new CustomAuthorizationManager();

            List<IAuthorizationPolicy> policies = new List<IAuthorizationPolicy>();
            policies.Add(new CustomAuthorizationPolicy());
            host.Authorization.ExternalAuthorizationPolicies = policies.AsReadOnly();
            host.Authorization.PrincipalPermissionMode = System.ServiceModel.Description.PrincipalPermissionMode.Custom;

            host.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            host.Description.Behaviors.Add(new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });


            host.Open();
            Console.WriteLine("AuthenticationService started...");

            Console.ReadLine();

            host.Close();

        }
    }
}
