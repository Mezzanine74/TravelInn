using SharedKernel;
using TravelInn.Common;
using TravelInn.Data.Interface;

namespace TravelInn.Data.ViewModels
{
    public class UyrukViewModel : IUyruk, IValidate, ICariIliskisi
    {
        public int Id { get; set; }
        public string Uyrugu { get; set; }
        public string Uyruk_Idstr { get; set; }
        public string Uniqueidentifier { get; set; }
        public int CariAdedi { get; set; }

        public OperationResult Validate()
        {
            return new OperationResult();
        }
    }
}
