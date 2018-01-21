using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sandbox.Web.Models;
using Sitecore.Collections;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;

namespace Sandbox.Web.Controllers
{
    public class OverviewController : Controller
    {
        // GET: Overview
        public ActionResult Index()
        {
            var model =
                new OverviewList
                {
                    ReadMore = Sitecore.Globalization.Translate.Text("Read More")
                };

            model.AddRange(RenderingContext.Current.Rendering.Item.GetChildren(ChildListOptions.SkipSorting)
                .OrderBy(x => x.Created)
                .Select(x => new OverviewItem
                {
                    Title = new HtmlString(FieldRenderer.Render(x, "ContentHeading")),
                    Url = LinkManager.GetItemUrl(x),
                    Image = new HtmlString(FieldRenderer.Render(x, "banner", "mw=500&Mh=333"))
                }));

            return View(model);
        }
    }
}