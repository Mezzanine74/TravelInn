using SharedKernel;
using System.ComponentModel.DataAnnotations;
using TravelInn.Common;
using TravelInn.Data.Interface;

namespace TravelInn.Data
{
    [MetadataType(typeof(BankaMetaData))]
    public partial class Banka : IBanka, IEntity, IValidate
    {
        public OperationResult Validate()
        {
            return new OperationResult() { Success = true };
        }
    }
}