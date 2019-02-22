using SharedKernel.Data;
using System.Web.Mvc;
using TravelInn.Data;
using TravelInn.Data.ViewModelRepository;
using TravelInn.Data.ViewModels;

namespace TravelInn.MVC.DevExpressWeb.Responsive.Controllers
{
    [Authorize]
    public class UyruklarController : Controller
    {
        private GenericRepository<Uyruk, Log> repo;
        private UyrukViewModelRepository repoViewModel;

        public UyruklarController(GenericRepository<Uyruk, Log> _repo)
        {
            repo = _repo;
            repoViewModel = new UyrukViewModelRepository();
        }

        // GET: Uyruklar
        public ActionResult Index()
        {
            ViewBag.ControllerToMenu = "Uyruklar";
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialUyruklar()
        {
            return PartialView("_GridViewPartialUyruklar", repoViewModel.GetList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUyruklarAddNew(UyrukViewModel item)
        {
            if (ModelState.IsValid)
            {

                var opr = repoViewModel.Add(item);

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }

                return PartialView("_GridViewPartialUyruklar", repoViewModel.GetList());

            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return PartialView("_GridViewPartialUyruklar", repoViewModel.GetList());

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUyruklarUpdate(UyrukViewModel item)
        {
            if (ModelState.IsValid)
            {

                var opr = repoViewModel.Update(item, repo.FindByKey(item.Id));

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }

                return PartialView("_GridViewPartialUyruklar", repoViewModel.GetList());

            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return PartialView("_GridViewPartialUyruklar", repoViewModel.GetList());

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUyruklarDelete(System.Int32 Id)
        {
            if (Id >= 0)
            {
                var opr = repoViewModel.Remove(Id);

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }
            }

            return PartialView("_GridViewPartialUyruklar", repoViewModel.GetList());

        }
    }
}