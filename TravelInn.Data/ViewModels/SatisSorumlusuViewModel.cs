using SharedKernel;
using TravelInn.Common;
using TravelInn.Data.Interface;

namespace TravelInn.Data.ViewModels
{
    public class SatisSorumlusuViewModel : ISatisSorumlusu, IValidate, ICariIliskisi
    {
        public int Id { get; set; }
        public string SatisSorumlusu_Idstr { get; set; }
        public string Ismi { get; set; }
        public string Uniqueidentifier { get; set; }
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
