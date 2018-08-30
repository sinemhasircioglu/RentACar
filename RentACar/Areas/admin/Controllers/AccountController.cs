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
                if (KullaniciVarMi.Rol.Ad == "Admin" || KullaniciVarMi.Rol.Ad == "Editör" )
                {
                    Session["KullaniciId"] = KullaniciVarMi.Id;
                    return RedirectToAction("Index", "Admin");
                }
                else if (KullaniciVarMi.Rol.Ad == "Üye")
                {
                    Session["KullaniciId"] = KullaniciVarMi.Id;
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Mesaj = "Yetkisiz kullanıcı";
                return View();
            }
            ViewBag.Mesaj = "Geçersiz Email/Şifre girdiniz!";
            return View();
        }

        //[HttpGet]
        //public ActionResult Register()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Register(Kullanici kullanici)
        //{
        //    var KullaniciVarMi = _kullaniciRepository.GetMany(x => x.Email == kullanici.Email).SingleOrDefault();
        //    if (KullaniciVarMi != null)
        //    {
        //        ViewBag.Mesaj = "Bu email kullanılmış !";
        //        return View();
        //    }
        //    Kullanici yeniKullanici = new Kullanici
        //    {
        //        AdSoyad = kullanici.AdSoyad,
        //        Email = kullanici.Email,
        //        Sifre = kullanici.Sifre,
        //        RolId = 3,
        //        KayitTarihi = DateTime.Now
        //    };

        //    try
        //    {
        //        _kullaniciRepository.Insert(yeniKullanici);
        //        _kullaniciRepository.Save();
        //        return RedirectToAction("Index", "Home");
        //    }
        //    catch (Exception)
        //    {
        //        return View();
        //    }
        //}

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}