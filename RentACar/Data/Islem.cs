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
    
    public partial class Islem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Islem()
        {
            this.Odemes = new HashSet<Odeme>();
        }
    
        public int Id { get; set; }
        public int MusteriId { get; set; }
        public int AracId { get; set; }
        public int Tutar { get; set; }
        public System.DateTime AlimTarihi { get; set; }
        public System.DateTime TeslimTarihi { get; set; }
        public int TahminiKm { get; set; }
        public Nullable<System.DateTime> RezervasyonTarihi { get; set; }
        public string TcKimlikNo { get; set; }
        public string Telefon { get; set; }
    
        public virtual Arac Arac { get; set; }
        public virtual Musteri Musteri { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Odeme> Odemes { get; set; }
    }
}
