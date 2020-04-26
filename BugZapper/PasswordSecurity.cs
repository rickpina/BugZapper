using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BugZapper
{
    public class PasswordSecurity
    {
        public static bool VerifyPassword(string enteredPassword, string storedSalt, string storedHash)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == storedHash;
        }

        public static Models.LoginModel GenerateSaltedHash(Models.LoginModel model, int size, string password)
        {
            var saltBytes = new byte[size];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            var salt = Convert.ToBase64String(saltBytes);

            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            var hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            model.Hash = hashPassword;
            model.Salt = salt;
            model.Password = null;

            return model;
        }
    }
}
