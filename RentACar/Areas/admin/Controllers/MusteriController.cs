using PagedList;
using RentACar.Areas.admin.Class;
using RentACar.Core.Infrastructure;
using RentACar.Data;
using System.Linq;
using System.Web.Mvc;

namespace RentACar.Areas.admin.Controllers
{
    public class MusteriController : Controller
    {
        private readonly IMusteriRepository _musteriRepository;

        public MusteriController(IMusteriRepository musteriRepository)
        {
            _musteriRepository = musteriRepository;
        }

        [HttpGet]
        [AdminPersonelAuth]
        public ActionResult Index(int sayfa = 1)
        {
            int sayfaBoyutu = 5;
            var musteriListesi = _musteriRepository.GetAll().OrderByDescending(x => x.Id).ToPagedList(sayfa, sayfaBoyutu);
            return View(musteriListesi);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [AdminPersonelAuth]
        public ActionResult Ekle(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                _musteriRepository.Insert(musteri);
                _musteriRepository.Save();
            }
            TempData["Bilgi"] = "Müşteri ekleme işleminiz başarılı";
            return RedirectToAction("Index", "Musteri");
        }

        [AdminAuth]
        public ActionResult Sil(int id)
        {
            Musteri musteri = _musteriRepository.GetById(id);
            if (musteri == null)
                TempData["Bilgi"] = "Müşteri bulunamadı!";
            _musteriRepository.Delete(id);
            _musteriRepository.Save();
            TempData["Bilgi"] = "Müşteri başarıyla silindi";
            return RedirectToAction("Index", "Musteri");
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Duzenle(int id)
        {
            Musteri gelenMusteri = _musteriRepository.GetById(id);
            if (gelenMusteri == null)
                TempData["Bilgi"] = "Müşteri bulunamadı!";
            return View(gelenMusteri);
        }

        [HttpPost]
        [ValidateInput(false)]
        [AdminPersonelAuth]
        public ActionResult Duzenle(Musteri musteri)
        {
            Musteri gelenMusteri = _musteriRepository.GetById(musteri.Id);
            gelenMusteri.AdSoyad = musteri.AdSoyad;
            gelenMusteri.Email = musteri.Email;
            gelenMusteri.Sifre = musteri.Sifre;

            _musteriRepository.Save();
            TempData["Bilgi"] = "Müşteri düzenleme işleminiz başarılı.";
            return RedirectToAction("Index", "Musteri");
        }
    }
}