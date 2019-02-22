using System.Reflection;

namespace TravelInn.Common
{
    public class Loggable
    {
        public string Log<TEntity>(TEntity entity) where TEntity : class
        {
            var _log = "";
            PropertyInfo[] properties = typeof(TEntity).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (!property.PropertyType.Name.StartsWith("ICollection"))
                {
                    _log += property.Name + " > " + property.GetValue(entity)?.ToString() + " | ";
                }
            }

            return _log;
        }

    }
}
