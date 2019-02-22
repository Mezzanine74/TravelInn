using SharedKernel;
using System.ComponentModel.DataAnnotations;
using TravelInn.Common;
using TravelInn.Data.Interface;

namespace TravelInn.Data
{
    [MetadataType(typeof(UyrukMetaData))]
    public partial class Uyruk : IUyruk, IEntity, IValidate
    {
        public OperationResult Validate()
        {
            return new OperationResult() { Success = true };
        }
    }
}