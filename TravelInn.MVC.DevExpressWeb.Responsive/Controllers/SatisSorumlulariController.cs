using SharedKernel.Data;
using System;
using System.Web.Mvc;
using TravelInn.Data;
using TravelInn.Data.ViewModelRepository;
using TravelInn.Data.ViewModels;

namespace TravelInn.MVC.DevExpressWeb.Responsive.Controllers
{
    [Authorize]
    public class SatisSorumlulariController : Controller
    {
        private GenericRepository<SatisSorumlusu, Log> repo;
        private SatisSorumlusuViewModelRepository repoViewModel;

        public SatisSorumlulariController(GenericRepository<SatisSorumlusu, Log> _repo)
        {
            repo = _repo;
            repoViewModel = new SatisSorumlusuViewModelRepository();
        }

        // GET: SatisSorumlulari
        public ActionResult Index()
        {
            ViewBag.ControllerToMenu = "SatisSorumlulari";
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialSatisSorumlulari()
        {
            return PartialView("_GridViewPartialSatisSorumlulari", repoViewModel.GetList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialSatisSorumlulariAddNew(SatisSorumlusuViewModel item)
        {
            if (ModelState.IsValid)
            {

                var opr = repoViewModel.Add(item);

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }

                return PartialView("_GridViewPartialSatisSorumlulari", repoViewModel.GetList());

            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return PartialView("_GridViewPartialSatisSorumlulari", repoViewModel.GetList());

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialSatisSorumlulariUpdate(SatisSorumlusuViewModel item)
        {
            if (ModelState.IsValid)
            {

                var opr = repoViewModel.Update(item, repo.FindByKey(item.Id));

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }

                return PartialView("_GridViewPartialSatisSorumlulari", repoViewModel.GetList());

            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return PartialView("_GridViewPartialSatisSorumlulari", repoViewModel.GetList());

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialSatisSorumlulariDelete(System.Int32 Id)
        {
            if (Id >= 0)
            {
                var opr = repoViewModel.Remove(Id);

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }
            }

            return PartialView("_GridViewPartialSatisSorumlulari", repoViewModel.GetList());

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