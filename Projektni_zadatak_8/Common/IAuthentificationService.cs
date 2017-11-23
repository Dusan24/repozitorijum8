using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Security.Cryptography;

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
        RSACryptoServiceProvider GetPublicKey();

        [OperationContract]
        bool SendKey(byte[] key);
    }
}



