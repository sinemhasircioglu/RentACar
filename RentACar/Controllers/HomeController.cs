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
            return View("Araclar", Araclar);
        }

        [HttpPost]
        public ActionResult Araclar(string TeslimAlmaNoktasi, string TeslimEtmeNoktasi, string TeslimAlmaTarihi, string TeslimAlmaSaati,
            string TeslimEtmeTarihi, string TeslimEtmeSaati, string ArabaSinif, string ArabaVites)
        {

            var arabalar = _aracRepository.GetMany(x => x.Sinif == ArabaSinif && x.Vites == ArabaVites).ToList();

            //var filtrelenmisAraclar = new List<Arac>();
            //if (Siralama == "Artan")
            //{
            //    filtrelenmisAraclar = _aracRepository.GetMany(x => x.Sinif == Sinif && x.Vites == Vites).OrderBy(x => x.GunlukFiyat).ToList();
            //} else
            //{
            //    filtrelenmisAraclar = _aracRepository.GetMany(x => x.Sinif == Sinif && x.Vites == Vites).OrderByDescending(x => x.GunlukFiyat).ToList();
            //}
            return View(arabalar);
        }
    }
}