using SharedKernel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelInn.Common;
using TravelInn.Data.ViewModels;

namespace TravelInn.Data.ViewModelRepository
{
    public class SatisSorumlusuViewModelRepository : IDisposable
    {
        private TravelInn.Data.TravelInnEntities db = new TravelInnEntities();
        private GenericRepository<SatisSorumlusu, Log> _repoSatisSorumlusu;

        public SatisSorumlusuViewModelRepository()
        {
            _repoSatisSorumlusu = new GenericRepository<SatisSorumlusu, Log>(db);
        }

        public List<SatisSorumlusuViewModel> GetList()
        {
            return db.SatisSorumlusus.Select(s => new SatisSorumlusuViewModel()
            {
                Id = s.Id,
                Ismi = s.Ismi,
                Uniqueidentifier = s.Uniqueidentifier,
                Adres = s.Adres,
                Email = s.Email,
                Telefon = s.Telefon,
                CariAdedi = s.Caris.Count
            }).ToList();
        }

        public OperationResult Add(SatisSorumlusuViewModel satisSorumlusuViewModel)
        {
            if (satisSorumlusuViewModel == null)
            {
                return new OperationResult() { Success = false, MessageList = { 0.ToString() } };
            }

            if (satisSorumlusuViewModel.SatisSorumlusu_Idstr == null)
            {
                var satisSorumlusu = new SatisSorumlusu()
                {
                    Ismi = satisSorumlusuViewModel.Ismi,
                    Adres = satisSorumlusuViewModel.Adres,
                    Email = satisSorumlusuViewModel.Email,
                    Telefon = satisSorumlusuViewModel.Telefon
                };

                if (_repoSatisSorumlusu.FindBy(c => c.Ismi == satisSorumlusu.Ismi).ToList().Count() == 0)
                {
                    var result = _repoSatisSorumlusu.Add(satisSorumlusu);
                    if (result.Success)
                    {
                        return new OperationResult() { Success = true, MessageList = { satisSorumlusu.Id.ToString() } };
                    }
                }

            }

            if (!Numeric.IsNumeric(satisSorumlusuViewModel.SatisSorumlusu_Idstr) && satisSorumlusuViewModel.SatisSorumlusu_Idstr?.Length > 0)
            {
                var satisSorumlusu = new SatisSorumlusu()
                {
                    Ismi = satisSorumlusuViewModel.SatisSorumlusu_Idstr,
                    Adres = satisSorumlusuViewModel.Adres,
                    Email = satisSorumlusuViewModel.Email,
                    Telefon = satisSorumlusuViewModel.Telefon
                };

                if (_repoSatisSorumlusu.FindBy(c => c.Ismi == satisSorumlusu.Ismi).ToList().Count() == 0)
                {
                    var result = _repoSatisSorumlusu.Add(satisSorumlusu);
                    if (result.Success)
                    {
                        return new OperationResult() { Success = true, MessageList = { satisSorumlusu.Id.ToString() } };
                    }
                }

            }

            else if (Numeric.IsNumeric(satisSorumlusuViewModel.SatisSorumlusu_Idstr))
            {
                var satisSorumlusu = _repoSatisSorumlusu.FindByKey(Convert.ToInt16(satisSorumlusuViewModel.SatisSorumlusu_Idstr));

                if (satisSorumlusu != null)
                {
                    // update SatisSorumlusu
                    this.Update(satisSorumlusuViewModel, satisSorumlusu);

                    return new OperationResult() { Success = false, MessageList = { satisSorumlusuViewModel.SatisSorumlusu_Idstr } };
                }

            }

            return new OperationResult() { Success = false, MessageList = { 0.ToString() } };

        }

        public OperationResult Update(SatisSorumlusuViewModel item, SatisSorumlusu satisSorumlusu)
        {
            satisSorumlusu.Ismi = Numeric.IsNumeric(item.SatisSorumlusu_Idstr) ? satisSorumlusu.Ismi : item.Ismi;
            satisSorumlusu.Adres = item.Adres;
            satisSorumlusu.Email = item.Email;
            satisSorumlusu.Telefon = item.Telefon;

            var repoSatisSorumlusu = new GenericRepository<SatisSorumlusu, Log>(db);

            if (satisSorumlusu.Validate().Success)
            {
                return repoSatisSorumlusu.Update(satisSorumlusu);
            }

            return satisSorumlusu.Validate();

        }

        public OperationResult Remove(int id)
        {
            var repo = new GenericRepository<SatisSorumlusu, Log>(db);

            return repo.Remove(id);
        }

        public void Dispose()
        {

        }
    }
}