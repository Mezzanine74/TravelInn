using SharedKernel.Data;
using System;
using System.Linq;
using TravelInn.Common;
using TravelInn.Data.ViewModels;

namespace TravelInn.Data.ViewModelRepository
{
    public class MusteriViewModelRepository : IDisposable
    {
        private TravelInn.Data.TravelInnEntities db = new TravelInnEntities();
        private GenericRepository<Musteri, Log> _repoMusteri;
        private MusteriGenelViewModelRepository musteriGenelViewModelRepository;

        public MusteriViewModelRepository()
        {
            _repoMusteri = new GenericRepository<Musteri, Log>(db);
            musteriGenelViewModelRepository = new MusteriGenelViewModelRepository();
        }

        public OperationResult Add(MusteriViewModel musteriViewModel)
        {
            if (musteriViewModel == null)
            {
                return new OperationResult() { Success = false, MessageList = { 0.ToString() } };
            }

            if (!Numeric.IsNumeric(musteriViewModel.MusteriIdstr) && musteriViewModel.MusteriIdstr?.Length > 0)
            {

                if (_repoMusteri.FindBy(c => c.Musteri_AdiSoyadi == musteriViewModel.MusteriIdstr).ToList().Count() == 0)
                {
                    return musteriGenelViewModelRepository.Add(musteriViewModel);
                }

            }

            else if (Numeric.IsNumeric(musteriViewModel.MusteriIdstr))
            {
                var musteri = _repoMusteri.FindByKey(Convert.ToInt16(musteriViewModel.MusteriIdstr));

                if (musteri != null)
                {
                    // Musteriyi guncelle
                    musteriGenelViewModelRepository.Update(musteriViewModel, musteri);

                    return new OperationResult() { Success = false, MessageList = { musteriViewModel.MusteriIdstr } };
                }

            }

            return new OperationResult() { Success = false, MessageList = { 0.ToString() } };

        }


        public void Dispose()
        {

        }
    }
}