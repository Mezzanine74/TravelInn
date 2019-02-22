using System.Collections;
using System.Web.UI;

namespace TravelInn.MVC.DevExpressWeb.Responsive.HelperClasses
{
    public abstract class ItemsData : IHierarchicalEnumerable, IEnumerable
    {
        public ItemsData()
        {
        }

        public abstract IEnumerable Data { get; }

        public IEnumerator GetEnumerator()
        {
            return Data.GetEnumerator();
        }
        public IHierarchyData GetHierarchyData(object enumeratedItem)
        {
            return (IHierarchyData)enumeratedItem;
        }
    }

}