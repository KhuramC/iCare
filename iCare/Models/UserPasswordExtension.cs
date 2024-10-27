using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iCare.Models
{
    public partial class UserPassword
    {
        // Return password of user specified by username.
        public string getPassword(string username)
        {
            using (var context = new iCAREEntities1())
            {
                var userPassword = context.UserPasswords.FirstOrDefault(up => up.Username == username);
                if (userPassword == null)
                {
                    return string.Empty;
                }
                return userPassword.Password;
            }
        }
    }
}