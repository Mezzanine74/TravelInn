using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelInn.Common;

namespace TravelInn.Data.ViewModelRepository
{
    public class OdemeLogRepository
    {
        private TravelInnEntities db = new TravelInnEntities();
        private string _currentUser = HttpContext.Current?.User.Identity.Name;

        public IEnumerable<OdemeLog> GetList(DateTime date)
        {
            DateTime dateC = new DateTime(date.Year, date.Month, date.Day);
            DateTime datePlus = dateC.AddDays(1);

            return db.OdemeLogs.Where(c => c.When >= dateC && c.When < datePlus).ToList();
        }

        public OperationResult Add(Odeme odeme, ActionLog action)
        {
            var _return = new OperationResult();

            var odemeLog = new OdemeLog()
            {
                Aciklama = odeme.Aciklama,
                Action = action.ToString(),
                Dollar = odeme.Dollar,
                Euro = odeme.Euro,
                FirmaIsmi = odeme.Firma?.Ismi,
                TL = odeme.TL,
                Tarih = odeme.Tarih,
                Uniqueidentifier = odeme.Uniqueidentifier,
                When = LocalTime.GetIstanbul(),
                Who = _currentUser,
                Banka = odeme.Banka?.Banka_Adi
            };

            using (db)
            {
                db.OdemeLogs.Attach(odemeLog);
                db.OdemeLogs.Add(odemeLog);

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

