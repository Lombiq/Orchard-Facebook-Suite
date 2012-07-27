using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Environment.Extensions;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Drivers
{
    [OrchardFeature("Piedone.Facebook.Suite.LikeButton")]
    public class FacebookLikeButtonPartDriver : SocialPluginPartDriver<FacebookLikeButtonPart, FacebookLikeButtonPartRecord>
    {
        protected override string Prefix
        {
            get { return "LikeButton"; }
        }

        protected override DriverResult Display(FacebookLikeButtonPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_FacebookLikeButton",
                () => shapeHelper.Parts_FacebookLikeButton());
        }

        // GET
        protected override DriverResult Editor(FacebookLikeButtonPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_FacebookLikeButton_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/FacebookLikeButton",
                    Model: part,
                    Prefix: Prefix));
        }

        // POST
        protected override DriverResult Editor(FacebookLikeButtonPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        protected override void Exporting(FacebookLikeButtonPart part, ExportContentContext context)
        {
            base.Exporting(part, context);

            context.Element(part.PartDefinition.Name).SetAttributeValue("EnableSendButton", part.EnableSendButton);
            context.Element(part.PartDefinition.Name).SetAttributeValue("LayoutStyle", part.LayoutStyle);
            context.Element(part.PartDefinition.Name).SetAttributeValue("ShowFaces", part.ShowFaces);
            context.Element(part.PartDefinition.Name).SetAttributeValue("VerbToDisplay", part.VerbToDisplay);
            context.Element(part.PartDefinition.Name).SetAttributeValue("Font", part.Font);
        }

        protected override void Importing(FacebookLikeButtonPart part, ImportContentContext context)
        {
            base.Importing(part, context);

            var partName = part.PartDefinition.Name;
            
            context.ImportAttribute(partName, "EnableSendButton", value => part.EnableSendButton = bool.Parse(value));
            context.ImportAttribute(partName, "LayoutStyle", value => part.LayoutStyle = value);
            context.ImportAttribute(partName, "ShowFaces", value => part.ShowFaces = bool.Parse(value));
            context.ImportAttribute(partName, "VerbToDisplay", value => part.VerbToDisplay = value);
            context.ImportAttribute(partName, "Font", value => part.Font = value);
        }
    }
}