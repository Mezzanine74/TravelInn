using System;
using System.ComponentModel.DataAnnotations;
using TravelInn.Data.Interface;

namespace TravelInn.Data
{
    public class CariMetaData : ICari
    {
        public DateTime? Tarih { get; set; }
        [Required]
        public string Aciklama { get; set; }
        public decimal? TL { get; set; }
        public decimal? Euro { get; set; }
        public decimal? Dollar { get; set; }
        public string VoucherNo { get; set; }
        public string Pax { get; set; }
        public int FirmaId { get; set; }
        public int? MusteriId { get; set; }
        public int? TurId { get; set; }
        public int? OtelId { get; set; }
        public int? SatisSorumlusu_Id { get; set; }
        public bool Confirmed { get; set; }
    }
}