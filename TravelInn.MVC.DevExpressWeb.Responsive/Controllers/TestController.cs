using DevExpress.Web.Mvc;
using System.IO;
using System.Web.Mvc;

namespace TravelInn.MVC.DevExpressWeb.Responsive.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ohaa()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult FileManagerCariConfirmationPartial(string rootFolder)
        {
            if (rootFolder != null)
            {
                DirectoryInfo di = Directory.CreateDirectory(Server.MapPath(rootFolder));
                TestControllerFileManagerCariConfirmationSettings.RootFolder = rootFolder;
            }

            return PartialView("_FileManagerCariConfirmationPartial", TestControllerFileManagerCariConfirmationSettings.Model);
        }

        public FileStreamResult FileManagerCariConfirmationPartialDownload()
        {
            return FileManagerExtension.DownloadFiles(TestControllerFileManagerCariConfirmationSettings.DownloadSettings, TestControllerFileManagerCariConfirmationSettings.Model);
        }
    }
    public class TestControllerFileManagerCariConfirmationSettings
    {
        public static string RootFolder = @"~\Content\CariConfirmations\";

        public static string Model { get { return RootFolder; } }
        public static DevExpress.Web.Mvc.FileManagerSettings DownloadSettings
        {
            get
            {
                var settings = new DevExpress.Web.Mvc.FileManagerSettings { Name = "FileManagerCariConfirmation" };
                settings.SettingsEditing.AllowDownload = true;
                return settings;
            }
        }
    }

}