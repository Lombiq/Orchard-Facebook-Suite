using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Drivers
{
    public class SocialPluginPartDriver<TSocialPluginPart, TSocialPluginPartRecord> : ContentPartDriver<TSocialPluginPart>
        where TSocialPluginPart : SocialPluginPart<TSocialPluginPartRecord>, new()
        where TSocialPluginPartRecord : SocialPluginPartRecord
    {
        protected override void Exporting(TSocialPluginPart part, ExportContentContext context)
        {
            context.Element(part.PartDefinition.Name).SetAttributeValue("ColorScheme", part.ColorScheme);
            context.Element(part.PartDefinition.Name).SetAttributeValue("Width", part.Width);
        }

        protected override void Importing(TSocialPluginPart part, ImportContentContext context)
        {
            part.ColorScheme = context.Attribute(part.PartDefinition.Name, "ColorScheme");
            part.Width = int.Parse(context.Attribute(part.PartDefinition.Name, "Width"));
        }
    }
}