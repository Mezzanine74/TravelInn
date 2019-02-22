using System.Collections;
using System.Linq;

namespace TravelInn.MVC.DevExpressWeb.Responsive.HelperClasses
{
    public class FirmasTabData : ItemsData
    {
        TravelInn.Data.TravelInnEntities db = new TravelInn.Data.TravelInnEntities();

        public override IEnumerable Data
        {
            get { return db.Firmas.OrderBy(c => c.Ismi).ToList().Select(c => new FirmaTabData(c)); }
        }
    }

}