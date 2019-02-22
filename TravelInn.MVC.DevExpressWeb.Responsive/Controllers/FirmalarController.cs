using SharedKernel.Data;
using System.Linq;
using System.Web.Mvc;
using TravelInn.Common;
using TravelInn.Data;

namespace TravelInn.MVC.DevExpressWeb.Responsive.Controllers
{
    [Authorize]
    public class FirmalarController : Controller
    {
        private GenericRepository<Firma, Log> repo;

        public FirmalarController(GenericRepository<Firma, Log> _repo)
        {
            repo = _repo;
        }

        // GET: Firmalar
        public ActionResult Index()
        {
            if (Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Index", "MobileFirmalar");
            }

            ViewBag.ControllerToMenu = "Firmalar";

            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewFirmalarPartial()
        {
            return PartialView("_GridViewFirmalarPartial", repo.All());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewFirmalarPartialAddNew(Firma item)
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
            return PartialView("_GridViewFirmalarPartial", repo.All());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewFirmalarPartialUpdate(Firma item)
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
            return PartialView("_GridViewFirmalarPartial", repo.All());

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewFirmalarPartialDelete(System.Int32 Id)
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
            return PartialView("_GridViewFirmalarPartial", repo.All());

        }

        public ActionResult ComboBoxFirmaPartial()
        {
            return PartialView("_ComboBoxFirmaPartial", repo.All().OrderBy(c => c.Ismi));
        }

    }
}