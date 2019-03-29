using DevExpress.Web.Mvc;
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

        public ActionResult Error()
        {
            return View();
        }


        [ValidateInput(false)]
        public ActionResult FileManagerPartial()
        {
            return PartialView("_FileManagerPartial", HomeControllerFileManagerSettings.Model);
        }

        public FileStreamResult FileManagerPartialDownload()
        {
            return FileManagerExtension.DownloadFiles(HomeControllerFileManagerSettings.DownloadSettings, HomeControllerFileManagerSettings.Model);
        }

        [ValidateInput(false)]
        public ActionResult FileManager1Partial()
        {
            return PartialView("_FileManager1Partial", HomeControllerFileManager1Settings.Model);
        }

        public FileStreamResult FileManager1PartialDownload()
        {
            return FileManagerExtension.DownloadFiles(HomeControllerFileManager1Settings.DownloadSettings, HomeControllerFileManager1Settings.Model);
        }
    }
    public class HomeControllerFileManager1Settings
    {
        public const string RootFolder = @"~\";

        public static string Model { get { return RootFolder; } }
        public static DevExpress.Web.Mvc.FileManagerSettings DownloadSettings
        {
            get
            {
                var settings = new DevExpress.Web.Mvc.FileManagerSettings { Name = "FileManager1" };
                settings.SettingsEditing.AllowDownload = true;
                return settings;
            }
        }
    }

    public class HomeControllerFileManagerSettings
    {
        public const string RootFolder = @"~\";

        public static string Model { get { return RootFolder; } }
        public static DevExpress.Web.Mvc.FileManagerSettings DownloadSettings
        {
            get
            {
                var settings = new DevExpress.Web.Mvc.FileManagerSettings { Name = "FileManager" };
                settings.SettingsEditing.AllowDownload = true;
                return settings;
            }
        }
    }


    public enum HeaderViewRenderMode { Full, Title }
}