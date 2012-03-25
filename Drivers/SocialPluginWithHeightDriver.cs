using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Piedone.Facebook.Suite.Models;
using Orchard.ContentManagement.Handlers;

namespace Piedone.Facebook.Suite.Drivers
{
    public class SocialPluginWithHeightDriver<TSocialPluginPart, TSocialPluginPartRecord> : SocialPluginPartDriver<TSocialPluginPart, TSocialPluginPartRecord>
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
            part.Height = int.Parse(context.Attribute(part.PartDefinition.Name, "Height"));
        }
    }
}