using SharedKernel;
using System.ComponentModel.DataAnnotations;
using TravelInn.Common;
using TravelInn.Data.Interface;

namespace TravelInn.Data
{
    [MetadataType(typeof(FirmaTemsilcisiMetaData))]
    public partial class FirmaTemsilcisi : IFirmaTemsilcisi, IEntity, IValidate
    {
        public OperationResult Validate()
        {
            return new OperationResult() { Success = true };
        }
    }
}
