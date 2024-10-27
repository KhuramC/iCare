using iCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iCare.Controllers
{
    public class AssignPatientController : Controller
    {
        // GET: Retrieve all patient records
        public ActionResult RetrieveAllPatients()
        {
            using (var context = new iCAREEntities())
            {
                var patients = context.PatientRecords.ToList(); // Retrieve all patients from the database
                return Json(patients, JsonRequestBehavior.AllowGet); // Return patients as JSON didn't know you could do this until I looked it up.
            }
        }

        // POST: Assign patients to a worker
        public ActionResult AssignPatients(string workerID, List<string> selectedPatientIDs)
        {
            using (var context = new iCAREEntities())
            {
                var worker = context.iCAREWorkers.FirstOrDefault(w => w.ID == workerID); // Find the worker by ID
                if (worker == null)
                {
                    return Content("Worker not found.");
                }

                var assignedMessages = new List<string>();

                foreach (var patientID in selectedPatientIDs)
                {
                    var patient = context.PatientRecords.FirstOrDefault(p => p.ID == patientID); // Find the patient by ID
                    if (patient == null)
                    {
                        assignedMessages.Add($"Patient with ID {patientID} not found.");
                        continue;
                    }

                    // Use the existing method to assign the nurse
                    string message = patient.AssignNurse(worker); // Call the AssignNurse method from PatientRecord
                    assignedMessages.Add(message); // Collect the response message
                }

                return Json(assignedMessages); // Return the messages as JSON
            }
        }
    }
}
