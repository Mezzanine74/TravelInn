using SharedKernel.Data;
using System;
using System.Web.Mvc;
using TravelInn.Common;
using TravelInn.Data;
using TravelInn.Data.ViewModelRepository;
using TravelInn.Data.ViewModels;

namespace TravelInn.MVC.DevExpressWeb.Responsive.Controllers
{
    [Authorize]
    public class MusterilerController : Controller
    {
        private GenericRepository<Musteri, Log> repo;
        private GenericRepository<Uyruk, Log> repoUyruk;
        private MusteriGenelViewModelRepository repoViewModel;
        private OperationResult opr = new OperationResult();

        public MusterilerController(GenericRepository<Musteri, Log> _repo, GenericRepository<Uyruk, Log> _repoUyruk)
        {
            repo = _repo;
            repoUyruk = _repoUyruk;
            repoViewModel = new MusteriGenelViewModelRepository();
        }

        // GET: Musteriler
        public ActionResult Index()
        {
            ViewBag.ControllerToMenu = "Musteriler";
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialMusteriler()
        {
            ViewBag.Uyruk = repoUyruk.All();
            return PartialView("_GridViewPartialMusteriler", repoViewModel.GetList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialMusterilerAddNew(MusteriViewModel item)
        {
            if (ModelState.IsValid)
            {

                var opr = repoViewModel.Add(item);

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }

                ViewBag.Uyruk = repoUyruk.All();

                return PartialView("_GridViewPartialMusteriler", repoViewModel.GetList());

            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return PartialView("_GridViewPartialMusteriler", repoViewModel.GetList());

        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialMusterilerUpdate(MusteriViewModel item)
        {
            if (ModelState.IsValid)
            {

                var opr = repoViewModel.Update(item, repo.FindByKey(item.Id));

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }

                ViewBag.Uyruk = repoUyruk.All();

                return PartialView("_GridViewPartialMusteriler", repoViewModel.GetList());

            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return PartialView("_GridViewPartialMusteriler", repoViewModel.GetList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialMusterilerDelete(System.Int32 Id)
        {
            if (Id >= 0)
            {
                opr = repoViewModel.Remove(Id);

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }
            }

            ViewBag.Uyruk = repoUyruk.All();

            return PartialView("_GridViewPartialMusteriler", repoViewModel.GetList());
        }

        public JsonResult GetByKey(string id = "")
        {
            int key;
            Int32.TryParse(id, out key);

            var _result = repo.FindByKey(key);

            return Json(new { Telefon = _result?.Telefon, Adres = _result?.Adres, Email = _result?.Email, UyrukId = _result?.Uyruk_Id }, JsonRequestBehavior.AllowGet);
        }

    }
}