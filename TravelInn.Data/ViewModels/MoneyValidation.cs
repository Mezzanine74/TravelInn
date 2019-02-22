using TravelInn.Common;

namespace TravelInn.Data.ViewModels
{
    public class MoneyValidation
    {

        public OperationResult ValidateMoney(decimal? TL, decimal? Euro, decimal? Dollar)
        {
            bool euroCheck = string.IsNullOrEmpty(Euro.ToString()) || string.IsNullOrWhiteSpace(Euro.ToString()) || Euro == 0 || Euro < 0;
            bool dollarCheck = string.IsNullOrEmpty(Dollar.ToString()) || string.IsNullOrWhiteSpace(Dollar.ToString()) || Dollar == 0 || Dollar < 0;
            bool tLCheck = string.IsNullOrEmpty(TL.ToString()) || string.IsNullOrWhiteSpace(TL.ToString()) || TL == 0 || TL < 0;

            if (euroCheck == true && dollarCheck == true && tLCheck == true)
            {
                return new OperationResult() { Success = false, MessageList = { "En az bir Euro, Dollar, TL degeri girilmeli" } };
            }

            return new OperationResult() { Success = true };

        }

    }

}