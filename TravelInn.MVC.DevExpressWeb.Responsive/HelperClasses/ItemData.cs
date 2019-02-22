using System.Web;
using System.Web.UI;

namespace TravelInn.MVC.DevExpressWeb.Responsive.HelperClasses
{
    public class ItemData : IHierarchyData
    {
        public string Text { get; protected set; }
        public string NavigateUrl { get; protected set; }

        public ItemData(string text, string navigateUrl)
        {
            Text = text;

            var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;

            //if (routeValues.ContainsKey("controller"))
            //{
            //    if (Convert.ToString(routeValues["controller"]).ToLower() != "cariveodemeler")
            //    {
            //        NavigateUrl = "CariVeOdemeler/" + NavigateUrl;
            //    }
            //    else
            //    {
            //        NavigateUrl = navigateUrl;
            //    }
            //}
            //else
            //{
            //    NavigateUrl = navigateUrl;
            //}
            NavigateUrl = navigateUrl;
        }

        // IHierarchyData
        bool IHierarchyData.HasChildren
        {
            get { return HasChildren(); }
        }
        object IHierarchyData.Item
        {
            get { return this; }
        }
        string IHierarchyData.Path
        {
            get
            {
                //var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;

                //if (routeValues.ContainsKey("controller"))
                //{
                //    if (Convert.ToString(routeValues["controller"]).ToLower() != "cariveodemeler")
                //    {
                //        return "CariVeOdemeler/" + NavigateUrl;
                //    }
                //}

                return NavigateUrl;
            }
        }
        string IHierarchyData.Type
        {
            get { return GetType().ToString(); }
        }
        IHierarchicalEnumerable IHierarchyData.GetChildren()
        {
            return CreateChildren();
        }
        IHierarchyData IHierarchyData.GetParent()
        {
            return null;
        }

        protected virtual bool HasChildren()
        {
            return false;
        }
        protected virtual IHierarchicalEnumerable CreateChildren()
        {
            return null;
        }
    }

}