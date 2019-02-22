using System.ComponentModel.DataAnnotations;
using TravelInn.Data.Interface;

namespace TravelInn.Data
{
    public class SatisSorumlusuMetaData : ISatisSorumlusu
    {
        [Required]
        public string Ismi { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
    }
}