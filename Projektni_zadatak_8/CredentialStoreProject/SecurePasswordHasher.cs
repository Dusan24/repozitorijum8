using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CredentialStoreProject
{
    public sealed class SecurePasswordHasher
    {
        /// <summary>
        /// Size of salt
        /// </summary>
        private const int SaltSize = 16;

        /// <summary>
        /// Size of hash
        /// </summary>
        private const int HashSize = 20;

        /// <summary>
        /// Creates a hash from a password
        /// </summary>
        /// <param name="password">the password</param>
        /// <param name="iterations">number of iterations</param>
        /// <returns>the hash</returns>
        public static string Hash(string password)
        {
            HashAlgorithm hash;
            //create salt
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

            //create hash
            hash = new SHA256Managed();
            var hashVal = ASCIIEncoding.UTF8.GetBytes(password);


            //combine salt and hash
            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hashVal, 0, hashBytes, SaltSize, HashSize);

            hash.ComputeHash(hashBytes);

            //convert to base64
            var base64Hash = Convert.ToBase64String(hashBytes);
            var retVal = String.Concat(hashBytes, salt);
            //format hash with extra information
            return retVal;
        }

        /// <summary>
        /// verify a password against a hash
        /// </summary>
        /// <param name="password">the password</param>
        /// <param name="hashedPassword">the hash</param>
        /// <returns>could be verified?</returns>
        public static bool Verify(string password, string hashedPassword)
        {


            //extract iteration and Base64 string
            byte[] pass = ASCIIEncoding.UTF8.GetBytes(password);
            byte[] hashpass = ASCIIEncoding.UTF8.GetBytes(hashedPassword);

            byte[] hash = new byte[HashSize];
            byte[] salt = new byte[SaltSize];

            Array.Copy(hashpass, hash, HashSize);
            Array.Copy(hashpass, HashSize, salt, 0, SaltSize);

            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(pass, 0, hashBytes, SaltSize, HashSize);

            HashAlgorithm hashalg;
            hashalg = new SHA256Managed();
            byte[] newhash= hashalg.ComputeHash(hashBytes);

            return (hashpass.SequenceEqual(newhash));

            
        }
    }
}
