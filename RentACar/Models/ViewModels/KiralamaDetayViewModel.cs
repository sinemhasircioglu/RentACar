using RentACar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Models.ViewModels
{
    public class KiralamaDetayViewModel
    {
        public Arac Arac { get; set; }

        public IEnumerable<Hizmet> EkHizmetler { get; set; }
    }
}