using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iCare.Controllers
{
    public class DisplayMyBoardController : Controller
    {
        // GET: DisplayMyBoard
        public ActionResult Index()
        {
            return View();
        }

        // GET: DisplayMyBoard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DisplayMyBoard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DisplayMyBoard/Create
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

        // GET: DisplayMyBoard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DisplayMyBoard/Edit/5
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

        // GET: DisplayMyBoard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DisplayMyBoard/Delete/5
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
