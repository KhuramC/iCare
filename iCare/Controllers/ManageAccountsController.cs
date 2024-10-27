using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iCare.Controllers
{
    public class ManageAccountsController : Controller
    {
        // GET: ManageAccounts
        public ActionResult Index()
        {
            return View();
        }

        // GET: ManageAccounts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManageAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageAccounts/Create
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

        // GET: ManageAccounts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManageAccounts/Edit/5
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

        // GET: ManageAccounts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManageAccounts/Delete/5
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
