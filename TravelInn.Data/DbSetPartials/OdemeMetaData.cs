using System;
using System.ComponentModel.DataAnnotations;
using TravelInn.Data.Interface;

namespace TravelInn.Data
{
    public class OdemeMetaData : IOdeme
    {
        public DateTime? Tarih { get; set; }
        [Required]
        public string Aciklama { get; set; }
        public decimal? TL { get; set; }
        public decimal? Euro { get; set; }
        public decimal? Dollar { get; set; }
        public int FirmaId { get; set; }
        public int? Banka_Id { get; set; }
    }
}