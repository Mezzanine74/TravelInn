using SharedKernel.Data;
using System.Web.Mvc;
using TravelInn.Data;

namespace TravelInn.MVC.DevExpressWeb.Responsive.Controllers
{
    [Authorize]
    public class MobileFirmalarController : Controller
    {
        private GenericRepository<Firma, Log> repoFirma;

        public MobileFirmalarController(GenericRepository<Firma, Log> _repoFirma)
        {
            repoFirma = _repoFirma;
        }

        // GET: Firmalar
        public ActionResult Index()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Index", "Firmalar");
            }

            ViewBag.ControllerToMenu = "Firmalar";

            return View();
        }
    }
}