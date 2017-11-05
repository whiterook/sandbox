using System;
using Sandbox.Data.Features.DataExchange.Models.ItemModels.DataAccess;
using Sitecore.DataExchange.Converters.DataAccess.ValueAccessors;
using Sitecore.DataExchange.DataAccess;
using Sitecore.DataExchange.DataAccess.Readers;
using Sitecore.DataExchange.DataAccess.Writers;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;

namespace Sandbox.Data.Features.DataExchange.Converters.DataAccess
{
    public class MergeColumnsConverter : ValueAccessorConverter
    {
        private static readonly Guid TemplateId = Guid.Parse("{7AF02837-829F-40ED-881B-0EFFDD866D8E}");
        public MergeColumnsConverter(IItemModelRepository repository) : base(repository)
        {
            SupportedTemplateIds.Add(TemplateId);
        }
        public override IValueAccessor Convert(ItemModel source)
        {
            var accessor = base.Convert(source);
            if (accessor == null)
            {
                return null;
            }
            var position = GetIntValue(source, ArrayValueAccessorItemModel.Position);
            if (position <= 0)
            {
                return null;
            }
            //
            //array position is 1-based in the Sitecore item but is 0-based in the reader/writer
            position--;
            //
            //unless a reader or writer is explicitly set use the property value
            if (accessor.ValueReader == null)
            {
                accessor.ValueReader = new ArrayValueReader(position);
            }
            if (accessor.ValueWriter == null)
            {
                accessor.ValueWriter = new ArrayValueWriter(position);
            }
            return accessor;
        }

    }
}