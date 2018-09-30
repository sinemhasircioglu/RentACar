using RentACar.Core.Infrastructure;
using RentACar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class HesapController : Controller
    {
        private readonly IMusteriRepository _musteriRepository;
        private readonly IIslemRepository _islemRepository;

        public HesapController(IMusteriRepository musteriRepository, IIslemRepository islemRepository)
        {
            _musteriRepository = musteriRepository;
            _islemRepository = islemRepository;
        }

        [HttpGet]
        public ActionResult LoginRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Musteri musteri)
        {
            var KullaniciVarMi = _musteriRepository.GetMany(x => x.Email == musteri.Email && x.Sifre == musteri.Sifre).SingleOrDefault();
            if (KullaniciVarMi != null)
            {
                Session["MusteriId"] = KullaniciVarMi.Id;
                return RedirectToAction("Index", "Home");
            }
            TempData["Bilgi"] = "Geçersiz Email/Şifre girdiniz!";
            return RedirectToAction("LoginRegister", "Hesap");
        }

        [HttpPost]
        public ActionResult Register(Musteri musteri, string SifreTekrar)
        {
            var KullaniciVarMi = _musteriRepository.GetMany(x => x.Email == musteri.Email).SingleOrDefault();
            if (KullaniciVarMi != null)
            {
                TempData["Bilgi"] = "Bu email kullanılmış !";
                return RedirectToAction("LoginRegister", "Hesap");
            }

            if (musteri.Sifre != null && musteri.Sifre == SifreTekrar)
            {
                Musteri yeniMusteri = new Musteri
                {
                    AdSoyad = musteri.AdSoyad,
                    Email = musteri.Email,
                    Sifre = musteri.Sifre,
                    KayitTarihi = DateTime.Now,
                };
                try
                {
                    _musteriRepository.Insert(yeniMusteri);
                    _musteriRepository.Save();
                    TempData["Bilgi"] = "Kayıt oldunuz lütfen giriş yapın.";
                    return RedirectToAction("LoginRegister", "Hesap");
                }
                catch (Exception)
                {
                    TempData["Bilgi"] = "Tüm alanları doğru girdiğinizden emin olun";
                    return RedirectToAction("LoginRegister", "Hesap");
                }
            }
            else
            {
                TempData["Bilgi"] = "Tüm alanları doğru girdiğinizden emin olun";
                return RedirectToAction("LoginRegister", "Hesap");
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            Musteri gelenMusteri = _musteriRepository.GetById(id);
            if (gelenMusteri == null)
                TempData["Bilgi"] = "Profil bulunamadı!";
            return View(gelenMusteri);
        }

        [HttpPost]
        public ActionResult Duzenle(Musteri musteri, string EskiSifre, string YeniSifre, string YeniSifreTekrar)
        {
            Musteri dbMusteri = _musteriRepository.GetById(musteri.Id);
            dbMusteri.AdSoyad = musteri.AdSoyad;
            dbMusteri.Email = musteri.Email;
            if (EskiSifre != null && EskiSifre == dbMusteri.Sifre)
            {
                if (YeniSifre == YeniSifreTekrar && YeniSifre != null)
                {
                    dbMusteri.Sifre = YeniSifre;
                }
            }
            _musteriRepository.Save();
            TempData["Bilgi"] = "Profil düzenleme işleminiz başarılı.";
            return RedirectToAction("Duzenle", "Hesap");
        }

        public ActionResult Rezervasyonlarim()
        {
            int musteri = (int)Session["MusteriId"];
            var Rezlerim = _islemRepository.GetAll().Where(x => x.MusteriId == musteri);
            return View(Rezlerim);
        }
    }
}