using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ServiceAddresses
    {


        public const  string CredentialServiceAddress = "net.tcp://{0}:27016/CredentialService";
        public const string AuthentificationServiceAddress = "net.tcp://{0}:17/AuthentificationService";
        public const string CA= "net.tcp://{0}:25555/CAService";



    }
}
