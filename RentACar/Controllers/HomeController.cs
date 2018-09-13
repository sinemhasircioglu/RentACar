using RentACar.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAracRepository _aracRepository;

        public HomeController(IAracRepository aracRepository)
        {
            _aracRepository = aracRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Iletisim()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KiralamaFiltrele(int fiyatMax, string arabaSinif, string arabaVites, string arabaYakit, string siralama, DateTime tarihBaslangic, DateTime tarihBitis)
        {
            return RedirectToAction("Kiralama");
        }
    }
}