using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ServiceAddresses
    {


        public const  string CredentialServiceAddress = "net.tcp://localhost:27016/CredentialService";
        public const string AuthentificationServiceAddress = "net.tcp://localhost:28016/AuthentificationService";
        public const string CA= "net.tcp://localhost:29016/CAService";


    }
}
