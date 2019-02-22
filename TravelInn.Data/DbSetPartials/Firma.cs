using SharedKernel;
using System.ComponentModel.DataAnnotations;
using TravelInn.Common;
using TravelInn.Data.Interface;

namespace TravelInn.Data
{
    [MetadataType(typeof(FirmaMetaData))]
    public partial class Firma : IEntity, IValidate, IFirma
    {
        public OperationResult Validate()
        {
            return new OperationResult(){Success = true};
        }
    }
}
