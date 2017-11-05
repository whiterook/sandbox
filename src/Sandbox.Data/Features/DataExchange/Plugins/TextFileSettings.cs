using Sitecore.DataExchange;

namespace Sandbox.Data.Features.DataExchange.Plugins
{
    public class TextFileSettings : IPlugin
    {
        public string Path { get; set; }
        public string ColumnSeparator { get; set; }
        public bool ColumnHeadersInFirstLine { get; set; }
    }
}
