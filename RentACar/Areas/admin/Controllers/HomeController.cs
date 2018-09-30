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
        [AdminPersonelAuth]
        public ActionResult Index()
        {           
            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                AracSayisi = _aracRepository.GetAll().Count(),
                YeniRezervasyonSayi = _islemRepository.GetMany(x=>x.RezervasyonTarihi== DateTime.Today).Count(),
                ToplamKiralamaBuguneKadar = _islemRepository.GetAll().Count()
            };
            return View(model);
        }
    }
}