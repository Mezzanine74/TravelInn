using System.ComponentModel.DataAnnotations;
using TravelInn.Data.Interface;

namespace TravelInn.Data
{
    public class CariConfirmationMetaData : ICariConfirmation
    {
        [Required]
        public int CariId { get; set; }
        [Required]
        public string FilePath { get; set; }
    }
}