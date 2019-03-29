using SharedKernel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelInn.Common;
using TravelInn.Data.ViewModels;

namespace TravelInn.Data.ViewModelRepository
{
    public class CariViewModelRepository
    {
        private TravelInn.Data.TravelInnEntities db = new TravelInnEntities();
        private GenericRepository<Cari, Log> _repoCari;
        private GenericRepository<Musteri, Log> _repoMusteri;
        private GenericRepository<Tur, Log> _repoTur;
        private GenericRepository<Otel, Log> _repoOtel;
        private GenericRepository<SatisSorumlusu, Log> _repoSatisSorumlusu;

        public CariViewModelRepository()
        {
            _repoCari = new GenericRepository<Cari, Log>(db);
            _repoMusteri = new GenericRepository<Musteri, Log>(db);
            _repoTur = new GenericRepository<Tur, Log>(db);
            _repoOtel = new GenericRepository<Otel, Log>(db);
            _repoSatisSorumlusu = new GenericRepository<SatisSorumlusu, Log>(db);
        }

        public List<CariViewModel> GetList(int Id)
        {
            return db.Caris.Where(c => c.FirmaId == Id).Select(s => new CariViewModel
            {
                Id = s.Id,

                TurIdstr = s.TurId.ToString(),
                TurAdi = s.Tur.Tur_Adi,
                TurAdres = s.Tur.Adres,
                TurTelefon = s.Tur.Telefon,
                TurEmail = s.Tur.Email,

                OtelIdstr = s.OtelId.ToString(),
                OtelAdi = s.Otel.Otel_Adi,
                OtelAdres = s.Otel.Adres,
                OtelTelefon = s.Otel.Telefon,
                OtelEmail = s.Otel.Email,

                MusteriIdstr = s.MusteriId.ToString(),
                Uyruk_Idstr = s.Musteri.Uyruk_Id.ToString(),
                MusteriAdi = s.Musteri.Musteri_AdiSoyadi,
                MusteriAdres = s.Musteri.Adres,
                MusteriTelefon = s.Musteri.Telefon,
                MusteriEmail = s.Musteri.Email,
                MusteriUyrugu = s.Musteri.Uyruk.Uyrugu,

                SatisSorumlusu_Idstr = s.SatisSorumlusu_Id.ToString(),
                SatisSorumlusuAdres = s.SatisSorumlusu.Adres,
                SatisSorumlusuTelefon = s.SatisSorumlusu.Telefon,
                SatisSorumlusuEmail = s.SatisSorumlusu.Email,

                Confirmed = s.Confirmed,

                Aciklama = s.Aciklama,
                Dollar = s.Dollar,
                Euro = s.Euro,
                FirmaId = s.FirmaId,
                Pax = s.Pax,
                TL = s.TL,
                Tarih = s.Tarih,
                VoucherNo = s.VoucherNo,
                Uniqueidentifier = s.Uniqueidentifier,

            }).ToList();
        }

        public OperationResult Add(CariViewModel item)
        {

            var cari = new Cari()
            {
                Aciklama = item.Aciklama,
                Dollar = item.Dollar,
                Euro = item.Euro,
                FirmaId = item.FirmaId,
                MusteriId = item.MusteriId,
                OtelId = item.OtelId,
                Pax = item.Pax,
                TL = item.TL,
                Tarih = item.Tarih,
                TurId = item.TurId,
                VoucherNo = item.VoucherNo,
                SatisSorumlusu_Id = item.SatisSorumlusu_Id
            };

            var repoCari = new GenericRepository<Cari, Log>(db);

            if (cari.Validate().Success)
            {

                using (var repo = new MusteriViewModelRepository())
                {
                    var returnId = Convert.ToInt16(repo.Add(new MusteriViewModel()
                    {
                        MusteriIdstr = item.MusteriIdstr,
                        Uyruk_Idstr = item.Uyruk_Idstr,
                        Uyruk_Id = item.Uyruk_Id,
                        Adres = item.MusteriAdres,
                        Email = item.MusteriEmail,
                        Telefon = item.MusteriTelefon
                    }).MessageList[0]);

                    if (returnId > 0)
                    {
                        cari.MusteriId = returnId;
                    }
                }

                using (var repo = new OtelViewModelRepository())
                {
                    var returnId = Convert.ToInt16(repo.Add(new OtelViewModel()
                    {
                        OtelIdstr = item.OtelIdstr,
                        Adres = item.OtelAdres,
                        Email = item.OtelEmail,
                        Telefon = item.OtelTelefon
                    }).MessageList[0]);

                    if (returnId > 0)
                    {
                        cari.OtelId = returnId;
                    }
                }

                using (var repo = new TurViewModelRepository())
                {
                    var returnId = Convert.ToInt16(repo.Add(new TurViewModel()
                    {
                        TurIdstr = item.TurIdstr,
                        Adres = item.TurAdres,
                        Email = item.TurEmail,
                        Telefon = item.TurTelefon
                    }).MessageList[0]);

                    if (returnId > 0)
                    {
                        cari.TurId = returnId;
                    }
                }

                using (var repo = new SatisSorumlusuViewModelRepository())
                {
                    var returnId = Convert.ToInt16(repo.Add(new SatisSorumlusuViewModel()
                    {
                        SatisSorumlusu_Idstr = item.SatisSorumlusu_Idstr,
                        Adres = item.SatisSorumlusuAdres,
                        Email = item.SatisSorumlusuEmail,
                        Telefon = item.SatisSorumlusuTelefon
                    }).MessageList[0]);

                    if (returnId > 0)
                    {
                        cari.SatisSorumlusu_Id = returnId;
                    }
                }

                if (repoCari.Add(cari).Success)
                {
                    var cariToLog = repoCari.FindByKey(cari.Id);
                    var cariLogRepository = new CariLogRepository();
                    if (cariLogRepository.Add(cariToLog, ActionLog.Eklendi).Success)
                    {
                        return new OperationResult();
                    }
                    else
                    {
                        repoCari.Remove(cari.Id);
                    };
                }
            }

            return cari.Validate();

        }

