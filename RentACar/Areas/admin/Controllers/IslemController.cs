using PagedList;
using RentACar.Areas.admin.Class;
using RentACar.Core.Infrastructure;
using RentACar.Data;
using System.Linq;
using System.Web.Mvc;

namespace RentACar.Areas.admin.Controllers
{
    public class IslemController : Controller
    {
        private readonly IIslemRepository _islemRepository;
        private readonly IMusteriRepository _musteriRepository;
        private readonly IAracRepository _aracRepository;

        public IslemController(IIslemRepository islemRepository, IMusteriRepository musteriRepository, IAracRepository aracRepository)
        {
            _islemRepository = islemRepository;
            _musteriRepository = musteriRepository;
            _aracRepository = aracRepository;
        }

        [HttpGet]
        [AdminPersonelAuth]
        public ActionResult Index(int sayfa = 1)
        {
            int sayfaBoyutu = 5;
            var islemListesi = _islemRepository.GetAll().OrderByDescending(x => x.Id).ToPagedList(sayfa, sayfaBoyutu);
            return View(islemListesi);
        }

        [HttpGet]
        [AdminPersonelAuth]
        public ActionResult Ekle()
        {
            ViewBag.Musteri = _musteriRepository.GetAll().ToList();
            ViewBag.Arac = _aracRepository.GetAll().ToList();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [AdminPersonelAuth]
        public ActionResult Ekle(Islem islem, int MusteriId, int AracId)
        {
            islem.MusteriId = MusteriId;
            islem.AracId = AracId;
            _islemRepository.Insert(islem);
            _islemRepository.Save();
            TempData["Bilgi"] = "İşlem eklemeniz başarılı";
            return RedirectToAction("Index", "Islem");
        }

        [AdminAuth]
        public ActionResult Sil(int id)
        {
            Islem islem = _islemRepository.GetById(id);
            if (islem == null)
                TempData["Bilgi"] = "İşlem bulunamadı!";
            _islemRepository.Delete(id);
            _islemRepository.Save();
            TempData["Bilgi"] = "Kiralama işlemi başarıyla silindi";
            return RedirectToAction("Index", "Islem");
        }

        [HttpGet]
        [ValidateInput(false)]
        [AdminPersonelAuth]
        public ActionResult Duzenle(int id)
        {
            Islem gelenIslem = _islemRepository.GetById(id);
            if (gelenIslem == null)
                TempData["Bilgi"] = "İşlem bulunamadı!";
            ViewBag.Musteri = _musteriRepository.GetAll().ToList();
            ViewBag.Arac = _aracRepository.GetAll().ToList();
            return View(gelenIslem);
        }

        [HttpPost]
        [ValidateInput(false)]
        [AdminPersonelAuth]
        public ActionResult Duzenle(Islem islem)
        {
            Islem gelenIslem = _islemRepository.GetById(islem.Id);
            gelenIslem.MusteriId = islem.MusteriId;
            gelenIslem.AracId = islem.AracId;
            gelenIslem.Tutar = islem.Tutar;
            gelenIslem.AlimTarihi = islem.AlimTarihi;
            gelenIslem.TeslimTarihi = islem.TeslimTarihi;
            gelenIslem.TahminiKm = islem.TahminiKm;

            _islemRepository.Save();
            TempData["Bilgi"] = "Kiralama işlem düzenlemeniz başarılı.";
            return RedirectToAction("Index", "Islem");
        }

        [AdminPersonelAuth]
        public ActionResult GecmisIslemler(int sayfa = 1)
        {
            int sayfaBoyutu = 5;
            var gecmisIslemler=_islemRepository.GetAll().OrderByDescending(x => x.Id).ToPagedList(sayfa, sayfaBoyutu);
            return View("Index",gecmisIslemler);
        }
    }
}