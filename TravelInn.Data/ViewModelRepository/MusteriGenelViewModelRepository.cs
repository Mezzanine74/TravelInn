using SharedKernel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelInn.Common;
using TravelInn.Data.ViewModels;

namespace TravelInn.Data.ViewModelRepository
{
    public class MusteriGenelViewModelRepository
    {
        private TravelInn.Data.TravelInnEntities db = new TravelInnEntities();
        private GenericRepository<Uyruk, Log> _repoUyruk;

        public MusteriGenelViewModelRepository()
        {
            _repoUyruk = new GenericRepository<Uyruk, Log>(db);
        }

        public List<MusteriViewModel> GetList()
        {
            return db.Musteris.Select(s => new MusteriViewModel
            {
                Id = s.Id,
                Musteri_AdiSoyadi = s.Musteri_AdiSoyadi,
                Uyruk_Idstr = s.Uyruk_Id.ToString(),
                Uniqueidentifier = s.Uniqueidentifier,
                Adres = s.Adres,
                Email = s.Email,
                Telefon = s.Telefon,
                CariAdedi = s.Caris.Count
            }).ToList();
        }

        public OperationResult Add(MusteriViewModel item)
        {

            var musteri = new Musteri()
            {
                Musteri_AdiSoyadi = item.Musteri_AdiSoyadi?.Length > 0 ? item.Musteri_AdiSoyadi : item.MusteriIdstr,
                Uyruk_Id = item.Uyruk_Id,
                Adres = item.Adres,
                Email = item.Email,
                Telefon = item.Telefon
            };

            var repoMusteri = new GenericRepository<Musteri, Log>(db);

            if (musteri.Validate().Success)
            {

                using (var repo = new UyrukViewModelRepository())
                {
                    var returnId = Convert.ToInt16(repo.Add(new UyrukViewModel() { Uyrugu = item.UyrukAdi, Uyruk_Idstr = item?.Uyruk_Idstr }).MessageList[0]);

                    if (returnId > 0)
                    {
                        musteri.Uyruk_Id = returnId;
                    }
                }

                if (repoMusteri.Add(musteri).Success)
                {
                    return new OperationResult() { Success = true, MessageList = { musteri.Id.ToString() } };
                };

            }

            return musteri.Validate();

        }

        public OperationResult Update(MusteriViewModel item, Musteri musteri)
        {
            musteri.Musteri_AdiSoyadi = Numeric.IsNumeric(item.MusteriIdstr) ? musteri.Musteri_AdiSoyadi : item.Musteri_AdiSoyadi;
            musteri.Uyruk_Id = item.Uyruk_Id;
            musteri.Adres = item.Adres;
            musteri.Email = item.Email;
            musteri.Telefon = item.Telefon;

            var repoMusteri = new GenericRepository<Musteri, Log>(db);

            if (musteri.Validate().Success)
            {

                using (var repo = new UyrukViewModelRepository())
                {
                    var returnId = Convert.ToInt16(repo.Add(new UyrukViewModel() { Uyrugu = item.UyrukAdi, Uyruk_Idstr = item?.Uyruk_Idstr }).MessageList[0]);

                    if (returnId > 0)
                    {
                        musteri.Uyruk_Id = returnId;
                    }
                }

                return repoMusteri.Update(musteri);

            }

            return musteri.Validate();

        }

        public OperationResult Remove(int id)
        {
            var repoMusteri = new GenericRepository<Musteri, Log>(db);

            return repoMusteri.Remove(id);
        }
    }
}