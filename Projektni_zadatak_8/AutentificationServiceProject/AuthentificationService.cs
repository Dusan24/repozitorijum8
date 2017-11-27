using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.ServiceModel;

namespace AutentificationServiceProject
{
    class AuthentificationService : IAuthentificationService
    {
        ProxyClientUsers2 p = new ProxyClientUsers2(new NetTcpBinding(), ServiceAddresses.CA);
        Dictionary<string, User> users = new Dictionary<string, User>();

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
