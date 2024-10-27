using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iCare.Models
{
    public partial class UserPassword
    {
        public string GetPassword(string username)
        {
            using (var context = new iCAREEntities())
            {
                var userPassword = context.UserPasswords.FirstOrDefault(up => up.Username == username);
                return userPassword?.Password ?? string.Empty;
            }
        }
    }
}