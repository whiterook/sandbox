using System.Collections.Generic;

namespace Sandbox.Web.Models
{
    public class OverviewList: List<OverviewItem>
    {
        public string ReadMore { get; set; }
    }
}