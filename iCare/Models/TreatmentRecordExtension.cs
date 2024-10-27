using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iCare.Models
{
    public partial class TreatmentRecord
    {
        public void SetRecord(string workerID, List<string> selectedPatients)
        {
            using (var context = new iCAREEntities())
            {
                // Get worker with id from database.
                var worker = context.iCAREWorkers.FirstOrDefault(w => w.ID == workerID);
                if (worker == null)
                {
                    throw new KeyNotFoundException($"Worker with ID {workerID} not found.");
                }

                // Iterate through each selected patient ID and create a new treatment record.
                foreach(var patientID in selectedPatients)
                {
                    var patient = context.PatientRecords.FirstOrDefault(p => p.ID == patientID);
                    if (patient == null)
                    {
                        throw new KeyNotFoundException($"Patient with ID {patientID} not found.");
                    }

                    // Create new treatment record for patient.
                    var newTreatmentRecord = new TreatmentRecord
                    {
                        TreatmentID = System.Guid.NewGuid().ToString(), // Generate new unique treatmentid
                        WorkerID = workerID,
                        PatientID = patientID,
                        Description = $"Assigned to worker {workerID}",
                        TreatmentDate = DateTime.Now,
                    };

                    // Add treatment record to context
                    context.TreatmentRecords.Add(newTreatmentRecord);

                }
                context.SaveChanges(); // Save changes
            }
        }
        public List<string> GetPatientsID(string workerID)
        {
            using (var context = new iCAREEntities())
            {
                var treatmentRecords = context.TreatmentRecords
                    .Where(tr => tr.WorkerID == workerID)
                    .Select(tr => tr.PatientID)
                    .ToList();
                return treatmentRecords;
            }
        }
    }
}