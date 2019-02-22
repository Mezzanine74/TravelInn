using System.ComponentModel.DataAnnotations;
using TravelInn.Data.Interface;

namespace TravelInn.Data
{
    public class MusteriMetaData : IMusteri
    {
        [Required]
        public string Musteri_AdiSoyadi { get; set; }
        public int? Uyruk_Id { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
    }
}