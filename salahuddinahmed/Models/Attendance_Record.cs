//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace salahuddinahmed.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Attendance_Record
    {
        public int Id { get; set; }
        public int Information_Id { get; set; }
        public System.DateTime Attendance_Timing { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<bool> Notified { get; set; }
        public Nullable<System.DateTime> Created_On { get; set; }
    
        public virtual Information Information { get; set; }
    }
}
