//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HOSPITALMVC.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class APPOINTMENT
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> DATETIME_ { get; set; }
        public Nullable<int> DOCTORID { get; set; }
        public Nullable<int> PATIENTID { get; set; }
    
        public virtual DOCTOR DOCTOR { get; set; }
        public virtual PATIENT PATIENT { get; set; }
    }
}