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
    
    public partial class iCAREAdmin
    {
        public string ID { get; set; }
        public string AdminEmail { get; set; }
        public Nullable<System.DateTime> DateHired { get; set; }
        public Nullable<System.DateTime> DateFinished { get; set; }
    
        public virtual iCAREUser iCAREUser { get; set; }
    }
}
