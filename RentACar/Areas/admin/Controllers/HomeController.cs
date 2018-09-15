using RentACar.Areas.admin.Class;
using RentACar.Areas.admin.Models.ViewModels;
using RentACar.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Areas.admin.Controllers
{
    [AdminPersonelAuth]
    public class HomeController : Controller
    {
        private readonly IIslemRepository _islemRepository;
        private readonly IAracRepository _aracRepository;

        public HomeController(IIslemRepository islemRepository, IAracRepository aracRepository)
        {
            _islemRepository = islemRepository;
            _aracRepository = aracRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {           
            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                MusaitAracSayisi = _aracRepository.GetMany(x => x.MusaitMi == true).Count(),
                DoluAracSayisi = _aracRepository.GetMany(x => x.MusaitMi == false).Count(),
                YeniRezervasyonSayi = _islemRepository.GetMany(x => x.Durum == "Yeni").Count(),
                ToplamKiralamaBuguneKadar = _islemRepository.Count()
            };
            return View(model);
        }
    }
}