using SharedKernel;
using System;
using System.ComponentModel.DataAnnotations;
using TravelInn.Common;
using TravelInn.Data.Interface;

namespace TravelInn.Data.ViewModels
{
    public enum Zamani
    {
        Gecmis,
        Bugun,
        Gelecek
    }

    public class CariViewModel : MoneyValidation, ICari, IValidate
    {
        public int Id { get; set; }
        [Required]
        public DateTime? Tarih { get; set; }
        [Required]
        public string Aciklama { get; set; }
        public decimal? TL { get; set; }
        public decimal? Euro { get; set; }
        public decimal? Dollar { get; set; }
        public string VoucherNo { get; set; }
        public string Pax { get; set; }
        public int FirmaId { get; set; }
        public string Uniqueidentifier { get; set; }

        public Zamani Zamani
        {
            get
            {
                var localTime = LocalTime.GetIstanbul().Date;

                if (this.Tarih.Value.Date == localTime)
                {
                    return Zamani.Bugun;
                }
                else if (this.Tarih > localTime)
                {
                    return Zamani.Gelecek;
                }
                else if (this.Tarih < localTime)
                {
                    return Zamani.Gecmis;
                }

                return Zamani.Gelecek;

            }
        }

        public int? MusteriId { get; set; }
        public string MusteriIdstr { get; set; }
        public int? Uyruk_Id { get; set; }
        public string Uyruk_Idstr { get; set; }
        public string MusteriAdi { get; set; }

        public string MusteriUyrugu { get; set; }
        public string MusteriTelefon { get; set; }
        public string MusteriEmail { get; set; }
        public string MusteriAdres { get; set; }

        public int? OtelId { get; set; }
        public string OtelIdstr { get; set; }
        public string OtelAdi { get; set; }
        public string OtelTelefon { get; set; }
        public string OtelEmail { get; set; }
        public string OtelAdres { get; set; }

        public int? SatisSorumlusu_Id { get; set; }
        public string SatisSorumlusu_Idstr { get; set; }
        public string SatisSorumlusuAdi { get; set; }
        public string SatisSorumlusuTelefon { get; set; }
        public string SatisSorumlusuEmail { get; set; }
        public string SatisSorumlusuAdres { get; set; }

        public int? TurId { get; set; }
        public string TurIdstr { get; set; }
        public string TurAdi { get; set; }
        public string TurTelefon { get; set; }
        public string TurEmail { get; set; }
        public string TurAdres { get; set; }
        public bool Confirmed { get; set; }

        public OperationResult Validate()
        {
            return base.ValidateMoney(this.TL, this.Euro, this.Dollar);

        }
    }

}