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

            var element = context.Element(part.PartDefinition.Name);

            element.SetAttributeValue("PageUrl", part.PageUrl);
            element.SetAttributeValue("ShowFaces", part.ShowFaces);
            element.SetAttributeValue("BorderColor", part.BorderColor);
            element.SetAttributeValue("ShowStream", part.ShowStream);
            element.SetAttributeValue("ShowHeader", part.ShowHeader);
        }

        protected override void Importing(FacebookLikeBoxPart part, ImportContentContext context)
        {
            base.Importing(part, context);

            var partName = part.PartDefinition.Name;

            context.ImportAttribute(partName, "PageUrl", value => part.PageUrl = value);
            context.ImportAttribute(partName, "ShowFaces", value => part.ShowFaces = bool.Parse(value));
            context.ImportAttribute(partName, "BorderColor", value => part.BorderColor = value);
            context.ImportAttribute(partName, "ShowStream", value => part.ShowStream = bool.Parse(value));
            context.ImportAttribute(partName, "ShowHeader", value => part.ShowHeader = bool.Parse(value));
        }
    }
}