using System.ComponentModel.DataAnnotations;
using TravelInn.Data.Interface;

namespace TravelInn.Data
{
    public class UyrukMetaData : IUyruk
    {
        [Required]
        public string Uyrugu { get; set; }
    }
}