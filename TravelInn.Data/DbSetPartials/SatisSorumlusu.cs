using SharedKernel;
using System.ComponentModel.DataAnnotations;
using TravelInn.Common;
using TravelInn.Data.Interface;

namespace TravelInn.Data
{
    [MetadataType(typeof(SatisSorumlusuMetaData))]
    public partial class SatisSorumlusu : ISatisSorumlusu, IEntity, IValidate
    {
        public OperationResult Validate()
        {
            return new OperationResult() { Success = true };
        }
    }
}