using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace iCare.Models
{
    public partial class PatientRecord
    {
        // State management properties
        public TreatmentRecord TreatedBy { get; private set; }
        public int NumOfNurses { get; private set; } = 0;
        public bool IsDoctorAssigned { get; private set; } = false;

        // Enum to represent states
        public enum PatientState { Unassigned, NurseAssigned, DoctorAssigned }
        public PatientState CurrentState { get; private set; } = PatientState.Unassigned;


        public List<PatientRecord> GetAllPatients()
        {
            using (var context = new iCAREEntities())
            {
                return context.PatientRecords.ToList();
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
        public string AssignNurse(iCAREWorker nurse)
        {
            if (NumOfNurses >= 3)
            {
                return "Cannot assign more than 3 nurses.";
            }

            if (CurrentState == PatientState.Unassigned || CurrentState == PatientState.NurseAssigned)
            {
                TreatedBy = new TreatmentRecord { TreatmentID = nurse.ID, Description = "Nurse assigned" };
                NumOfNurses++;
                CurrentState = PatientState.NurseAssigned;
                return $"Nurse {nurse.iCAREUser.Name} assigned to patient {Name}. Total nurses: {NumOfNurses}.";
            }

            return "Cannot assign nurse. Doctor has already been assigned.";
        }

        public string AssignDoctor(iCAREWorker doctor)
        {
            if (IsDoctorAssigned)
            {
                return "Doctor has already been assigned.";
            }

            if (CurrentState == PatientState.NurseAssigned)
            {
                TreatedBy = new TreatmentRecord { TreatmentID = doctor.ID, Description = "Doctor assigned" };
                IsDoctorAssigned = true;
                CurrentState = PatientState.DoctorAssigned;
                return $"Doctor {doctor.iCAREUser.Name} assigned to patient {Name}.";
            }

            return "Cannot assign doctor. Assign a nurse first.";
        }
    }
}