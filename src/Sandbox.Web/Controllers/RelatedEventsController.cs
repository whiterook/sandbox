using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sandbox.Web.Models;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;

namespace Sandbox.Web.Controllers
{
    public class RelatedEventsController : Controller
    {
        // GET: RelatedEvents
        public ActionResult Index()
        {
            var renderingItem = RenderingContext.Current.Rendering.Item;
            if (renderingItem == null)
            {
                return new EmptyResult();
            }

            MultilistField multiListField = renderingItem.Fields["Related Events"];
            if (multiListField == null)
            {
                return new EmptyResult();
            }

            var relatedEvents =
                multiListField.GetItems()
                    .Select(x => new NavigationItem
                    {
                        Title = new HtmlString(x.DisplayName),
                        Url = LinkManager.GetItemUrl(x)
                    });

            
            return View(relatedEvents);
        }
    }
}