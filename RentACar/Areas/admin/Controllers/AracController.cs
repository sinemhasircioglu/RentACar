using PagedList;
using RentACar.Core.Infrastructure;
using RentACar.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Areas.admin.Controllers
{
    public class AracController : Controller
    {
        private readonly IAracRepository _aracRepository;
        private readonly IResimRepository _resimRepository;

        public AracController(IAracRepository aracRepository, IResimRepository resimRepository)
        {
            _aracRepository = aracRepository;
            _resimRepository = resimRepository;
        }

        [HttpGet]
        public ActionResult Index(int sayfa = 1)
        {
            int sayfaBoyutu = 5;
            var aracListesi = _aracRepository.GetAll().OrderByDescending(x => x.Id).ToPagedList(sayfa, sayfaBoyutu);
            return View(aracListesi);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Ekle(Arac arac, IEnumerable<HttpPostedFileBase> DetayResim)
        {
            if (ModelState.IsValid)
            {
                _aracRepository.Insert(arac);
                try
                {
                    _aracRepository.Save();
                }
                catch (Exception)
                {
                    TempData["Bilgi"] = "Arac ekleme işleminiz başarısız!";
                    return RedirectToAction("Index", "Arac");
                }
            }
            string cokluResim = Path.GetExtension(Request.Files[0].FileName);
            if (cokluResim != "")
            {
                foreach (var file in DetayResim)
                {
                    if (file.ContentLength > 0)
                    {
                        string dosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                        string uzanti = Path.GetExtension(Request.Files[0].FileName);
                        string tamYol = "/Areas/admin/External/Arac/" + dosyaAdi + uzanti;
                        file.SaveAs(Server.MapPath(tamYol));
                        var resim = new Resim
                        {
                            ResimUrl = tamYol
                        };
                        resim.AracId = arac.Id;
                        _resimRepository.Insert(resim);
                        _resimRepository.Save();
                    }
                }
            }
            TempData["Bilgi"] = "Araç ekleme işleminiz başarılı";
            return RedirectToAction("Index", "Arac");
        }

        [HttpGet]
        public ActionResult Duzenle(int Id)
        {
            var gelenArac = _aracRepository.GetById(Id);
            if (gelenArac == null)
                TempData["Bilgi"] = "Araç bulunamadı!";
            return View(gelenArac);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Duzenle(Arac arac, IEnumerable<HttpPostedFileBase> DetayResim)
        {
            Arac gelenArac = _aracRepository.GetById(arac.Id);
            gelenArac.Aciklama = arac.Aciklama;
            gelenArac.Marka = arac.Marka;
            gelenArac.Model = arac.Model;
            gelenArac.Plaka = arac.Plaka;
            gelenArac.Renk = arac.Renk;
            gelenArac.Yil = arac.Yil;
            gelenArac.Kilometre = arac.Kilometre;
            gelenArac.GunlukFiyat = arac.GunlukFiyat;
            gelenArac.MusaitMi = arac.MusaitMi;
            gelenArac.Yakit = arac.Yakit;
            gelenArac.Sinif = arac.Sinif;
            gelenArac.Vites = arac.Vites;
            gelenArac.KoltukSayisi = arac.KoltukSayisi;
            gelenArac.YasSiniri = arac.YasSiniri;
            gelenArac.EhliyetYasSiniri = arac.EhliyetYasSiniri;

            string cokluResim = Path.GetExtension(Request.Files[0].FileName);
            if (cokluResim != "")
            {
                foreach (var detay in DetayResim)
                {
                    string dosya_adi = Guid.NewGuid().ToString().Replace("-", "");
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string tamyol = "/Areas/admin/External/Arac/" + dosya_adi + uzanti;
                    detay.SaveAs(Server.MapPath(tamyol));
                    var img = new Resim
                    {
                        ResimUrl = tamyol
                    };
                    img.AracId = arac.Id;
                    _resimRepository.Insert(img);
                    _resimRepository.Save();
                }
            }
            _aracRepository.Save();
            TempData["Bilgi"] = "Araç düzenleme işleminiz başarılı.";
            return RedirectToAction("Index", "Arac");
        }

        public ActionResult ResimSil(int id)
        {
            Resim dbResim = _resimRepository.GetById(id);
            if (dbResim == null)
            {
                TempData["Bilgi"] = "Resim bulunamadı !";
                return RedirectToAction("Index", "Arac");
            }
            string file_name = dbResim.ResimUrl;
            string path = Server.MapPath(file_name);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
                file.Delete();
            _resimRepository.Delete(id);
            _resimRepository.Save();
            TempData["Bilgi"] = "Resim silme işleminiz başarılı!";
            return RedirectToAction("Index", "Arac");
        }

        public ActionResult Sil(int id)
        {
            Arac dbArac = _aracRepository.GetById(id);
            var dbDetayResim = _resimRepository.GetMany(x => x.AracId == id);
            if (dbArac == null)
            {
                TempData["Bilgi"] = "Araç bulunamadı !";
                return RedirectToAction("Index", "Arac");
            }
            if (dbDetayResim != null)
            {
                foreach (var item in dbDetayResim)
                {
                    string detayPath = Server.MapPath(item.ResimUrl);
                    FileInfo files = new FileInfo(detayPath);
                    if (files.Exists) // dosyanın varlığı kontrol ediliyor. fiziksel olarak varsa siliniyor.
                        files.Delete();
                }
            }
            _aracRepository.Delete(id);
            _aracRepository.Save();
            TempData["Bilgi"] = "Araç başarıyla silindi";
            return RedirectToAction("Index", "Arac");
        }
    }
}