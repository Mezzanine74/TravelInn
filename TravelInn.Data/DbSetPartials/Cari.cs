using SharedKernel;
using System.ComponentModel.DataAnnotations;
using TravelInn.Common;
using TravelInn.Data.Interface;
using TravelInn.Data.ViewModels;

namespace TravelInn.Data
{
    [MetadataType(typeof(CariMetaData))]
    public partial class Cari : MoneyValidation, IEntity, IValidate, ICari
    {
        public OperationResult Validate()
        {
            return base.ValidateMoney(this.TL, this.Euro, this.Dollar);
        }
    }
}
