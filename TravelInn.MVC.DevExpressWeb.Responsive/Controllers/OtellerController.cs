using SharedKernel.Data;
using System;
using System.Web.Mvc;
using TravelInn.Data;
using TravelInn.Data.ViewModelRepository;
using TravelInn.Data.ViewModels;

namespace TravelInn.MVC.DevExpressWeb.Responsive.Controllers
{
    [Authorize]
    public class OtellerController : Controller
    {
        private GenericRepository<Otel, Log> repo;
        private OtelViewModelRepository repoViewModel;

        public OtellerController(GenericRepository<Otel, Log> _repo)
        {
            repo = _repo;
            repoViewModel = new OtelViewModelRepository();
        }

        // GET: Oteller
        public ActionResult Index()
        {
            ViewBag.ControllerToMenu = "Oteller";
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialOteller()
        {
            return PartialView("_GridViewPartialOteller", repoViewModel.GetList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialOtellerAddNew(OtelViewModel item)
        {
            if (ModelState.IsValid)
            {

                var opr = repoViewModel.Add(item);

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }

                ViewData["Editable"] = item;
                return PartialView("_GridViewPartialOteller", repoViewModel.GetList());

            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            ViewData["Editable"] = item;
            return PartialView("_GridViewPartialOteller", repoViewModel.GetList());

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialOtellerUpdate(OtelViewModel item)
        {
            if (ModelState.IsValid)
            {

                var opr = repoViewModel.Update(item, repo.FindByKey(item.Id));

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }

                ViewData["Editable"] = item;
                return PartialView("_GridViewPartialOteller", repoViewModel.GetList());

            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            ViewData["Editable"] = item;
            return PartialView("_GridViewPartialOteller", repoViewModel.GetList());

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialOtellerDelete(System.Int32 Id)
        {
            if (Id >= 0)
            {
                var opr = repoViewModel.Remove(Id);

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }
            }

            return PartialView("_GridViewPartialOteller", repoViewModel.GetList());

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