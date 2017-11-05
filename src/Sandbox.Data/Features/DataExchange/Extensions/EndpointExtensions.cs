using Sandbox.Data.Features.DataExchange.Plugins;
using Sitecore.DataExchange.Models;

namespace Sandbox.Data.Features.DataExchange.Extensions
{
    public static class EndpointExtensions
    {
        public static TextFileSettings GetTextFileSettings(this Endpoint endpoint)
        {
            return endpoint.GetPlugin<TextFileSettings>();
        }
        public static bool HasTextFileSettings(this Endpoint endpoint)
        {
            return (GetTextFileSettings(endpoint) != null);
        }
    }
}
