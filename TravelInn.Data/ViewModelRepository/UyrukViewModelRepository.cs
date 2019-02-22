using SharedKernel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelInn.Common;
using TravelInn.Data.ViewModels;

namespace TravelInn.Data.ViewModelRepository
{
    public class UyrukViewModelRepository : IDisposable
    {
        private TravelInn.Data.TravelInnEntities db = new TravelInnEntities();
        private GenericRepository<Uyruk, Log> _repoUyruk;

        public UyrukViewModelRepository()
        {
            _repoUyruk = new GenericRepository<Uyruk, Log>(db);
        }

        public List<UyrukViewModel> GetList()
        {

            return db.View_UyrukCariAdedi
                .Select(s => new UyrukViewModel()
                {
                    Id = s.Id,
                    Uyrugu = s.Uyrugu,
                    Uniqueidentifier = s.Uniqueidentifier,
                    CariAdedi = s.CariAdedi
                }).ToList();

        }

        public OperationResult Add(UyrukViewModel model)
        {
            if (model == null)
            {
                return new OperationResult() { Success = false, MessageList = { 0.ToString() } };
            }

            if (model.Uyruk_Idstr == null)
            {
                var uyruk = new Uyruk()
                {
                    Uyrugu = model.Uyrugu,
                };

                if (_repoUyruk.FindBy(c => c.Uyrugu == uyruk.Uyrugu).ToList().Count() == 0)
                {
                    var result = _repoUyruk.Add(uyruk);
                    if (result.Success)
                    {
                        return new OperationResult() { Success = true, MessageList = { uyruk.Id.ToString() } };
                    }
                }

            }

            if (!Numeric.IsNumeric(model.Uyruk_Idstr) && model.Uyruk_Idstr?.Length > 0)
            {
                var uyruk = new Uyruk()
                {
                    Uyrugu = model.Uyruk_Idstr,
                };

                if (_repoUyruk.FindBy(c => c.Uyrugu == uyruk.Uyrugu).ToList().Count() == 0)
                {
                    var result = _repoUyruk.Add(uyruk);
                    if (result.Success)
                    {
                        return new OperationResult() { Success = true, MessageList = { uyruk.Id.ToString() } };
                    }
                }

            }

            else if (Numeric.IsNumeric(model.Uyruk_Idstr))
            {
                var uyruk = _repoUyruk.FindByKey(Convert.ToInt16(model.Uyruk_Idstr));

                if (uyruk != null)
                {
                    // update
                    this.Update(model, uyruk);

                    return new OperationResult() { Success = false, MessageList = { model.Uyruk_Idstr } };
                }

            }

            return new OperationResult() { Success = false, MessageList = { 0.ToString() } };

        }

        public OperationResult Update(UyrukViewModel item, Uyruk uyruk)
        {
            uyruk.Uyrugu = Numeric.IsNumeric(item.Uyruk_Idstr) ? uyruk.Uyrugu : item.Uyrugu;

            var repoUyruk = new GenericRepository<Uyruk, Log>(db);

            if (uyruk.Validate().Success)
            {
                return repoUyruk.Update(uyruk);
            }

            return uyruk.Validate();

        }

        public OperationResult Remove(int id)
        {
            var repo = new GenericRepository<Uyruk, Log>(db);

            return repo.Remove(id);
        }

        public void Dispose()
        {

        }
    }
}