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
        private readonly UserPassword _userPassword;
        
        // relies on a userpassword existing.
        public UserAuthenticationController(UserPassword userPassword)
        {
            _userPassword = userPassword;
        }

        public ActionResult Validate(string username, string password)
        {
            // Retrieve the password from the database
            string storedPassword = _userPassword.GetPassword(username);

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
    }
}