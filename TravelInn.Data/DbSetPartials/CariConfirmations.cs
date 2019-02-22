using SharedKernel;
using System.ComponentModel.DataAnnotations;
using TravelInn.Common;
using TravelInn.Data.Interface;

namespace TravelInn.Data
{
    [MetadataType(typeof(CariConfirmationMetaData))]
    public partial class CariConfirmation : IEntity, IValidate, ICariConfirmation
    {
        public OperationResult Validate()
        {
            return new OperationResult();
        }
    }
}
