//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iCare.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class iCAREWorker
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public iCAREWorker()
        {
            this.ModificationHistories = new HashSet<ModificationHistory>();
            this.TreatmentRecords = new HashSet<TreatmentRecord>();
        }
    
        public string ID { get; set; }
        public string Profession { get; set; }
    
        public virtual iCAREUser iCAREUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ModificationHistory> ModificationHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TreatmentRecord> TreatmentRecords { get; set; }
    }
}
