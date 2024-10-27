using iCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iCare.Controllers
{
    public class UserAuthenticationController : Controller
    {
        //endpoint uauth with username and password
        public ActionResult Login(string username, string password)
        {
            // add password encrpytion somewhere in here later.
            string storedPassword = GetPassword(username);

            //validate credentials.
            if (string.IsNullOrEmpty(storedPassword))
            {
                return Content("User does not exist.");
            }
            else if (storedPassword == password)
            {
                return Content("Login successful.");
            }
            else
            {
                return Content("Invalid password.");
            }
        }
        private string GetPassword(string username)
        {
            using (var context = new iCAREEntities())
            {
                var userPassword = context.UserPasswords.FirstOrDefault(up => up.Username == username);
                return userPassword?.Password ?? string.Empty;
            }
        }
    }
}
