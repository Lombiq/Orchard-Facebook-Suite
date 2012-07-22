using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Environment.Extensions;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Drivers
{
    [OrchardFeature("Piedone.Facebook.Suite.LikeBox")]
    public class FacebookLikeBoxPartDriver : SocialPluginWithHeightDriver<FacebookLikeBoxPart, FacebookLikeBoxPartRecord>
    {
        protected override string Prefix
        {
            get { return "LikeBox"; }
        }

        protected override DriverResult Display(FacebookLikeBoxPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_FacebookLikeBox",
                () => shapeHelper.Parts_FacebookLikeBox());
        }

        // GET
        protected override DriverResult Editor(FacebookLikeBoxPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_FacebookLikeBox_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/FacebookLikeBox",
                    Model: part,
                    Prefix: Prefix));
        }

        // POST
        protected override DriverResult Editor(FacebookLikeBoxPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        protected override void Exporting(FacebookLikeBoxPart part, ExportContentContext context)
        {
            base.Exporting(part, context);
            context.Element(part.PartDefinition.Name).SetAttributeValue("PageUrl", part.PageUrl);
            context.Element(part.PartDefinition.Name).SetAttributeValue("ShowFaces", part.ShowFaces);
            context.Element(part.PartDefinition.Name).SetAttributeValue("BorderColor", part.BorderColor);
            context.Element(part.PartDefinition.Name).SetAttributeValue("ShowStream", part.ShowStream);
            context.Element(part.PartDefinition.Name).SetAttributeValue("ShowHeader", part.ShowHeader);
        }

        protected override void Importing(FacebookLikeBoxPart part, ImportContentContext context)
        {
            base.Importing(part, context);
            part.PageUrl = context.Attribute(part.PartDefinition.Name, "PageUrl");
            part.ShowFaces = bool.Parse(context.Attribute(part.PartDefinition.Name, "ShowFaces"));
            part.BorderColor = context.Attribute(part.PartDefinition.Name, "BorderColor");
            part.ShowStream = bool.Parse(context.Attribute(part.PartDefinition.Name, "ShowStream"));
            part.ShowHeader = bool.Parse(context.Attribute(part.PartDefinition.Name, "ShowHeader"));
        }
    }
}