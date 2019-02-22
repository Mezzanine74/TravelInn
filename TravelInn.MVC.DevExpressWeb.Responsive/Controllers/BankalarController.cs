using SharedKernel.Data;
using System.Web.Mvc;
using TravelInn.Data;

namespace TravelInn.MVC.DevExpressWeb.Responsive.Controllers
{
    [Authorize]
    public class BankalarController : Controller
    {
        private GenericRepository<Banka, Log> repo;

        public BankalarController(GenericRepository<Banka, Log> _repo)
        {
            repo = _repo;
        }

        // GET: Bankalar
        public ActionResult Index()
        {
            ViewBag.ControllerToMenu = "Bankalar";
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialBankalar()
        {
            return PartialView("_GridViewPartialBankalar", repo.All());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialBankalarAddNew(Banka item)
        {
            if (ModelState.IsValid)
            {

                var opr = repo.Add(item);

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }

                return PartialView("_GridViewPartialBankalar", repo.All());

            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return PartialView("_GridViewPartialBankalar", repo.All());

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialBankalarUpdate(Banka item)
        {
            if (ModelState.IsValid)
            {

                var opr = repo.Update(item);

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }

                return PartialView("_GridViewPartialBankalar", repo.All());

            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return PartialView("_GridViewPartialBankalar", repo.All());

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialBankalarDelete(System.Int32 Id)
        {
            if (Id >= 0)
            {
                var opr = repo.Remove(Id);

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }
            }

            return PartialView("_GridViewPartialBankalar", repo.All());

        }
    }
}