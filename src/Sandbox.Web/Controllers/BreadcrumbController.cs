using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sandbox.Web.Models;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;

namespace Sandbox.Web.Controllers
{
    public class BreadcrumbController : Controller
    {
        // GET: Breadcrumb
        public ActionResult Index()
        {
            return View(GetModel());
        }


        private IEnumerable<NavigationItem> GetModel()
        {
            var currentContextItem = RenderingContext.CurrentOrNull.ContextItem;

            var dataSourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var dataSource = Sitecore.Context.Database.GetItem(dataSourceId);

            var homeItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);

            var items =
                currentContextItem.Axes.GetAncestors()
                    .Where(x => x.Axes.IsDescendantOf(dataSource ?? homeItem))
                    .Concat(new[] { currentContextItem })
                    .ToList();

            var result =
                items.Select(x => new NavigationItem
                {
                    Url = LinkManager.GetItemUrl(x),
                    Active = x.ID == currentContextItem.ID,
                    Title = new HtmlString(FieldRenderer.Render(x, "ContentHeading", "disable-web-editing=true"))
                });

            return result;
        }
    }
}