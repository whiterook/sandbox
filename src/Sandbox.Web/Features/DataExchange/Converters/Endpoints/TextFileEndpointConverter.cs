using System;
using Sandbox.Data.Features.DataExchange.Plugins;
using Sandbox.Web.Features.DataExchange.Models.ItemModels.Endpoints;
using Sitecore.DataExchange.Converters.Endpoints;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;

namespace Sandbox.Web.Features.DataExchange.Converters.Endpoints
{
    public class TextFileEndpointConverter : BaseEndpointConverter
    {
        private static readonly Guid TemplateId = Guid.Parse("{A28280BE-8331-4BAA-B5BE-41E7456FB67E}");
        public TextFileEndpointConverter(IItemModelRepository repository) : base(repository)
        {
            SupportedTemplateIds.Add(TemplateId);
        }
        protected override void AddPlugins(ItemModel source, Endpoint endpoint)
        {
            var settings = new TextFileSettings
            {
                Path = GetStringValue(source, TextFileEndpointItemModel.Path),
                ColumnSeparator = GetStringValue(source, TextFileEndpointItemModel.ColumnSeparator),
                ColumnHeadersInFirstLine = GetBoolValue(source, TextFileEndpointItemModel.ColumnHeadersInFirstLine)
            };
            endpoint.Plugins.Add(settings);
        }
    }
}
