using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace iCare.Models
{
    public partial class PatientRecord
    {
        // Get all patient records.
        public IEnumerable<PatientRecord> GetAllPatients()
        {
            using (var context = new iCAREEntities1())
            {
                return context.PatientRecords.ToList();
            }
        }

        // State management
        public TreatmentRecord TreatedBy { get; private set; }
        public int NumOfNurses { get; private set; } = 0;
        public bool IsDoctorAssigned { get; private set; } = false;

        // Enum to represent states
        public enum PatientState { Unassigned, NurseAssigned, DoctorAssigned }
        public PatientState CurrentState { get; private set; } = PatientState.Unassigned;

        public string AssignNurse(iCAREWorker nurse)
        {
            if (NumOfNurses >= 3)
            {
                return "Cannot assign more than 3 nurses.";
            }

            if (CurrentState == PatientState.Unassigned || CurrentState == PatientState.NurseAssigned)
            {
                // Assign nurse and update state
                TreatedBy = new TreatmentRecord { TreatmentID = nurse.ID, Description = "Nurse assigned" };
                NumOfNurses++;
                CurrentState = PatientState.NurseAssigned;

                return $"Nurse {nurse.iCAREUser.Name} assigned to patient {Name}. Total nurses: {NumOfNurses}.";
            }

            return "Cannot assign nurse. Doctor has already been assigned.";
        }

        // Assign a doctor
        public string AssignDoctor(iCAREWorker doctor)
        {
            if (IsDoctorAssigned)
            {
                return "Doctor has already been assigned.";
            }

            if (CurrentState == PatientState.NurseAssigned)
            {
                // Assign doctor and update state
                TreatedBy = new TreatmentRecord { TreatmentID = doctor.ID, Description = "Doctor assigned" };
                IsDoctorAssigned = true;
                CurrentState = PatientState.DoctorAssigned;

                return $"Doctor {doctor.iCAREUser.Name} assigned to patient {Name}.";
            }

            return "Cannot assign doctor. Assign a nurse first.";
        }
    }
}