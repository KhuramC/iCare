using System;
using System.Linq;
//using System.Security.Cryptography; maybe in future version
using System.Text;
using iCare.Models;

namespace iCare.Services
{
    public class UserAuthenticationForm
    {
        private string _validationMessage;

        // Method to log in user by verifying account name and password
        public bool Login(string userAccountName, string password)
        {
            using (var db = new iCAREEntities1()) // not sure if this would be right.
            {
                // Retrieve user account with matching username
                var user = db.UserPasswords.FirstOrDefault(u => u.Username == userAccountName);

                if (user == null)
                {
                    _validationMessage = "User account not found.";
                    return false;
                }

                //// Encrypt and compare the password
                //var encryptedInputPassword = EncryptPassword(password);
                //if (user.encryptedPassword == encryptedInputPassword)
                if (user.Password == password)
                {
                    _validationMessage = "Login successful!";
                    return true;
                }
                else
                {
                    _validationMessage = "Invalid password.";
                    return false;
                }
            }
        }

        // Method to return the validation response message
        public string ValidationResponse()
        {
            return _validationMessage;
        }

        // Helper method to encrypt the password
        //private string EncryptPassword(string password)
        //{
        //    using (var sha256 = SHA256.Create())
        //    {
        //        var saltedPassword = "your_salt_here" + password; // Replace with secure salt
        //        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
        //        return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        //    }
        //}
    }
}
