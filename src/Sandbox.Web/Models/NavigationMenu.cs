using System.Collections.Generic;

namespace Sandbox.Web.Models
{
    public class NavigationMenu: NavigationItem
    {
        public IEnumerable<NavigationMenu> Children { get; set; }
    }
}