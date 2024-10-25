using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iCare.Models
{
    public partial class PatientRecord
    {
        // State management
        public TreatmentRecord TreatedBy { get; private set; }
        public int NumOfNurses { get; private set; } = 0;
        public bool IsDoctorAssigned { get; private set; } = false;

        // Enum to represent states
        public enum PatientState { Unassigned, NurseAssigned, DoctorAssigned }
        public PatientState CurrentState { get; private set; } = PatientState.Unassigned;

        public string AssignNurse(iCareWorker nurse)
        {
            if (NumOfNurses >= 3)
            {
                return "Cannot assign more than 3 nurses.";
            }

            if (CurrentState == PatientState.Unassigned || CurrentState == PatientState.NurseAssigned)
            {
                // Assign nurse and update state
                TreatedBy = new TreatmentRecord { treatmentID = nurse.userID, description = "Nurse assigned" };
                NumOfNurses++;
                CurrentState = PatientState.NurseAssigned;

                return $"Nurse {nurse.userID} assigned to patient {name}. Total nurses: {NumOfNurses}.";
            }

            return "Cannot assign nurse. Doctor has already been assigned.";
        }

        // Assign a doctor
        public string AssignDoctor(iCareWorker doctor)
        {
            if (IsDoctorAssigned)
            {
                return "Doctor has already been assigned.";
            }

            if (CurrentState == PatientState.NurseAssigned)
            {
                // Assign doctor and update state
                TreatedBy = new TreatmentRecord { treatmentID = doctor.userID, description = "Doctor assigned" };
                IsDoctorAssigned = true;
                CurrentState = PatientState.DoctorAssigned;

                return $"Doctor {doctor.userID} assigned to patient {name}.";
            }

            return "Cannot assign doctor. Assign a nurse first.";
        }
    }
}