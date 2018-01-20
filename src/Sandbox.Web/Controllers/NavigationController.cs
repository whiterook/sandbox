using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sandbox.Web.Constants;
using Sandbox.Web.Models;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;

namespace Sandbox.Web.Controllers
{
    public class NavigationController : Controller
    {
        // GET: NavigationMenu
        public ActionResult Index()
        {
            var currentContextItem = RenderingContext.CurrentOrNull.ContextItem;

            var dataSourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var dataSource = Sitecore.Context.Database.GetItem(dataSourceId);

            var rootTemplateId = dataSource != null ? dataSource.TemplateID : SitecoreTemplate.EventSectionTemplateId;

            var root = currentContextItem
                              .Axes
                              .GetAncestors()
                              .FirstOrDefault(x => x.TemplateID == rootTemplateId) ?? currentContextItem;

            var model =
                CreateNavigationMenu(root, currentContextItem);

            return View(model);
        }

        private NavigationMenu CreateNavigationMenu(Item root, Item current)
        {
            var menu =
                new NavigationMenu
                {
                    Title = new HtmlString(FieldRenderer.Render(root, "ContentHeading", "disable-web-editing=true")),
                    Url = LinkManager.GetItemUrl(root),
                    Children = root.Axes.IsAncestorOf(current)
                        ? root.GetChildren().Select(x => CreateNavigationMenu(x, current))
                        : null
                };

            return menu;
        }
    }
}