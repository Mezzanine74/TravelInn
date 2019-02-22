using System.Collections.Generic;

namespace TravelInn.Common
{
    public class LoggingService
    {
        public static void WriteToDatabase(IEnumerable<Loggable> changedItems)
        {
            foreach (var item in changedItems)
            {
                // Database e ekle

            }
        }
    }
}
