using System.ComponentModel.DataAnnotations;
using TravelInn.Data.Interface;

namespace TravelInn.Data
{
    public class FirmaTemsilcisiMetaData : IFirmaTemsilcisi
    {
        [Required]
        public string AdiSoyadi { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public int FirmaId { get; set; }
    }
}
