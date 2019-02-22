using SharedKernel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelInn.Common;
using TravelInn.Data.ViewModels;

namespace TravelInn.Data.ViewModelRepository
{
    public class OdemeViewModelRepository
    {
        private TravelInnEntities db = new TravelInnEntities();
        private GenericRepository<Musteri, Log> _repoMusteri;
        private GenericRepository<Tur, Log> _repoTur;
        private GenericRepository<Otel, Log> _repoOtel;

        public OdemeViewModelRepository()
        {
            _repoMusteri = new GenericRepository<Musteri, Log>(db);
            _repoTur = new GenericRepository<Tur, Log>(db);
            _repoOtel = new GenericRepository<Otel, Log>(db);
        }

        public List<OdemeViewModel> GetList(int Id)
        {
            return db.Odemes.Where(c => c.FirmaId == Id).Select(s => new OdemeViewModel
            {
                Id = s.Id,
                Aciklama = s.Aciklama,
                Dollar = s.Dollar,
                Euro = s.Euro,
                FirmaId = s.FirmaId,
                TL = s.TL,
                Tarih = s.Tarih,
                Uniqueidentifier = s.Uniqueidentifier,
                Banka_Idstr = s.Banka_Id.ToString()
            }).ToList();
        }

        public OperationResult Add(OdemeViewModel item)
        {

            var odeme = new Odeme()
            {
                Aciklama = item.Aciklama,
                Dollar = item.Dollar,
                Euro = item.Euro,
                FirmaId = item.FirmaId,
                TL = item.TL,
                Tarih = item.Tarih,
                Banka_Id = item.Banka_Id
            };

            var repoOdeme = new GenericRepository<Odeme, Log>(db);

            if (odeme.Validate().Success)
            {

                using (var repo = new BankaViewModelRepository())
                {
                    var returnId = Convert.ToInt16(repo.Add(item?.Banka_Idstr).MessageList[0]);

                    if (returnId > 0)
                    {
                        odeme.Banka_Id = returnId;
                    }
                }

                if (repoOdeme.Add(odeme).Success)
                {
                    var odemeToLog = repoOdeme.FindByKey(odeme.Id);
                    var odemeLogRepository = new OdemeLogRepository();
                    if (odemeLogRepository.Add(odemeToLog, ActionLog.Eklendi).Success)
                    {
                        return new OperationResult();
                    }
                    else
                    {
                        repoOdeme.Remove(odeme.Id);
                    };
                }

            }

            return odeme.Validate();

        }

        public OperationResult Update(OdemeViewModel item)
        {
            var odeme = new Odeme()
            {
                Id = item.Id,
                Aciklama = item.Aciklama,
                Dollar = item.Dollar,
                Euro = item.Euro,
                FirmaId = item.FirmaId,
                TL = item.TL,
                Tarih = item.Tarih,
                Banka_Id = item.Banka_Id
            };

            var repoOdeme = new GenericRepository<Odeme, Log>(db);

            if (odeme.Validate().Success)
            {

                using (var repo = new BankaViewModelRepository())
                {
                    var returnId = Convert.ToInt16(repo.Add(item?.Banka_Idstr).MessageList[0]);

                    if (returnId > 0)
                    {
                        odeme.Banka_Id = returnId;
                    }
                }

                if (repoOdeme.Update(odeme).Success)
                {
                    var odemeToLog = repoOdeme.FindByKey(odeme.Id);
                    var odemeLogRepository = new OdemeLogRepository();
                    if (odemeLogRepository.Add(odemeToLog, ActionLog.Guncellendi).Success)
                    {
                        return new OperationResult();
                    }
                    else
                    {
                        // Burada error log verdirmem gerek. Yani admine gidecek.
                        // Error sayfasi yaptiginda dikkate al
                    };
                }

            }

            return odeme.Validate();

        }

        public OperationResult Remove(int id)
        {
            var _return = new OperationResult();

            var repoOdeme = new GenericRepository<Odeme, Log>(db);

            var odemeToLog = repoOdeme.FindByKey(id);

            if (repoOdeme.Remove(id).Success)
            {
                var odemeLogRepository = new OdemeLogRepository();
                if (odemeLogRepository.Add(odemeToLog, ActionLog.Silindi).Success)
                {

                }
                else
                {
                    repoOdeme.Add(odemeToLog);
                    _return.Success = false;
                    _return.MessageList.Add("Silme Log Basarisiz");
                };
            }

            return _return;
        }

    }
}