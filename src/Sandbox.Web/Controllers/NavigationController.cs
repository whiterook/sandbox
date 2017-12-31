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
            var section =
                currentContextItem.Axes.GetAncestors().FirstOrDefault(x => x.TemplateID == SitecoreTemplate.EventSectionTemplateId);

            var model =
                CreateNavigationMenu(section, currentContextItem);

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