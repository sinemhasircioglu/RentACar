using RentACar.Core.Infrastructure;
using RentACar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMusteriRepository _musteriRepository;

        public AccountController(IMusteriRepository musteriRepository)
        {
            _musteriRepository = musteriRepository;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Musteri musteri) //giriş yap butonuna basınca çalışacak kodlar
        {
            var KullaniciVarMi = _musteriRepository.GetMany(x => x.Email == musteri.Email && x.Sifre == musteri.Sifre).SingleOrDefault();
            if (KullaniciVarMi != null)
            {
                Session["KullaniciId"] = KullaniciVarMi.Id;
                return RedirectToAction("Index", "Home");

            }
            TempData["Bilgi"] = "Geçersiz Email/Şifre girdiniz!";
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
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
                Telefon=" ",
                TcKimlikNo=" "
            };

            try
            {
                _musteriRepository.Insert(yeniMusteri);
                _musteriRepository.Save();
                return RedirectToAction("Index", "Home");
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
    }
}