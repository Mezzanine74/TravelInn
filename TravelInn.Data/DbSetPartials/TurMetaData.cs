using System.ComponentModel.DataAnnotations;
using TravelInn.Data.Interface;

namespace TravelInn.Data
{
    public class TurMetaData : ITur
    {

        [Required]
        public string Tur_Adi { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
    }
}