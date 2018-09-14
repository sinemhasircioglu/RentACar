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

        public HesapController(IMusteriRepository musteriRepository)
        {
            _musteriRepository = musteriRepository;
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
                Session["KullaniciId"] = KullaniciVarMi.Id;
                return RedirectToAction("Index", "Home");
                //$$$$$$$$$$$$

            }
            TempData["Bilgi"] = "Geçersiz Email/Şifre girdiniz!";
            return View();
        }

        [HttpPost]
        public ActionResult Register(Musteri musteri)
        {
            var KullaniciVarMi = _musteriRepository.GetMany(x => x.Email == musteri.Email).SingleOrDefault();
            if (KullaniciVarMi != null)
            {
                TempData["Bilgi"] = "Bu email kullanılmış !";
                return View();
            }
            Musteri yeniMusteri = new Musteri
            {
                AdSoyad = musteri.AdSoyad,
                Email = musteri.Email,
                Sifre = musteri.Sifre,
                KayitTarihi = DateTime.Now,
                Telefon = musteri.Telefon,
                TcKimlikNo = " "
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
                return View();
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
        public ActionResult Duzenle(Musteri musteri)
        {
            Musteri dbMusteri = _musteriRepository.GetById(musteri.Id);
            dbMusteri.AdSoyad = musteri.AdSoyad;
            dbMusteri.Email = musteri.Email;
            dbMusteri.Sifre = musteri.Sifre;
            _musteriRepository.Save();
            TempData["Bilgi"] = "Profil düzenleme işleminiz başarılı.";
            return RedirectToAction("Duzenle", "Hesap");
        }
    }
}