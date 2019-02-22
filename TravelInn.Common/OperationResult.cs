using System.Collections.Generic;

namespace TravelInn.Common
{
    public class OperationResult
    {
        public OperationResult()
        {
            MessageList = new List<string>();
            Success = true;
        }

        public bool Success { get; set; }

        public List<string> MessageList { get; private set; }

        public void AddMessage(string message)
        {
            MessageList.Add(message);
        }
    }

}
