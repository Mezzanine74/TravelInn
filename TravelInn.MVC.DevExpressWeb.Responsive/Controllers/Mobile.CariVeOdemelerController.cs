using SharedKernel.Data;
using System.Web.Mvc;
using TravelInn.Common;
using TravelInn.Data;
using TravelInn.MVC.DevExpressWeb.Responsive.HelperClasses;

namespace TravelInn.MVC.DevExpressWeb.Responsive.Controllers
{
    [Authorize]
    public class MobileCariVeOdemelerController : Controller
    {
        private GenericRepository<Cari, Log> repoCari;
        private GenericRepository<Odeme, Log> repoOdeme;
        private GenericRepository<Firma, Log> repoFirma;
        private GenericRepository<Musteri, Log> repoMusteri;
        private GenericRepository<Tur, Log> repoTur;
        private GenericRepository<Otel, Log> repoOtel;
        private GenericRepository<Banka, Log> repoBanka;
        private GenericRepository<SatisSorumlusu, Log> repoSatisSorumlusu;
        private GenericRepository<View_CariOdemeExcel, Log> repoViewExcel;
        private OperationResult opr = new OperationResult();
        private Data.ViewModelRepository.CariViewModelRepository repoCariViewModelRepository;
        private Data.ViewModelRepository.OdemeViewModelRepository repoOdemeViewModelRepository;

        public MobileCariVeOdemelerController(
            GenericRepository<Cari, Log> _repoCari,
            GenericRepository<Odeme, Log> _repoOdeme,
            GenericRepository<Firma, Log> _repoFirma,
            GenericRepository<Musteri, Log> _repoMusteri,
            GenericRepository<Tur, Log> _repoTur,
            GenericRepository<Otel, Log> _repoOtel,
            GenericRepository<Banka, Log> _repoBanka,
            GenericRepository<SatisSorumlusu, Log> _repoSatisSorumlusu,
            GenericRepository<View_CariOdemeExcel, Log> _repoViewExcel
        )
        {
            repoCari = _repoCari;
            repoOdeme = _repoOdeme;
            repoFirma = _repoFirma;
            repoMusteri = _repoMusteri;
            repoTur = _repoTur;
            repoOtel = _repoOtel;
            repoBanka = _repoBanka;
            repoSatisSorumlusu = _repoSatisSorumlusu;
            repoViewExcel = _repoViewExcel;
            repoCariViewModelRepository = new Data.ViewModelRepository.CariViewModelRepository();
            repoOdemeViewModelRepository = new Data.ViewModelRepository.OdemeViewModelRepository();
        }

        // GET: CariVeOdemeler
        public ActionResult Index(int frmId = 0)
        {
            if (!Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Index", "CariVeOdemeler", new { frmId });
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

    }
}