using SharedKernel.Data;
using System.Linq;
using TravelInn.Common;

namespace TravelInn.Data.ViewModelRepository
{
    public class CariConfirmationRepository
    {
        private TravelInn.Data.TravelInnEntities db = new TravelInnEntities();
        private GenericRepository<CariConfirmation, Log> _repo;
        private GenericRepository<Cari, Log> _repoCari;

        public CariConfirmationRepository()
        {
            _repo = new GenericRepository<CariConfirmation, Log>(db);
            _repoCari = new GenericRepository<Cari, Log>(db);
        }

        public OperationResult Upload(string path, int id)
        {
            var _return = new OperationResult();

            var confirmationCount = _repo.FindBy(c => c.FilePath.Contains(path)).ToList().Count;

            // path dublike olmuyorsa
            if (confirmationCount == 0)
            {
                // confirmation ekleme basarili ise
                if (_repo.Add(new CariConfirmation()
                {
                    FilePath = path,
                    CariId = id
                }).Success)
                {
                    // cari yi confirmed yap
                    var cari = _repoCari.FindByKey(id);
                    if (cari.Confirmed == false)
                    {
                        cari.Confirmed = true;
                        _repoCari.Update(cari);
                    };

                    _return.Success = true;
                }
                else
                {
                    _return.Success = false;
                    _return.MessageList.Add("Database eklemesi hata verdi");
                };
            }
            else
            {
                _return.Success = false;
                _return.MessageList.Add("Bu path daha once yuklenmis");
            }

            return _return;
        }

        public OperationResult Remove(string path, int id)
        {
            var _return = new OperationResult();

            var confirmation = _repo.FindBy(c => c.FilePath.Contains(path)).ToList()[0];

            // confirmation silme basarili ise
            if (_repo.Remove(confirmation.Id).Success)
            {
                // caride confirmation kalmamis ise sil
                var confirmationsCount = _repo.FindBy(c => c.CariId == id).ToList().Count;
                if (confirmationsCount == 0)
                {
                    // cari yi unconfirmed yap
                    var cari = _repoCari.FindByKey(id);
                    cari.Confirmed = false;
                    _repoCari.Update(cari);
                };

                // cari yi confirmed yap
                _return.Success = true;
            }
            else
            {
                _return.Success = false;
            };

            return _return;

        }
    }
}