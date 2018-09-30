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
    public class AccountController : Controller
    {
        private readonly IKullaniciRepository _kullaniciRepository;

        public AccountController(IKullaniciRepository kullaniciRepository)
        {
            _kullaniciRepository = kullaniciRepository;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Kullanici kullanici) //giriş yap butonuna basınca çalışacak kodlar
        {
            var KullaniciVarMi = _kullaniciRepository.GetMany(x => x.Email == kullanici.Email && x.Sifre == kullanici.Sifre ).SingleOrDefault();
            if (KullaniciVarMi != null)
            {
                if (KullaniciVarMi.Rol.Ad == "Admin" || KullaniciVarMi.Rol.Ad == "Personel" )
                {
                    Session["KullaniciId"] = KullaniciVarMi.Id;
                    return Redirect("/admin/Home/Index");
                }
                TempData["Bilgi"] = "Yetkisiz kullanıcı";
                return View();
            }
            TempData["Bilgi"] = "Geçersiz Email/Şifre girdiniz!";
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            Kullanici gelenKullanici = _kullaniciRepository.GetById(id);
            if (gelenKullanici == null)
                TempData["Bilgi"] = "Kullanıcı bulunamadı!";
            return View(gelenKullanici);
        }

        [HttpPost]
        public ActionResult Duzenle(Kullanici kullanici)
        {
            Kullanici dbKullanici = _kullaniciRepository.GetById(kullanici.Id);
            dbKullanici.AdSoyad = kullanici.AdSoyad;
            dbKullanici.Email = kullanici.Email;
            dbKullanici.Sifre = kullanici.Sifre;
            _kullaniciRepository.Save();
            TempData["Bilgi"] = "Kullanıcı düzenleme işleminiz başarılı.";
            return RedirectToAction("Duzenle", "Account");
        }
    }
}