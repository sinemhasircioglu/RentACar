using PagedList;
using RentACar.Core.Infrastructure;
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
        public ActionResult Index(int sayfa = 1)
        {
            int sayfaBoyutu = 5;
            var musteriListesi = _musteriRepository.GetAll().OrderByDescending(x => x.Id).ToPagedList(sayfa, sayfaBoyutu);
            return View(musteriListesi);
        }
    }
}