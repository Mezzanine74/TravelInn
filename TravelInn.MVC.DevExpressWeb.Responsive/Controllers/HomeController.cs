using System.Web.Mvc;

namespace TravelInn.MVC.DevExpressWeb.Responsive.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            if (Request.QueryString["frmId"] != null)
            {
                return RedirectToAction("Index", "CariVeOdemeler", new { frmId = Request.QueryString["frmId"] });
            }

            //return RedirectToAction("Index", "CariVeOdemeler");
            return View();
        }
    }

    public enum HeaderViewRenderMode { Full, Title }
}