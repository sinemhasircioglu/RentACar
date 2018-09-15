using RentACar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Models.ViewModels
{
    public class KiralamaDetayViewModel
    {
        public IEnumerable<Arac> BenzerAraclar { get; set; }
        public Arac Arac { get; set; }
    }
}