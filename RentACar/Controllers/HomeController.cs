using PagedList;
using RentACar.Core.Infrastructure;
using RentACar.Data;
using RentACar.Models.ViewModels;
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
        public ActionResult OnlineRezarvasyon()
        {

            return View();
        }

        [HttpPost]
        public ActionResult OnlineRezarvasyon(string TeslimAlmaNoktasi, string TeslimEtmeNoktasi, string TeslimAlmaTarihi,
            string TeslimAlmaSaati, string TeslimEtmeTarihi, string TeslimEtmeSaati, string ArabaSinif, string ArabaVites, string Siralama)
        {
            ViewBag.Markalar = _aracRepository.GetAll().Select(x => x.Marka).ToList();
            ViewBag.ArabaSinif = ArabaSinif;
            ViewBag.ArabaVites = ArabaVites;
            var filtrelenmisAraclar = new List<Arac>();
            if (Siralama == "Artan")
            {
                filtrelenmisAraclar = _aracRepository.GetMany(x => x.Sinif == ArabaSinif && x.Vites == ArabaVites).OrderBy(x => x.GunlukFiyat).ToList();
            }
            else
            {
                filtrelenmisAraclar = _aracRepository.GetMany(x => x.Sinif == ArabaSinif && x.Vites == ArabaVites).OrderByDescending(x => x.GunlukFiyat).ToList();
            }
            return View("Araclar");
        }

        [HttpGet]
        public ActionResult Araclar(int sayfa = 1)
        {
            int sayfaBoyutu = 6;
            var Araclar = _aracRepository.GetAll().OrderByDescending(x => x.Id).ToPagedList(sayfa, sayfaBoyutu);
            ViewBag.Markalar = _aracRepository.GetAll().Select(x => x.Marka).ToList();
            return View("Araclar", Araclar);
        }

        public ActionResult MarkayaGoreAraclar(string marka, int sayfa = 1)
        {
            int sayfaBoyutu = 6;
            ViewBag.Markalar = _aracRepository.GetAll().Select(x => x.Marka).ToList();
            var filtrelenmisAraclar = _aracRepository.GetMany(x => x.Marka == marka).OrderBy(x => x.GunlukFiyat).ToPagedList(sayfa, sayfaBoyutu);
            return View("Araclar", filtrelenmisAraclar);
        }

        public ActionResult KiralamaDetay(int id)
        {
            var model = new KiralamaDetayViewModel()
            {
                BenzerAraclar = _aracRepository.GetAll().ToList(),
                Arac = _aracRepository.GetById(id)
            };
            return View(model);
        }

        public ActionResult AracDetay(int id)
        {
            var arac = _aracRepository.GetById(id);
            return View(arac);
        }
    }
}