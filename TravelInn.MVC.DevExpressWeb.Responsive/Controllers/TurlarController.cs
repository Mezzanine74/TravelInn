using SharedKernel.Data;
using System;
using System.Web.Mvc;
using TravelInn.Data;
using TravelInn.Data.ViewModelRepository;
using TravelInn.Data.ViewModels;

namespace TravelInn.MVC.DevExpressWeb.Responsive.Controllers
{
    [Authorize]
    public class TurlarController : Controller
    {
        private GenericRepository<Tur, Log> repo;
        private TurViewModelRepository repoViewModel;

        public TurlarController(GenericRepository<Tur, Log> _repo)
        {
            repo = _repo;
            repoViewModel = new TurViewModelRepository();
        }

        // GET: Turlar
        public ActionResult Index()
        {
            ViewBag.ControllerToMenu = "Turlar";
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialTurlar()
        {
            return PartialView("_GridViewPartialTurlar", repoViewModel.GetList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialTurlarAddNew(TurViewModel item)
        {
            if (ModelState.IsValid)
            {

                var opr = repoViewModel.Add(item);

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }

                return PartialView("_GridViewPartialTurlar", repoViewModel.GetList());

            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return PartialView("_GridViewPartialTurlar", repoViewModel.GetList());

        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialTurlarUpdate(TurViewModel item)
        {
            if (ModelState.IsValid)
            {

                var opr = repoViewModel.Update(item, repo.FindByKey(item.Id));

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }

                return PartialView("_GridViewPartialTurlar", repoViewModel.GetList());

            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return PartialView("_GridViewPartialTurlar", repoViewModel.GetList());

        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialTurlarDelete(System.Int32 Id)
        {
            if (Id >= 0)
            {
                var opr = repoViewModel.Remove(Id);

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }
            }

            return PartialView("_GridViewPartialTurlar", repoViewModel.GetList());

        }

        public JsonResult GetByKey(string id = "")
        {
            int key;
            Int32.TryParse(id, out key);

            var _result = repo.FindByKey(key);

            return Json(new { Telefon = _result?.Telefon, Adres = _result?.Adres, Email = _result?.Email }, JsonRequestBehavior.AllowGet);
        }
    }
}