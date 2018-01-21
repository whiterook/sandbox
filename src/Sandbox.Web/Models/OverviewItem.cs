using System.Web;

namespace Sandbox.Web.Models
{
    public class OverviewItem
    {
        public HtmlString Title { get; set; }
        public HtmlString Image { get; set; }
        public string Url { get; set; }
    }
}