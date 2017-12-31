using System.Web;
using System.Web.Mvc;
using Sandbox.Web.Models;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;

namespace Sandbox.Web.Controllers
{
    public class FeaturedEventController : Controller
    {


        public ActionResult Index()
        {
            return View(Model);
        }


        private FeaturedEvent Model
        {
            get
            {
                var currentRendering = RenderingContext.Current.Rendering;
                var renderingItem = currentRendering.Item;
                var renderingParameter = currentRendering.Parameters["CssClass"];

                string css = null;

                if (!string.IsNullOrEmpty(renderingParameter))
                {
                    var refItem = Sitecore.Context.Database.GetItem(renderingParameter);

                    css = refItem != null ? refItem["Class"] : renderingParameter;
                }

                return new FeaturedEvent
                {
                    Heading = new HtmlString(FieldRenderer.Render(renderingItem, "ContentHeading")),
                    Intro = new HtmlString(FieldRenderer.Render(renderingItem, "ContentIntro")),
                    EventImage = new HtmlString(FieldRenderer.Render(renderingItem, "Event Image", "mw = 400")),
                    CssClass = css,
                    Url = LinkManager.GetItemUrl(renderingItem)
                };
            }
        }
    }
}