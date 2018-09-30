using PagedList;
using RentACar.Areas.admin.Class;
using RentACar.Core.Infrastructure;
using RentACar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Areas.admin.Controllers
{
    public class OdemeController : Controller
    {
        private readonly IOdemeRepository _odemeRepository;
        private readonly IIslemRepository _islemRepository;

        public OdemeController(IOdemeRepository odemeRepository, IIslemRepository islemRepository)
        {
            _odemeRepository = odemeRepository;
            _islemRepository = islemRepository;
        }

        [HttpGet]
        [AdminPersonelAuth]
        public ActionResult Index(int sayfa = 1)
        {
            int sayfaBoyutu = 5;
            var odemeListesi = _odemeRepository.GetAll().OrderByDescending(x => x.Id).ToPagedList(sayfa, sayfaBoyutu);
            return View(odemeListesi);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            ViewBag.Islem = _islemRepository.GetAll().ToList();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Ekle(Odeme odeme)
        {
            if (ModelState.IsValid)
            {
                _odemeRepository.Insert(odeme);
                _odemeRepository.Save();
            }
            TempData["Bilgi"] = "Ödeme ekleme işleminiz başarılı";
            return RedirectToAction("Index", "Odeme");
        }

        public ActionResult Sil(int id)
        {
            Odeme odeme = _odemeRepository.GetById(id);
            if (odeme == null)
                TempData["Bilgi"] = "Ödeme bulunamadı!";
            _odemeRepository.Delete(id);
            _odemeRepository.Save();
            TempData["Bilgi"] = "Ödeme başarıyla silindi";
            return RedirectToAction("Index", "Odeme");
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Duzenle(int id)
        {
            Odeme gelenOdeme = _odemeRepository.GetById(id);
            if (gelenOdeme == null)
                TempData["Bilgi"] = "Ödeme bulunamadı!";
            ViewBag.Islem = _islemRepository.GetAll().ToList();
            ViewBag.OdemeTarih = gelenOdeme.OdemeTarihi;
            ViewBag.AlmaTarih = gelenOdeme.TeslimAlinmaTarihi;
            return View(gelenOdeme);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Duzenle(Odeme odeme)
        {
            Odeme gelenOdeme = _odemeRepository.GetById(odeme.Id);
            gelenOdeme.IslemId = odeme.IslemId;
            gelenOdeme.TeslimAlinmaTarihi = odeme.TeslimAlinmaTarihi;
            gelenOdeme.Tutar = odeme.Tutar;
            gelenOdeme.OdemeTarihi = odeme.OdemeTarihi;

            _odemeRepository.Save();
            TempData["Bilgi"] = "Ödeme düzenleme işleminiz başarılı.";
            return RedirectToAction("Index", "Odeme");
        }
    }
}