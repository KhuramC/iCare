using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iCare.Controllers
{
    public class UserAuthenticationController : Controller
    {
        // GET: UserAuthenticationControler
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserAuthenticationControler/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserAuthenticationControler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAuthenticationControler/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserAuthenticationControler/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserAuthenticationControler/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserAuthenticationControler/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserAuthenticationControler/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
