using PagedList;
using RentACar.Core.Infrastructure;
using RentACar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Areas.admin.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly IKullaniciRepository _kullaniciRepository;

        public KullaniciController(IKullaniciRepository kullaniciRepository)
        {
            _kullaniciRepository = kullaniciRepository;
        }

        [HttpGet]
        public ActionResult Index(int sayfa = 1)
        {
            int sayfaBoyutu = 5;
            var kullaniciListesi = _kullaniciRepository.GetAll().OrderByDescending(x => x.Id).ToPagedList(sayfa, sayfaBoyutu);
            return View(kullaniciListesi);
        }

        public ActionResult Sil(int id)
        {
            Kullanici kullanici = _kullaniciRepository.GetById(id);
            if (kullanici == null)
            {
                TempData["Bilgi"] = "Kullanıcı bulunamadı!";
            }
            _kullaniciRepository.Delete(id);
            _kullaniciRepository.Save();
            TempData["Bilgi"] = "Kullanıcı başarıyla silindi";
            return RedirectToAction("Index", "Kullanici");
        }
    }
}