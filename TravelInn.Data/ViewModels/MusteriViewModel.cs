using SharedKernel;
using TravelInn.Common;
using TravelInn.Data.Interface;

namespace TravelInn.Data.ViewModels
{
    public class MusteriViewModel : IMusteri, IValidate, ICariIliskisi
    {
        public int Id { get; set; }

        public string MusteriIdstr { get; set; }
        public string Musteri_AdiSoyadi { get; set; }
        public string Uniqueidentifier { get; set; }

        public int? Uyruk_Id { get; set; }
        public string Uyruk_Idstr { get; set; }
        public string UyrukAdi { get; set; }

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
