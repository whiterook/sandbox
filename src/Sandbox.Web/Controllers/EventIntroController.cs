using System.Web;
using System.Web.Mvc;
using Sandbox.Web.Models;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;

namespace Sandbox.Web.Controllers
{
    public class EventIntroController : Controller
    {
        // GET: Events/EventIntro
        public ActionResult Index()
        {
            return View(GetModel());
        }

        private EventIntro GetModel()
        {
            var currentItem =
                RenderingContext.Current.ContextItem;

            return new EventIntro
            {
                ContentBody = new HtmlString(FieldRenderer.Render(currentItem, "ContentBody")),
                DifficultyLevel = new HtmlString(FieldRenderer.Render(currentItem, "Difficulty Level")),
                Duration = new HtmlString(FieldRenderer.Render(currentItem, "Duration")),
                EventImage = new HtmlString(FieldRenderer.Render(currentItem, "Event Image", "mw=400")),
                ContentHeading = new HtmlString(FieldRenderer.Render(currentItem, "ContentHeading")),
                Highlights = new HtmlString(FieldRenderer.Render(currentItem, "Highlights")),
                ContentIntro = new HtmlString(FieldRenderer.Render(currentItem, "ContentIntro")),
                StartDate = new HtmlString(FieldRenderer.Render(currentItem, "Start Date"))
            };
        }
    }
}