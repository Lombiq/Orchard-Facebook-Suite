using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Drivers
{
    public abstract class SocialPluginPartDriver<TSocialPluginPart, TSocialPluginPartRecord> : ContentPartDriver<TSocialPluginPart>
        where TSocialPluginPart : SocialPluginPart<TSocialPluginPartRecord>, new()
        where TSocialPluginPartRecord : SocialPluginPartRecord
    {
        protected override void Exporting(TSocialPluginPart part, ExportContentContext context)
        {
            var element = context.Element(part.PartDefinition.Name);

            element.SetAttributeValue("ColorScheme", part.ColorScheme);
            element.SetAttributeValue("Width", part.Width);
        }

        protected override void Importing(TSocialPluginPart part, ImportContentContext context)
        {
            var partName = part.PartDefinition.Name;

            context.ImportAttribute(partName, "ColorScheme", value => part.ColorScheme = value);
            context.ImportAttribute(partName, "Width", value => part.Width = int.Parse(value));
        }
    }
}