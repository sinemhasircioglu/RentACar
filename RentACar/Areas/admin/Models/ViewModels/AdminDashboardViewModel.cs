using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Areas.admin.Models.ViewModels
{
    public class AdminDashboardViewModel
    {
        public int MusaitAracSayisi { get; set; }
        public int DoluAracSayisi { get; set; }
        public int YeniRezervasyonSayi { get; set; }
        public int ToplamKiralamaBuguneKadar { get; set; }
    }
}