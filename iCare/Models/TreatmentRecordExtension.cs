using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iCare.Models
{
    public partial class TreatmentRecord
    {
        public List<PatientRecord> getAllPatients()
        {
            using (var context = new iCAREEntities())
            {
                var patients = context.PatientRecords.ToList();
                return patients;
            }
        }
    }
}