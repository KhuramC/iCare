using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iCare.Controllers
{
    public class ManagePatientRecordController : Controller
    {
        // GET: ManagePatientRecord
        public ActionResult Index()
        {
            return View();
        }

        // GET: ManagePatientRecord/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManagePatientRecord/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagePatientRecord/Create
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

        // GET: ManagePatientRecord/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManagePatientRecord/Edit/5
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

        // GET: ManagePatientRecord/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManagePatientRecord/Delete/5
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
