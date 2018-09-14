using RentACar.Core.Infrastructure;
using RentACar.Data;
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

        public ActionResult Hakkimizda()
        {
            return View();
        }

        public ActionResult Iletisim()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult KiralamaFiltrele(int fiyatMax, string arabaSinif, string arabaVites, string arabaYakit, string siralama, DateTime tarihBaslangic, DateTime tarihBitis)
        //{
        //    return RedirectToAction("Kiralama");
        //}

        [HttpGet]
        public ActionResult Araclar()
        {
            var Araclar = _aracRepository.GetAll().ToList();
            return View("Araclar",Araclar);
        }

        [HttpPost]
        public ActionResult Araclar(string Sinif, string Vites, string Siralama)
        {
            var filtrelenmisAraclar = new List<Arac>();
            if (Siralama == "Artan")
            {
                filtrelenmisAraclar = _aracRepository.GetMany(x => x.Sinif == Sinif && x.Vites == Vites).OrderBy(x => x.GunlukFiyat).ToList();
            } else
            {
                filtrelenmisAraclar = _aracRepository.GetMany(x => x.Sinif == Sinif && x.Vites == Vites).OrderByDescending(x => x.GunlukFiyat).ToList();
            }
            return View(filtrelenmisAraclar);
        }
    }
}