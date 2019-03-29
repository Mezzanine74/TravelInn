using DevExpress.Web.Mvc;
using SharedKernel.Data;
using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using TravelInn.Common;
using TravelInn.Data;
using TravelInn.Data.ViewModelRepository;
using TravelInn.Data.ViewModels;
using TravelInn.MVC.DevExpressWeb.Responsive.HelperClasses;

namespace TravelInn.MVC.DevExpressWeb.Responsive.Controllers
{
    [Authorize]
    public class CariVeOdemelerController : Controller
    {
        private GenericRepository<Cari, Log> repoCari;
        private GenericRepository<Odeme, Log> repoOdeme;
        private GenericRepository<Firma, Log> repoFirma;
        private GenericRepository<Musteri, Log> repoMusteri;
        private GenericRepository<Tur, Log> repoTur;
        private GenericRepository<Otel, Log> repoOtel;
        private GenericRepository<Banka, Log> repoBanka;
        private GenericRepository<Uyruk, Log> repoUyruk;
        private GenericRepository<SatisSorumlusu, Log> repoSatisSorumlusu;
        private GenericRepository<View_CariOdemeExcel, Log> repoViewExcel;
        private GenericRepository<View_YaklasanKayitlar, Log> repoViewYaklasanTurlar;
        private GenericRepository<View_CariSearch, Log> repoView_CariSearch;
        private OperationResult opr = new OperationResult();
        private Data.ViewModelRepository.CariViewModelRepository repoCariViewModelRepository;
        private Data.ViewModelRepository.OdemeViewModelRepository repoOdemeViewModelRepository;
        private Data.ViewModelRepository.CariConfirmationRepository repoCariConfirmationRepository;

        public CariVeOdemelerController(
            GenericRepository<Cari, Log> _repoCari,
            GenericRepository<Odeme, Log> _repoOdeme,
            GenericRepository<Firma, Log> _repoFirma,
            GenericRepository<Musteri, Log> _repoMusteri,
            GenericRepository<Tur, Log> _repoTur,
            GenericRepository<Otel, Log> _repoOtel,
            GenericRepository<Banka, Log> _repoBanka,
            GenericRepository<Uyruk, Log> _repoUyruk,
            GenericRepository<SatisSorumlusu, Log> _repoSatisSorumlusu,
            GenericRepository<View_CariOdemeExcel, Log> _repoViewExcel,
            GenericRepository<View_YaklasanKayitlar, Log> _repoViewYaklasanTurlar,
            GenericRepository<View_CariSearch, Log> _repoView_CariSearch
            )
        {
            repoCari = _repoCari;
            repoOdeme = _repoOdeme;
            repoFirma = _repoFirma;
            repoMusteri = _repoMusteri;
            repoTur = _repoTur;
            repoOtel = _repoOtel;
            repoBanka = _repoBanka;
            repoUyruk = _repoUyruk;
            repoSatisSorumlusu = _repoSatisSorumlusu;
            repoViewExcel = _repoViewExcel;
            repoViewYaklasanTurlar = _repoViewYaklasanTurlar;
            repoView_CariSearch = _repoView_CariSearch;
            repoCariViewModelRepository = new CariViewModelRepository();
            repoOdemeViewModelRepository = new OdemeViewModelRepository();
            repoCariConfirmationRepository = new CariConfirmationRepository();
        }

        // GET: CariVeOdemeler
        public ActionResult Index(int frmId = 0)
        {

            if (Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Index", "MobileCariVeOdemeler", new { frmId });
            }

            ViewBag.Firma = repoFirma.FindByKey(frmId)?.Ismi;
            ViewBag.ControllerToMenu = "CariVeOdemeler";

            FirmasTabData frmTab = new FirmasTabData();
            foreach (FirmaTabData item in frmTab.Data)
            {
                if (string.IsNullOrEmpty(Request.QueryString["frmId"]?.ToString())
                    || string.IsNullOrWhiteSpace(Request.QueryString["frmId"]?.ToString())
                    || Request.QueryString["frmId"]?.ToString() == "0")
                {
                    return RedirectToAction("Index", new { frmId = item.Firma.Id });
                }
            }

            return View(frmTab);
        }

