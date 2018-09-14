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

        public ActionResult Galeri()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Araclar()
        {
            var Araclar = _aracRepository.GetAll().ToList();
            ViewBag.Markalar = _aracRepository.GetAll().Select(x => x.Marka).ToList();
            return View("Araclar", Araclar);
        }

        [HttpPost]
        public ActionResult AracBul(string TeslimAlmaNoktasi, string TeslimEtmeNoktasi, string TeslimAlmaTarihi, 
            string TeslimAlmaSaati, string TeslimEtmeTarihi, string TeslimEtmeSaati)
        {
            return View("Araclar");
        }

        [HttpPost]
        public ActionResult Araclar(string ArabaSinif, string ArabaVites, string Siralama)
        {
            ViewBag.Markalar = _aracRepository.GetAll().Select(x => x.Marka).ToList();
            var filtrelenmisAraclar = new List<Arac>();
            if (Siralama == "Artan")
            {
                filtrelenmisAraclar = _aracRepository.GetMany(x => x.Sinif == ArabaSinif && x.Vites == ArabaVites).OrderBy(x => x.GunlukFiyat).ToList();
            }
            else
            {
                filtrelenmisAraclar = _aracRepository.GetMany(x => x.Sinif == ArabaSinif && x.Vites == ArabaVites).OrderByDescending(x => x.GunlukFiyat).ToList();
            }
            return View(filtrelenmisAraclar);
        }

        public ActionResult MarkayaGoreAraclar(string marka)
        {
            ViewBag.Markalar = _aracRepository.GetAll().Select(x => x.Marka).ToList();
            var filtrelenmisAraclar = _aracRepository.GetMany(x => x.Marka == marka).OrderBy(x => x.GunlukFiyat).ToList();
            return View("Araclar", filtrelenmisAraclar);
        }
    }
}