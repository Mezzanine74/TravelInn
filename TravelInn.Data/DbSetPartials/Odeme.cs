using SharedKernel;
using System.ComponentModel.DataAnnotations;
using TravelInn.Common;
using TravelInn.Data.Interface;
using TravelInn.Data.ViewModels;

namespace TravelInn.Data
{
    [MetadataType(typeof(OdemeMetaData))]
    public partial class Odeme : MoneyValidation, IEntity, IValidate, IOdeme
    {
        public OperationResult Validate()
        {
            return base.ValidateMoney(this.TL, this.Euro, this.Dollar);
        }
    }
}
