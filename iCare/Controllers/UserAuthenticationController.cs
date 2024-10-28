using iCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// Created by UserAuthenticationForm or login
namespace iCare.Controllers
{
    public class UserAuthenticationController : Controller
    {
        public ActionResult Validate(string username, string password)
        {
            // Retrieve the password from the database
            string storedPassword = GetPassword(username);

            // Compare the provided password with the stored password.
            // Encrypt stored password before compare.
            if (storedPassword == password)
            {
                // Successful login
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Login failed
                ModelState.AddModelError("", "Invalid username or password.");
                return View();
            }
        }
        public string encrypt(string password)
        {
            //salt and hash password here.

            return password;
        }
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