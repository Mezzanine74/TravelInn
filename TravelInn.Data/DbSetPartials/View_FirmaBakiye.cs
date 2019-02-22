using SharedKernel;
using System;
using TravelInn.Common;

namespace TravelInn.Data
{
    public partial class View_FirmaBakiye : IEntity, IValidate
    {
        public int Id { get; set; }
        public string Uniqueidentifier { get; set; }
        public string WhoInserted { get; set; }
        public string WhoUpdated { get; set; }
        public string WhoDeleted { get; set; }
        public DateTime? WhenInserted { get; set; }
        public DateTime? WhenUpdated { get; set; }
        public DateTime? WhenDeleted { get; set; }

        public OperationResult Validate()
        {
            return new OperationResult() { Success = true };

        }
    }
}
