//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentACar.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Odeme
    {
        public int Id { get; set; }
        public Nullable<int> IslemId { get; set; }
        public Nullable<System.DateTime> TeslimAlinmaTarihi { get; set; }
        public Nullable<int> Tutar { get; set; }
        public Nullable<System.DateTime> OdemeTarihi { get; set; }
    
        public virtual Islem Islem { get; set; }
    }
}
