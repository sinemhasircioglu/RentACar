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
        public ActionResult OnlineRezarvasyon(DateTime TeslimAlmaTarihi, DateTime TeslimEtmeTarihi, string ArabaSinif, string ArabaVites, string ArabaYakit, int sayfa = 1)
        {
            ViewBag.Markalar = _aracRepository.GetAll().Select(x => x.Marka).Distinct().ToList();
            ViewBag.ArabaSinif = ArabaSinif;
            ViewBag.ArabaVites = ArabaVites;
            ViewBag.ArabaYakit = ArabaYakit;
            ViewBag.TeslimEtmeTarihi = TeslimEtmeTarihi;
            ViewBag.TeslimAlmaTarihi = TeslimAlmaTarihi;
            int sayfaBoyutu = 20;

            var oTarihteDoluAracIdleri = _islemRepository.GetMany(islem => islem.TeslimTarihi >= TeslimAlmaTarihi
            && islem.TeslimTarihi <= TeslimEtmeTarihi).Select(islem => islem.AracId).ToList();

            var ozelliklereUygunAracIdleri = _aracRepository.GetMany(x => x.Sinif == ArabaSinif && x.Vites == ArabaVites && x.Yakit == ArabaYakit).Select(x => x.Id).ToList();

            var idler = ozelliklereUygunAracIdleri.Except(oTarihteDoluAracIdleri);

            var musaitAraclar = new List<Arac>();

            foreach (var n in idler)
            {
                musaitAraclar.Add(_aracRepository.GetById(n));
            }

            var araclar=musaitAraclar.OrderBy(x => x.Id).ToPagedList(sayfa, sayfaBoyutu);

            return View("Araclar",araclar);
        }

        [HttpGet]
        public ActionResult Araclar(int sayfa = 1)
        {
            int sayfaBoyutu = 6;
            var Araclar = _aracRepository.GetAll().OrderByDescending(x => x.Id).ToPagedList(sayfa, sayfaBoyutu);
            ViewBag.Markalar = _aracRepository.GetAll().Select(x => x.Marka).Distinct().ToList(); // tekrar edenleri göstermiyoruz.
            return View("Araclar", Araclar);
        }

        public ActionResult MarkayaGoreAraclar(string marka, int sayfa = 1)
        {
            int sayfaBoyutu = 6;
            ViewBag.Markalar = _aracRepository.GetAll().Select(x => x.Marka).Distinct().ToList();
            var filtrelenmisAraclar = _aracRepository.GetMany(x => x.Marka == marka).OrderBy(x => x.GunlukFiyat).ToPagedList(sayfa, sayfaBoyutu);
            return View("Araclar", filtrelenmisAraclar);
        }

        public ActionResult KiralamaDetay(int id, DateTime TeslimAlma, DateTime TeslimEtme)
        {
            var model = new KiralamaDetayViewModel()
            {
                Arac = _aracRepository.GetById(id),
                EkHizmetler = _hizmetRepository.GetAll().ToList()
            };
            ViewBag.TeslimAlmaTarih = TeslimAlma;
            ViewBag.TeslimEtmeTarih = TeslimEtme;
            ViewBag.GunSayisi = (TeslimEtme - TeslimAlma).TotalDays;
            return View(model);
        }

        public ActionResult AracDetay(int id)
        {
            var arac = _aracRepository.GetById(id);
            return View(arac);
        }

        [HttpPost]
        public ActionResult RezervasyonYap(Islem islem )
        {
            Islem yeniIslem = new Islem();
            yeniIslem.RezervasyonTarihi = DateTime.Now;
            yeniIslem.MusteriId = islem.MusteriId;
            yeniIslem.AracId = islem.AracId;
            yeniIslem.TcKimlikNo = islem.TcKimlikNo;
            yeniIslem.Telefon = islem.Telefon;
            yeniIslem.Tutar = islem.Tutar;
            yeniIslem.AlimTarihi = islem.AlimTarihi;
            yeniIslem.TeslimTarihi = islem.TeslimTarihi;
            yeniIslem.TahminiKm = islem.TahminiKm;
            _islemRepository.Insert(yeniIslem);
            _islemRepository.Save();
            return RedirectToAction("Rezervasyonlarim", "Hesap");
        }
    }
}