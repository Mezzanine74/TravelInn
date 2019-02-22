using SharedKernel.Data;
using System.Linq;
using System.Web.Mvc;
using TravelInn.Data;

namespace TravelInn.MVC.DevExpressWeb.Responsive.Controllers
{
    [Authorize]
    public class BakiyeController : Controller
    {
        private GenericRepository<View_FirmaBakiye, Log> repo;

        public BakiyeController(GenericRepository<View_FirmaBakiye, Log> _repo)
        {
            repo = _repo;
        }

        // GET: Bakiyeler
        public ActionResult Index()
        {
            ViewBag.ControllerToMenu = "Bakiye";
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialBakiye(int frmId = 0)
        {
            var filtrele = frmId > 0;
            ViewBag.Filtrele = filtrele;
            return PartialView("_GridViewPartialBakiye", filtrele ? repo.FindBy(c => c.FirmaId == frmId) : repo.All().OrderBy(c => c.Firma));
        }
    }
}