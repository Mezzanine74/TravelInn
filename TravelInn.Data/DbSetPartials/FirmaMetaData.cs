using System.ComponentModel.DataAnnotations;
using TravelInn.Data.Interface;

namespace TravelInn.Data
{
    public class FirmaMetaData : IFirma
    {
        [Required]
        public string Ismi { get; set; }

        public string Adresi { get; set; }
    }
}
