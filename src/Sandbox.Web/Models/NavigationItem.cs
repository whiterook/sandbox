using System.Web;

namespace Sandbox.Web.Models
{
    public class NavigationItem
    {
        public HtmlString Title { get; set; }
        public string Url { get; set; }
        public bool Active { get; set; }
    }
}