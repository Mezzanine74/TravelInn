using SharedKernel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelInn.Common;
using TravelInn.Data.ViewModels;

namespace TravelInn.Data.ViewModelRepository
{
    public class TurViewModelRepository : IDisposable
    {
        private TravelInn.Data.TravelInnEntities db = new TravelInnEntities();
        private GenericRepository<Tur, Log> _repoTur;

        public TurViewModelRepository()
        {
            _repoTur = new GenericRepository<Tur, Log>(db);
        }

        public List<TurViewModel> GetList()
        {
            return db.Turs.Select(s => new TurViewModel()
            {
                Id = s.Id,
                Tur_Adi = s.Tur_Adi,
                Uniqueidentifier = s.Uniqueidentifier,
                Adres = s.Adres,
                Email = s.Email,
                Telefon = s.Telefon,
                CariAdedi = s.Caris.Count
            }).ToList();
        }

        public OperationResult Add(TurViewModel turViewModel)
        {
            if (turViewModel == null)
            {
                return new OperationResult() { Success = false, MessageList = { 0.ToString() } };
            }

            if (turViewModel.TurIdstr == null)
            {
                var tur = new Tur()
                {
                    Tur_Adi = turViewModel.Tur_Adi,
                    Adres = turViewModel.Adres,
                    Email = turViewModel.Email,
                    Telefon = turViewModel.Telefon
                };

                if (_repoTur.FindBy(c => c.Tur_Adi == tur.Tur_Adi).ToList().Count() == 0)
                {
                    var result = _repoTur.Add(tur);
                    if (result.Success)
                    {
                        return new OperationResult() { Success = true, MessageList = { tur.Id.ToString() } };
                    }
                }

            }

            if (!Numeric.IsNumeric(turViewModel.TurIdstr) && turViewModel.TurIdstr?.Length > 0)
            {
                var tur = new Tur()
                {
                    Tur_Adi = turViewModel.TurIdstr,
                    Adres = turViewModel.Adres,
                    Email = turViewModel.Email,
                    Telefon = turViewModel.Telefon
                };

                if (_repoTur.FindBy(c => c.Tur_Adi == tur.Tur_Adi).ToList().Count() == 0)
                {
                    var result = _repoTur.Add(tur);
                    if (result.Success)
                    {
                        return new OperationResult() { Success = true, MessageList = { tur.Id.ToString() } };
                    }
                }

            }

            else if (Numeric.IsNumeric(turViewModel.TurIdstr))
            {
                var tur = _repoTur.FindByKey(Convert.ToInt16(turViewModel.TurIdstr));

                if (tur != null)
                {
                    // update Otel
                    this.Update(turViewModel, tur);

                    return new OperationResult() { Success = false, MessageList = { turViewModel.TurIdstr } };
                }

            }

            return new OperationResult() { Success = false, MessageList = { 0.ToString() } };

        }

        public OperationResult Update(TurViewModel item, Tur tur)
        {
            tur.Tur_Adi = Numeric.IsNumeric(item.TurIdstr) ? tur.Tur_Adi : item.Tur_Adi;
            tur.Adres = item.Adres;
            tur.Email = item.Email;
            tur.Telefon = item.Telefon;

            var repoTur = new GenericRepository<Tur, Log>(db);

            if (tur.Validate().Success)
            {
                return repoTur.Update(tur);
            }

            return tur.Validate();

        }

        public OperationResult Remove(int id)
        {
            var repo = new GenericRepository<Tur, Log>(db);

            return repo.Remove(id);
        }

        public void Dispose()
        {

        }
    }
}