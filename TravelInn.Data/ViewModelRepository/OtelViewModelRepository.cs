using SharedKernel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelInn.Common;
using TravelInn.Data.ViewModels;

namespace TravelInn.Data.ViewModelRepository
{
    public class OtelViewModelRepository : IDisposable
    {
        private TravelInn.Data.TravelInnEntities db = new TravelInnEntities();
        private GenericRepository<Otel, Log> _repoOtel;

        public OtelViewModelRepository()
        {
            _repoOtel = new GenericRepository<Otel, Log>(db);
        }

        public List<OtelViewModel> GetList()
        {
            return db.Otels.Select(s => new OtelViewModel()
            {
                Id = s.Id,
                Otel_Adi = s.Otel_Adi,
                Uniqueidentifier = s.Uniqueidentifier,
                Adres = s.Adres,
                Email = s.Email,
                Telefon = s.Telefon,
                CariAdedi = s.Caris.Count
            }).ToList();
        }

        public OperationResult Add(OtelViewModel otelViewModel)
        {
            if (otelViewModel == null)
            {
                return new OperationResult() { Success = false, MessageList = { 0.ToString() } };
            }

            if (otelViewModel.OtelIdstr == null)
            {
                var otel = new Otel()
                {
                    Otel_Adi = otelViewModel.Otel_Adi,
                    Adres = otelViewModel.Adres,
                    Email = otelViewModel.Email,
                    Telefon = otelViewModel.Telefon
                };

                if (_repoOtel.FindBy(c => c.Otel_Adi == otel.Otel_Adi).ToList().Count() == 0)
                {
                    var result = _repoOtel.Add(otel);
                    if (result.Success)
                    {
                        return new OperationResult() { Success = true, MessageList = { otel.Id.ToString() } };
                    }
                }

            }

            if (!Numeric.IsNumeric(otelViewModel.OtelIdstr) && otelViewModel.OtelIdstr?.Length > 0)
            {
                var otel = new Otel()
                {
                    Otel_Adi = otelViewModel.OtelIdstr,
                    Adres = otelViewModel.Adres,
                    Email = otelViewModel.Email,
                    Telefon = otelViewModel.Telefon
                };

                if (_repoOtel.FindBy(c => c.Otel_Adi == otel.Otel_Adi).ToList().Count() == 0)
                {
                    var result = _repoOtel.Add(otel);
                    if (result.Success)
                    {
                        return new OperationResult() { Success = true, MessageList = { otel.Id.ToString() } };
                    }
                }

            }

            else if (Numeric.IsNumeric(otelViewModel.OtelIdstr))
            {
                var otel = _repoOtel.FindByKey(Convert.ToInt16(otelViewModel.OtelIdstr));

                if (otel != null)
                {
                    // update Otel
                    this.Update(otelViewModel, otel);

                    return new OperationResult() { Success = false, MessageList = { otelViewModel.OtelIdstr } };
                }

            }

            return new OperationResult() { Success = false, MessageList = { 0.ToString() } };

        }

        public OperationResult Update(OtelViewModel item, Otel otel)
        {
            otel.Otel_Adi = Numeric.IsNumeric(item.OtelIdstr) ? otel.Otel_Adi : item.Otel_Adi;
            otel.Adres = item.Adres;
            otel.Email = item.Email;
            otel.Telefon = item.Telefon;

            var repoOtel = new GenericRepository<Otel, Log>(db);

            if (otel.Validate().Success)
            {
                return repoOtel.Update(otel);
            }

            return otel.Validate();

        }

        public OperationResult Remove(int id)
        {
            var repo = new GenericRepository<Otel, Log>(db);

            return repo.Remove(id);
        }

        public void Dispose()
        {

        }
    }
}