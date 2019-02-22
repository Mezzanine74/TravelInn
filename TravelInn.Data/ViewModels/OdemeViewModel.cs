using SharedKernel;
using System;
using TravelInn.Common;
using TravelInn.Data.Interface;

namespace TravelInn.Data.ViewModels
{
    public class OdemeViewModel : MoneyValidation, IOdeme, IValidate
    {
        public int Id { get; set; }
        public DateTime? Tarih { get; set; }
        public string Aciklama { get; set; }
        public decimal? TL { get; set; }
        public decimal? Euro { get; set; }
        public decimal? Dollar { get; set; }
        public int FirmaId { get; set; }
        public string Uniqueidentifier { get; set; }
        public int? Banka_Id { get; set; }
        public string Banka_Idstr { get; set; }
        public string BankaAdi { get; set; }

        public OperationResult Validate()
        {
            return base.ValidateMoney(this.TL, this.Euro, this.Dollar);

        }
    }
}