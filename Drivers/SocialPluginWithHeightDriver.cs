using Orchard.ContentManagement.Handlers;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Drivers
{
    public abstract class SocialPluginWithHeightDriver<TSocialPluginPart, TSocialPluginPartRecord> : SocialPluginPartDriver<TSocialPluginPart, TSocialPluginPartRecord>
        where TSocialPluginPart : SocialPluginWithHeightPart<TSocialPluginPartRecord>, new()
        where TSocialPluginPartRecord : SocialPluginWithHeightRecord
    {
        protected override void Exporting(TSocialPluginPart part, ExportContentContext context)
        {
            base.Exporting(part, context);
            context.Element(part.PartDefinition.Name).SetAttributeValue("Height", part.Height);
        }

        protected override void Importing(TSocialPluginPart part, ImportContentContext context)
        {
            base.Importing(part, context);
            context.ImportAttribute(part.PartDefinition.Name, "Height", value => part.Height = int.Parse(value));
        }
    }
}