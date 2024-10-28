using iCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

// Created by UserAuthenticationForm or login
namespace iCare.Controllers
{
    public class UserAuthenticationController : Controller
    {
        public ActionResult Validate(string username, string password)
        {
            // Retrieve the stored hashed password
            var storedHashedPassword = GetStoredHashedPassword(username);

            // Hash the provided password
            var hashedPassword = HashPassword(password);

            // Compare the hashed passwords
            if (hashedPassword == storedHashedPassword)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View();
        }

        private string GetStoredHashedPassword(string username)
        {
            using (var context = new iCAREEntities())
            {
                var userPassword = context.UserPasswords.FirstOrDefault(up => up.Username == username);
                return userPassword?.Password ?? string.Empty; // return empty string if null.
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}