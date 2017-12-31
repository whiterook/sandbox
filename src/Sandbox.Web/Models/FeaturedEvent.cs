using System.Web;

namespace Sandbox.Web.Models
{
    public class FeaturedEvent
    {
        public HtmlString Heading { get; set; }
        public HtmlString Intro { get; set; }
        public HtmlString EventImage { get; set; }
        public string CssClass { get; set; }
        public string Url { get; set; }
    }
}