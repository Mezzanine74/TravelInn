using SharedKernel.Data;
using System.Web.Mvc;
using TravelInn.Common;
using TravelInn.Data;

namespace TravelInn.MVC.DevExpressWeb.Responsive.Controllers
{
    [Authorize]
    public class FirmaTemsilcileriController : Controller
    {
        private GenericRepository<FirmaTemsilcisi, Log> repo;

        public FirmaTemsilcileriController(GenericRepository<FirmaTemsilcisi, Log> _repo)
        {
            repo = _repo;
        }

        // GET: FirmaTemsilcileri
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewFirmaTemsilcileriPartial(int FirmaId = 0)
        {
            ViewBag.FirmaId = FirmaId;
            return PartialView("~/Views/Firmalar/_GridViewFirmaTemsilcileriPartial.cshtml", repo.FindBy(c => c.FirmaId == FirmaId));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewFirmaTemsilcileriPartialAddNew(FirmaTemsilcisi item)
        {
            var ort = new OperationResult();

            if (ModelState.IsValid)
            {
                ort = repo.Add(item);

                if (!ort.Success)
                {
                    ViewData["EditError"] = ort.MessageList[0];
                }

            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("~/Views/Firmalar/_GridViewFirmaTemsilcileriPartial.cshtml", repo.FindBy(c => c.FirmaId == item.FirmaId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewFirmaTemsilcileriPartialUpdate(FirmaTemsilcisi item)
        {
            var ort = new OperationResult();

            if (ModelState.IsValid)
            {
                ort = repo.Update(item);

                if (!ort.Success)
                {
                    ViewData["EditError"] = ort.MessageList[0];
                }

            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("~/Views/Firmalar/_GridViewFirmaTemsilcileriPartial.cshtml", repo.FindBy(c => c.FirmaId == item.FirmaId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewFirmaTemsilcileriPartialDelete(System.Int32 Id, int FirmaId = 0)
        {
            var ort = new OperationResult();

            if (Id > 0)
            {
                ort = repo.Remove(Id);

                if (!ort.Success)
                {
                    ViewData["EditError"] = ort.MessageList[0];
                }

            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("~/Views/Firmalar/_GridViewFirmaTemsilcileriPartial.cshtml", repo.FindBy(c => c.FirmaId == FirmaId));
        }
    }
}