using SharedKernel.Data;
using System;
using System.Web.Mvc;
using TravelInn.Data;
using TravelInn.Data.ViewModelRepository;

namespace TravelInn.MVC.DevExpressWeb.Responsive.Controllers
{
    [Authorize]
    public class LogController : Controller
    {
        private GenericRepository<Log, Log> repo;
        private Data.ViewModelRepository.CariLogRepository cariLogRepo = new CariLogRepository();
        private Data.ViewModelRepository.OdemeLogRepository odemeLogRepo = new OdemeLogRepository();

        public LogController(GenericRepository<Log, Log> _repo)
        {
            repo = _repo;
        }

        // GET: Log
        public ActionResult Index()
        {
            ViewBag.ControllerToMenu = "GunlukAktiviteler";
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialLog(string uniqeIdentifier)
        {
            if (uniqeIdentifier?.Trim().Length > 0)
            {
                return PartialView("_GridViewPartialLog", repo.FindBy(c => c.LogString.Contains(uniqeIdentifier)));
            }

            return PartialView("_GridViewPartialLog", null);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialCariLog(DateTime date)
        {
            return PartialView("_GridViewPartialCariLog", cariLogRepo.GetList(date));
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialOdemeLog(DateTime date)
        {
            return PartialView("_GridViewPartialOdemeLog", odemeLogRepo.GetList(date));
        }

    }
}