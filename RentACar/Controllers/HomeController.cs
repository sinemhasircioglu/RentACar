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
        private readonly IIslemRepository _islemRepository;
        private readonly IHizmetRepository _hizmetRepository;
        private readonly IResimRepository _resimRepository;

        public HomeController(IAracRepository aracRepository, IIslemRepository islemRepository, IHizmetRepository hizmetRepository, IResimRepository resimRepository)
        {
            _aracRepository = aracRepository;
            _islemRepository = islemRepository;
            _hizmetRepository = hizmetRepository;
            _resimRepository = resimRepository;
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
            var resimler = _resimRepository.GetAll().Take(9).ToList();
            return View(resimler);
        }

        [HttpGet]
        public ActionResult OnlineRezarvasyon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OnlineRezarvasyon(string TeslimAlmaTarihi, string TeslimEtmeTarihi, string ArabaSinif, string ArabaVites, string ArabaYakit)
        {
            ViewBag.Markalar = _aracRepository.GetAll().Select(x => x.Marka).Distinct().ToList();
            ViewBag.ArabaSinif = ArabaSinif;
            ViewBag.ArabaVites = ArabaVites;
            ViewBag.ArabaYakit = ArabaYakit;
            var musaitAracIdleri = new List<int>();
            var musaitAraclar = new List<Arac>();

            var ozellikFiltreliAracIdleri = _aracRepository.GetMany(x => x.Sinif == ArabaSinif && x.Vites == ArabaVites && x.Yakit == ArabaYakit).OrderBy(x => x.GunlukFiyat).Select(x => x.Id);
            var tarihFiltreliIdler = _islemRepository.GetAll().Where(islem => Convert.ToDateTime(islem.AlimTarihi) < Convert.ToDateTime(TeslimAlmaTarihi) && Convert.ToDateTime(islem.TeslimTarihi) < Convert.ToDateTime(TeslimEtmeTarihi)).Select(y => y.AracId);

            foreach (var n in ozellikFiltreliAracIdleri)
            {
                if (tarihFiltreliIdler.Contains(n))
                {
                    musaitAracIdleri.Add(n);
                }
            }
            
            for(int i=0; i<musaitAracIdleri.Count(); i++)
            {
                musaitAraclar.Add(_aracRepository.GetById(musaitAracIdleri[i]));
            }
            var Araclar = musaitAraclar.OrderBy(x => x.Id).ToPagedList(1, 6);
            return View("Araclar",Araclar);
        }

        [HttpGet]
        public ActionResult Araclar(int sayfa = 1)
        {
            int sayfaBoyutu = 6;
            var Araclar = _aracRepository.GetAll().OrderByDescending(x => x.Id).ToPagedList(sayfa, sayfaBoyutu);
            ViewBag.Markalar = _aracRepository.GetAll().Select(x => x.Marka).Distinct().ToList();
            return View("Araclar", Araclar);
        }

        public ActionResult MarkayaGoreAraclar(string marka, int sayfa = 1)
        {
            int sayfaBoyutu = 6;
            ViewBag.Markalar = _aracRepository.GetAll().Select(x => x.Marka).Distinct().ToList();
            var filtrelenmisAraclar = _aracRepository.GetMany(x => x.Marka == marka).OrderBy(x => x.GunlukFiyat).ToPagedList(sayfa, sayfaBoyutu);
            return View("Araclar", filtrelenmisAraclar);
        }

        public ActionResult KiralamaDetay(int id)
        {
            var model = new KiralamaDetayViewModel()
            {
                BenzerAraclar = _aracRepository.GetAll().ToList(),
                Arac = _aracRepository.GetById(id),
                EkHizmetler = _hizmetRepository.GetAll().ToList()
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