using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Common
{
    [ServiceContract]
    public interface IAuthentificationService
    {
        [OperationContract]
        bool Login(string username,string password);

        [OperationContract]
        bool Logout(string username);
     

        [OperationContract]
        bool SendKey(byte[] key);

     
    }
}