        /// <summary>
        /// CARI
        /// </summary>
        [ValidateInput(false)]
        public ActionResult GridViewPartialCari(int frmId = 0)
        {
            ViewBag.Musteri = repoMusteri.All();
            ViewBag.Tur = repoTur.All();
            ViewBag.Otel = repoOtel.All();
            ViewBag.Uyruk = repoUyruk.All();
            ViewBag.SatisSorumlusu = repoSatisSorumlusu.All();

            return PartialView("_GridViewPartialCari", repoCariViewModelRepository.GetList(frmId));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialCariAddNew(CariViewModel item, int frmId = 0)
        {
            item.FirmaId = frmId;

            if (ModelState.IsValid)
            {

                var opr = repoCariViewModelRepository.Add(item);

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }

                ViewBag.Musteri = repoMusteri.All();
                ViewBag.Tur = repoTur.All();
                ViewBag.Otel = repoOtel.All();
                ViewBag.Uyruk = repoUyruk.All();
                ViewBag.SatisSorumlusu = repoSatisSorumlusu.All();

                ViewData["EditableCari"] = item;
                return PartialView("_GridViewPartialCari", repoCariViewModelRepository.GetList(frmId));

            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            ViewData["EditableCari"] = item;
            return PartialView("_GridViewPartialCari", repoCariViewModelRepository.GetList(frmId));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialCariUpdate(CariViewModel item, int frmId = 0)
        {
            item.FirmaId = frmId;

            if (ModelState.IsValid)
            {

                var opr = repoCariViewModelRepository.Update(item);

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }

                ViewBag.Musteri = repoMusteri.All();
                ViewBag.Tur = repoTur.All();
                ViewBag.Otel = repoOtel.All();
                ViewBag.Uyruk = repoUyruk.All();
                ViewBag.SatisSorumlusu = repoSatisSorumlusu.All();

                ViewData["EditableCari"] = item;
                return PartialView("_GridViewPartialCari", repoCariViewModelRepository.GetList(frmId));

            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            ViewData["EditableCari"] = item;
            return PartialView("_GridViewPartialCari", repoCariViewModelRepository.GetList(frmId));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialCariDelete(System.Int32 Id, int frmId = 0)
        {

            if (Id >= 0)
            {
                opr = repoCariViewModelRepository.Remove(Id);

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }
            }

            ViewBag.Musteri = repoMusteri.All();
            ViewBag.Tur = repoTur.All();
            ViewBag.Otel = repoOtel.All();
            ViewBag.Uyruk = repoUyruk.All();
            ViewBag.SatisSorumlusu = repoSatisSorumlusu.All();

            return PartialView("_GridViewPartialCari", repoCariViewModelRepository.GetList(frmId));

        }

        /// <summary>
        /// ODEME
        /// </summary>
        [ValidateInput(false)]
        public ActionResult GridViewPartialOdeme(int frmId = 0)
        {
            ViewBag.Banka = repoBanka.All();

            return PartialView("_GridViewPartialOdeme", repoOdemeViewModelRepository.GetList(frmId));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialOdemeAddNew(OdemeViewModel item, int frmId = 0)
        {
            item.FirmaId = frmId;

            if (ModelState.IsValid)
            {

                var opr = repoOdemeViewModelRepository.Add(item);

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }

                ViewBag.Banka = repoBanka.All();

                ViewData["EditableOdeme"] = item;
                return PartialView("_GridViewPartialOdeme", repoOdemeViewModelRepository.GetList(frmId));

            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            ViewData["EditableOdeme"] = item;
            return PartialView("_GridViewPartialOdeme", repoOdemeViewModelRepository.GetList(frmId));

        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialOdemeUpdate(OdemeViewModel item, int frmId = 0)
        {
            item.FirmaId = frmId;

            if (ModelState.IsValid)
            {

                var opr = repoOdemeViewModelRepository.Update(item);

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }

                ViewBag.Banka = repoBanka.All();

                ViewData["EditableOdeme"] = item;
                return PartialView("_GridViewPartialOdeme", repoOdemeViewModelRepository.GetList(frmId));

            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            ViewData["EditableOdeme"] = item;
            return PartialView("_GridViewPartialOdeme", repoOdemeViewModelRepository.GetList(frmId));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialOdemeDelete(System.Int32 Id, int frmId = 0)
        {
            if (Id >= 0)
            {
                opr = repoOdemeViewModelRepository.Remove(Id);

                if (!opr.Success)
                {
                    ViewData["EditError"] = opr.MessageList[0];
                }
            }

            ViewBag.Banka = repoBanka.All();

            return PartialView("_GridViewPartialOdeme", repoOdemeViewModelRepository.GetList(frmId));

        }

        public ActionResult GridViewPartialCariOdemeExcel(int frmId = 0)
        {
            return PartialView("_GridViewPartialCariOdemeExcel", repoViewExcel.FindBy(c => c.FirmaId == frmId));
        }

        public ActionResult Export()
        {
            return View();
        }

        public ActionResult YaklasanTurlar()
        {
            ViewBag.ControllerToMenu = "YaklasanTurlar";
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewYaklasanTurlarPartial()
        {
            var bugun = LocalTime.GetIstanbul().AddDays(-1);
            return PartialView("_GridViewYaklasanTurlarPartial", repoViewYaklasanTurlar.FindBy(c => c.Tarih >= bugun));
        }

        public ActionResult CariSearch()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewCariSearchPartial(string kolonAdi, string kolonFiltreDegeri)
        {

            var parameter = Expression.Parameter(typeof(View_CariSearch), "t");

            // t.Total
            var propertyExpression = Expression.PropertyOrField(parameter, kolonAdi);

            // "ARJANTIN"
            var constant = Expression.Constant(kolonFiltreDegeri, typeof(string));

            // t.Uyrugu == "ARJANTIN"
            var equalExpression = Expression.Equal(propertyExpression, constant);

            // t => t.Uyrugu == "ARJANTIN"
            var lambda = Expression.Lambda(equalExpression, parameter);

            var typedExpression = (Expression<Func<View_CariSearch, bool>>)lambda;

            return PartialView("_GridViewCariSearchPartial", repoView_CariSearch.FindBy(typedExpression).ToList());
        }

        public ActionResult ComboBoxVNPartial()
        {
            return PartialView("_ComboBoxVNPartial",
                repoCari
                    .FindBy(c => c.VoucherNo != null)
                    .Select(c =>
                        new
                        {
                            VN = c.VoucherNo,
                            FirmaId = c.FirmaId,
                            FirmaAdi = c.Firma.Ismi,
                            Aciklama = c.Aciklama
                        }));
        }

        public ActionResult ComboBoxMusterilerPartial()
        {
            return PartialView("_ComboBoxMusterilerPartial",
                repoCari
                    .FindBy(c => c.MusteriId != null)
                    .Select(c =>
                        new
                        {
                            MusteriAdi = c.Musteri.Musteri_AdiSoyadi,
                            FirmaId = c.FirmaId,
                            FirmaAdi = c.Firma.Ismi,
                            Aciklama = c.Aciklama
                        }));
        }

        public ActionResult ComboBoxOtellerPartial()
        {
            return PartialView("_ComboBoxOtellerPartial",
                repoCari
                    .FindBy(c => c.OtelId != null)
                    .Select(c =>
                        new
                        {
                            OtelAdi = c.Otel.Otel_Adi,
                            FirmaId = c.FirmaId,
                            FirmaAdi = c.Firma.Ismi,
                            Aciklama = c.Aciklama
                        }));
        }

        public ActionResult ComboBoxTurlarPartial()
        {
            return PartialView("_ComboBoxTurlarPartial",
                repoCari
                    .FindBy(c => c.TurId != null)
                    .Select(c =>
                        new
                        {
                            TurAdi = c.Tur.Tur_Adi,
                            FirmaId = c.FirmaId,
                            FirmaAdi = c.Firma.Ismi,
                            Aciklama = c.Aciklama
                        }));
        }

        public ActionResult ComboBoxSorumlularPartial()
        {
            return PartialView("_ComboBoxSorumlularPartial",
                repoCari
                    .FindBy(c => c.SatisSorumlusu_Id != null)
                    .Select(c =>
                        new
                        {
                            Sorumlu = c.SatisSorumlusu.Ismi,
                            FirmaId = c.FirmaId,
                            FirmaAdi = c.Firma.Ismi,
                            Aciklama = c.Aciklama
                        }));
        }

        // File Manager
        [ValidateInput(false)]
        public ActionResult FileManagerCariConfirmationPartial(string rootFolder)
        {
            //if (rootFolder != null)
            //{
            //    DirectoryInfo di = Directory.CreateDirectory(Server.MapPath(rootFolder));
            //    TestControllerFileManagerCariConfirmationSettings.RootFolder = rootFolder;
            //}

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

        [HttpPost]
        public ActionResult ConfirmationUpload(string path, int id)
        {
            return Json(repoCariConfirmationRepository.Upload(path, id));
        }

        [HttpPost]
        public JsonResult ConfirmationRemove(string path, int id)
        {
            return Json(repoCariConfirmationRepository.Remove(path, id));
        }

        public ActionResult ReadEmail(int id = 0)
        {
            return View();
        }

        public ActionResult RichEditEmailPartial(int id = 0)
        {
            ViewBag.Email = repoCariConfirmationRepository.GetEmailPath(id) == String.Empty ? string.Empty : Server.MapPath(repoCariConfirmationRepository.GetEmailPath(id));
            return PartialView("_RichEditEmailPartial");
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