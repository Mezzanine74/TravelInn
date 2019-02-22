using SharedKernel.Data;
using System;
using System.Linq;
using TravelInn.Common;

namespace TravelInn.Data.ViewModelRepository
{
    public class BankaViewModelRepository : IDisposable
    {
        private TravelInn.Data.TravelInnEntities db = new TravelInnEntities();
        private GenericRepository<Banka, Log> _repoBanka;

        public BankaViewModelRepository()
        {
            _repoBanka = new GenericRepository<Banka, Log>(db);
        }

        public OperationResult Add(string input)
        {
            if (input == null)
            {
                return new OperationResult() { Success = false, MessageList = { 0.ToString() } };
            }

            if (!Numeric.IsNumeric(input) && input.Length > 0)
            {
                var banka = new Banka()
                {
                    Banka_Adi = input,
                };

                if (_repoBanka.FindBy(c => c.Banka_Adi == banka.Banka_Adi).ToList().Count() == 0)
                {
                    var result = _repoBanka.Add(banka);
                    if (result.Success)
                    {
                        return new OperationResult() { Success = true, MessageList = { banka.Id.ToString() } };
                    }
                }

            }

            else if (Numeric.IsNumeric(input))
            {
                if (_repoBanka.FindByKey(Convert.ToInt16(input)) != null)
                {
                    return new OperationResult() { Success = false, MessageList = { input } };
                }

            }

            return new OperationResult() { Success = false, MessageList = { 0.ToString() } };

        }

        public void Dispose()
        {

        }
    }
}