using SharedKernel;
using System.ComponentModel.DataAnnotations;
using TravelInn.Common;
using TravelInn.Data.Interface;

namespace TravelInn.Data
{
    [MetadataType(typeof(OtelMetaData))]
    public partial class Otel : IOtel, IEntity, IValidate
    {
        public OperationResult Validate()
        {
            return new OperationResult() { Success = true };
        }
    }
}