        public OperationResult Update(CariViewModel item)
        {
            var confirmed = _repoCari.FindByKey(item.Id);

            var cari = new Cari()
            {
                Id = item.Id,
                Aciklama = item.Aciklama,
                Dollar = item.Dollar,
                Euro = item.Euro,
                FirmaId = item.FirmaId,
                MusteriId = item.MusteriId,
                OtelId = item.OtelId,
                Pax = item.Pax,
                TL = item.TL,
                Tarih = item.Tarih,
                TurId = item.TurId,
                VoucherNo = item.VoucherNo,
                SatisSorumlusu_Id = item.SatisSorumlusu_Id,
                Confirmed = confirmed.Confirmed
            };

            var repoCari = new GenericRepository<Cari, Log>(db);

            if (cari.Validate().Success)
            {

                using (var repo = new MusteriViewModelRepository())
                {
                    var returnId = Convert.ToInt16(repo.Add(new MusteriViewModel()
                    {
                        MusteriIdstr = item.MusteriIdstr,
                        Uyruk_Idstr = item.Uyruk_Idstr,
                        Uyruk_Id = item.Uyruk_Id,
                        Adres = item.MusteriAdres,
                        Email = item.MusteriEmail,
                        Telefon = item.MusteriTelefon
                    }).MessageList[0]);

                    if (returnId > 0)
                    {
                        cari.MusteriId = returnId;
                    }
                }

                using (var repo = new OtelViewModelRepository())
                {
                    var returnId = Convert.ToInt16(repo.Add(new OtelViewModel()
                    {
                        OtelIdstr = item.OtelIdstr,
                        Adres = item.OtelAdres,
                        Email = item.OtelEmail,
                        Telefon = item.OtelTelefon
                    }).MessageList[0]);

                    if (returnId > 0)
                    {
                        cari.OtelId = returnId;
                    }
                }

                using (var repo = new TurViewModelRepository())
                {
                    var returnId = Convert.ToInt16(repo.Add(new TurViewModel()
                    {
                        TurIdstr = item.TurIdstr,
                        Adres = item.TurAdres,
                        Email = item.TurEmail,
                        Telefon = item.TurTelefon
                    }).MessageList[0]);

                    if (returnId > 0)
                    {
                        cari.TurId = returnId;
                    }
                }

                using (var repo = new SatisSorumlusuViewModelRepository())
                {
                    var returnId = Convert.ToInt16(repo.Add(new SatisSorumlusuViewModel()
                    {
                        SatisSorumlusu_Idstr = item.SatisSorumlusu_Idstr,
                        Adres = item.SatisSorumlusuAdres,
                        Email = item.SatisSorumlusuEmail,
                        Telefon = item.SatisSorumlusuTelefon
                    }).MessageList[0]);

                    if (returnId > 0)
                    {
                        cari.SatisSorumlusu_Id = returnId;
                    }
                }

                if (repoCari.Update(cari).Success)
                {
                    var cariToLog = repoCari.FindByKey(cari.Id);
                    var cariLogRepository = new CariLogRepository();
                    if (cariLogRepository.Add(cariToLog, ActionLog.Guncellendi).Success)
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

            return cari.Validate();

        }

        public OperationResult Remove(int id)
        {
            var _return = new OperationResult();

            var repoCari = new GenericRepository<Cari, Log>(db);

            var cariToLog = repoCari.FindByKey(id);

            if (repoCari.Remove(id).Success)
            {
                var cariLogRepository = new CariLogRepository();
                if (cariLogRepository.Add(cariToLog, ActionLog.Silindi).Success)
                {

                }
                else
                {
                    repoCari.Add(cariToLog);
                    _return.Success = false;
                    _return.MessageList.Add("Silme Log Basarisiz");
                };
            }

            return _return;
        }

        public YaklasanTurBilgisi YaklasanTur()
        {
            try
            {
                var bugun = Convert.ToDateTime(Convert.ToDateTime(LocalTime.GetIstanbul()).ToString("dd/MM/yyyy"));
                var yarin = bugun.AddDays(1);

                var yarinTurSayisi = db.Caris.Where(c => c.Tarih == yarin).Count();
                var bugunTurSayisi = db.Caris.Where(c => c.Tarih == bugun).Count();
                string bilgiler = "";
                bool yaklasiyor = false;

                if (yarinTurSayisi > 0)
                {
                    bilgiler = $" Yarin {yarinTurSayisi.ToString()} tur var,";
                    yaklasiyor = true;
                }

                if (bugunTurSayisi > 0)
                {
                    bilgiler += $" Bugun {bugunTurSayisi.ToString()} tur var,";
                    yaklasiyor = true;
                }

                return new YaklasanTurBilgisi() { Yaklasiyor = yaklasiyor, Bilgileri = bilgiler.Remove(bilgiler.Length - 1, 1) };

            }
            catch (Exception e)
            {

            }

            return new YaklasanTurBilgisi() { Yaklasiyor = false, Bilgileri = "" };
        }

    }

    public class YaklasanTurBilgisi
    {
        public bool Yaklasiyor { get; set; }
        public string Bilgileri { get; set; }
    }
}