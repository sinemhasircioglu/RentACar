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
    
    public partial class Resim
    {
        public int Id { get; set; }
        public Nullable<int> AracId { get; set; }
        public string ResimUrl { get; set; }
    
        public virtual Arac Arac { get; set; }
    }
}
