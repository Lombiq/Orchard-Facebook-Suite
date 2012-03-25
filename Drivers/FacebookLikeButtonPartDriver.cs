using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Environment.Extensions;
using Piedone.Facebook.Suite.Models;
using Orchard.ContentManagement.Handlers;

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
            part.EnableSendButton = bool.Parse(context.Attribute(part.PartDefinition.Name, "EnableSendButton"));
            part.LayoutStyle = context.Attribute(part.PartDefinition.Name, "LayoutStyle");
            part.ShowFaces = bool.Parse(context.Attribute(part.PartDefinition.Name, "ShowFaces"));
            part.VerbToDisplay = context.Attribute(part.PartDefinition.Name, "VerbToDisplay");
            part.Font = context.Attribute(part.PartDefinition.Name, "Font");
        }
    }
}