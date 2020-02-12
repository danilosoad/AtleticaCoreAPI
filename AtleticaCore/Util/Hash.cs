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
        public string CryptByCore(string password)
        {
            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password : password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256/8
            ));

            return hashedPassword;
        }

        public bool CheckHashedPassword(string currentPassword, string storedPassword)
        {
            var encryptedPassword = CryptByCore(currentPassword);

            return encryptedPassword == storedPassword;
        }
    }
}
