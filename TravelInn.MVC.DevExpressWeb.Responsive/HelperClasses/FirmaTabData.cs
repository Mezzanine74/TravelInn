using System.Web.UI;
using TravelInn.Data;

namespace TravelInn.MVC.DevExpressWeb.Responsive.HelperClasses
{
    public class FirmaTabData : ItemData
    {
        public Firma Firma { get; protected set; }

        public FirmaTabData(Firma firma)
            : base(firma.Ismi, "?frmId=" + firma.Id)
        {
            Firma = firma;
        }

        protected override bool HasChildren()
        {
            return true;
            //return false;
        }
        protected override IHierarchicalEnumerable CreateChildren()
        {
            //return new ProductsData(Category.CategoryID);
            // Eger Child gerekirse su ornekten devam et
            // https://demos.devexpress.com/MVCxNavigationAndLayoutDemos/Menu/DataBinding

            return null;
        }
    }

}