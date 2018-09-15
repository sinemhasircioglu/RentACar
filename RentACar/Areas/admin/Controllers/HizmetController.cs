using PagedList;
using RentACar.Areas.admin.Class;
using RentACar.Core.Infrastructure;
using RentACar.Data;
using System.Linq;
using System.Web.Mvc;

namespace RentACar.Areas.admin.Controllers
{
    [AdminPersonelAuth]
    public class HizmetController : Controller
    {
        private readonly IHizmetRepository _hizmetRepository;

        public HizmetController(IHizmetRepository hizmetRepository )
        {
            _hizmetRepository = hizmetRepository;
        }

        [HttpGet]
        public ActionResult Index(int sayfa = 1)
        {
            int sayfaBoyutu = 5;
            var hizmetListesi = _hizmetRepository.GetAll().OrderByDescending(x => x.Id).ToPagedList(sayfa, sayfaBoyutu);
            return View(hizmetListesi);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Ekle(Hizmet hizmet)
        {
            if (ModelState.IsValid)
            {
                _hizmetRepository.Insert(hizmet);
                _hizmetRepository.Save();
            }           
            TempData["Bilgi"] = "Hizmet ekleme işleminiz başarılı";
            return RedirectToAction("Index", "Hizmet");
        }

        public ActionResult Sil(int id)
        {
            Hizmet hizmet = _hizmetRepository.GetById(id);
            if (hizmet == null)
                TempData["Bilgi"] = "Hizmet bulunamadı!";
            _hizmetRepository.Delete(id);
            _hizmetRepository.Save();
            TempData["Bilgi"] = "Hizmet başarıyla silindi";
            return RedirectToAction("Index", "Hizmet");
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Duzenle(int id)
        {
            Hizmet gelenHizmet = _hizmetRepository.GetById(id);
            if (gelenHizmet == null)
                TempData["Bilgi"] = "Hizmet bulunamadı!";
            return View(gelenHizmet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Duzenle(Hizmet hizmet)
        {
            Hizmet gelenHizmet = _hizmetRepository.GetById(hizmet.Id);
            gelenHizmet.Ad = hizmet.Ad;
            gelenHizmet.Aciklama = hizmet.Aciklama;
            gelenHizmet.Tutar = hizmet.Tutar;

            _hizmetRepository.Save();
            TempData["Bilgi"] = "Hizmet düzenleme işleminiz başarılı.";
            return RedirectToAction("Index", "Hizmet");
        }
    }
}