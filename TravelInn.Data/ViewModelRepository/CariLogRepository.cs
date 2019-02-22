using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelInn.Common;

namespace TravelInn.Data.ViewModelRepository
{
    public class CariLogRepository
    {
        private TravelInnEntities db = new TravelInnEntities();
        private string _currentUser = HttpContext.Current?.User.Identity.Name;

        public IEnumerable<CariLog> GetList(DateTime date)
        {
            DateTime dateC = new DateTime(date.Year, date.Month, date.Day);
            DateTime datePlus = dateC.AddDays(1);

            return db.CariLogs.Where(c => c.When >= dateC && c.When < datePlus).ToList();
        }


        public OperationResult Add(Cari cari, ActionLog action)
        {
            var _return = new OperationResult();

            var cariLog = new CariLog()
            {
                Aciklama = cari.Aciklama,
                Action = action.ToString(),
                Dollar = cari.Dollar,
                Euro = cari.Euro,
                FirmaIsmi = cari.Firma?.Ismi,
                MusteriAdi = cari.Musteri?.Musteri_AdiSoyadi,
                OtelAdi = cari.Otel?.Otel_Adi,
                Pax = cari.Pax?.ToString(),
                TL = cari.TL,
                Tarih = cari.Tarih,
                TurAdi = cari.Tur?.Tur_Adi,
                Uniqueidentifier = cari.Uniqueidentifier,
                VoucherNo = cari.VoucherNo,
                When = LocalTime.GetIstanbul(),
                Who = _currentUser,
                SatisSorumlusu = cari.SatisSorumlusu?.Ismi
            };

            using (db)
            {
                db.CariLogs.Attach(cariLog);
                db.CariLogs.Add(cariLog);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    _return.Success = false;
                    _return.MessageList.Add("log ekleme basarisiz");
                }

            }

            return _return;
        }
    }
}

public enum ActionLog
{
    Eklendi,
    Guncellendi,
    Silindi
}