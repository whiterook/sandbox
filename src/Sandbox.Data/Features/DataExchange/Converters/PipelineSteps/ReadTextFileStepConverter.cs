using System;
using Sandbox.Data.Features.DataExchange.Models.ItemModels.PipelineSteps;
using Sitecore.DataExchange.Converters.PipelineSteps;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Plugins;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;

namespace Sandbox.Data.Features.DataExchange.Converters.PipelineSteps
{
    public class ReadTextFileStepConverter : BasePipelineStepConverter
    {
        private static readonly Guid TemplateId = Guid.Parse("{BB3E3BAB-7497-4B84-A13B-46DEC07002B3}");
        public ReadTextFileStepConverter(IItemModelRepository repository) : base(repository)
        {
            SupportedTemplateIds.Add(TemplateId);
        }
        protected override void AddPlugins(ItemModel source, PipelineStep pipelineStep)
        {
            AddEndpointSettings(source, pipelineStep);
        }
        private void AddEndpointSettings(ItemModel source, PipelineStep pipelineStep)
        {
            var settings = new EndpointSettings();
            var endpointFrom = ConvertReferenceToModel<Endpoint>(source, ReadTextFileStepItemModel.EndpointFrom);
            if (endpointFrom != null)
            {
                settings.EndpointFrom = endpointFrom;
            }
            pipelineStep.Plugins.Add(settings);
        }
    }
}
