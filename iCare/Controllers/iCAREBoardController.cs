using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iCare.Controllers
{
    public class iCAREBoardController : Controller
    {
        // GET: iCAREBoard
        public ActionResult Index()
        {
            return View();
        }

        // GET: iCAREBoard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: iCAREBoard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: iCAREBoard/Create
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

        // GET: iCAREBoard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: iCAREBoard/Edit/5
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

        // GET: iCAREBoard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: iCAREBoard/Delete/5
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
