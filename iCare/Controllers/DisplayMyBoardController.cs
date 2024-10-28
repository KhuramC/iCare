using iCare.Models;
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
        public ActionResult Index(string workerID)
        {
            // fetch data from database.
            var myPatients = retrieveMyPatients(workerID);
            ViewBag.MyPatients = myPatients;

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


        public List<PatientRecord> retrieveMyPatients(string workerID)
        {
            var patientIDs = getPatientIDs(workerID);

            var patients = GetMyPatients(workerID, patientIDs);

            return patients;
        }
        public List<string> getPatientIDs(string workerID)
        {
            using (var context = new iCAREEntities())
            {
                var patientIDs = context.TreatmentRecords
                    .Where(tr => tr.WorkerID == workerID) // Filter by workerID
                    .Select(tr => tr.PatientID)
                    .ToList();
                return patientIDs;
            }
        }

        public List<PatientRecord> GetMyPatients(string workerID, List<string> patientIDs)
        {
            using (var context = new iCAREEntities())
            {
                var myPatients = context.PatientRecords
                    .Where(p => patientIDs.Contains(p.ID) && p.TreatedBy.TreatmentID == workerID)
                    .ToList();
                return myPatients;
            }
        }

    }
}
