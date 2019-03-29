using SharedKernel;
using System.ComponentModel.DataAnnotations;
using TravelInn.Common;
using TravelInn.Data.Interface;

namespace TravelInn.Data.ViewModels
{
    public class TurViewModel : ITur, IValidate, ICariIliskisi
    {
        public int Id { get; set; }
        public string TurIdstr { get; set; }
        public string Uniqueidentifier { get; set; }
        [Required]
        public string Tur_Adi { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
        public int CariAdedi { get; set; }

        public OperationResult Validate()
        {
            return new OperationResult();
        }
    }
}
