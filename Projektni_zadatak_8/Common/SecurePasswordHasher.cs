using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class SecurePasswordHasher
    {


        private const int SaltSize = 16;
		

<<<<<<< HEAD
=======

       


>>>>>>> f737c04a637b9e30d84160a93e8a0e3bb5c858f4
    
        public static string Hash(string password)
        {

            HashAlgorithm hash_alg = new SHA256Managed();
           

            byte[] byte_salt;
            new RNGCryptoServiceProvider().GetBytes(byte_salt = new byte[SaltSize]);
            string salt = Convert.ToBase64String(byte_salt);


            string for_hashing = password + salt;
            string hashed_password = Convert.ToBase64String(hash_alg.ComputeHash(ASCIIEncoding.UTF8.GetBytes(for_hashing)));
            string salted_hashed_password = hashed_password + salt;

            return salted_hashed_password;
<<<<<<< HEAD



        }




           

        

       
=======
			 }
>>>>>>> f737c04a637b9e30d84160a93e8a0e3bb5c858f4

        public static bool Verify(string password, string hashedPassword)
        {

            HashAlgorithm hash_alg = new SHA256Managed();


            string salt = hashedPassword.Substring(hashedPassword.Length - SaltSize - 8);
            string forhashing = password + salt;

            string hashedpasword1 = Convert.ToBase64String(hash_alg.ComputeHash(ASCIIEncoding.UTF8.GetBytes(forhashing)));



            string hashedpasword2 = hashedPassword.Substring(0, hashedPassword.Length - SaltSize - 8);



            return hashedpasword1 == hashedpasword2;

        }


    }
}
