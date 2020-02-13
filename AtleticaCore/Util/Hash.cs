using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AtleticaCore.Util
{
    public class Hash
    {
        public string CryptByCore(string password, string salt)
        {


            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password : password,
                salt: Encoding.UTF8.GetBytes(salt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256/8
            ));

            return hashedPassword;
        }

        public string SaltCreate()
        {
            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
                return Convert.ToBase64String(salt);
            }
        }
        
        public bool ValidatePassword(string currentPassword, string salt, string storedPassword)
        {
            var encryptedPassword = CryptByCore(currentPassword,salt);
            
            return encryptedPassword == storedPassword;
        }

        
    }
}
