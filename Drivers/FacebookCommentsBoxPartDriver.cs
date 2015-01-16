using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Environment.Extensions;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Drivers
{
    [OrchardFeature("Piedone.Facebook.Suite.CommentsBox")]
    public class FacebookCommentsBoxPartDriver : SocialPluginPartDriver<FacebookCommentsBoxPart, FacebookCommentsBoxPartRecord>
    {
        protected override string Prefix
        {
            get { return "CommentsBox"; }
        }

        protected override DriverResult Display(FacebookCommentsBoxPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_FacebookCommentsBox",
                () => shapeHelper.Parts_FacebookCommentsBox());
        }

        // GET
        protected override DriverResult Editor(FacebookCommentsBoxPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_FacebookCommentsBox_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/FacebookCommentsBox",
                    Model: part,
                    Prefix: Prefix));
        }

        // POST
        protected override DriverResult Editor(FacebookCommentsBoxPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        protected override void Exporting(FacebookCommentsBoxPart part, ExportContentContext context)
        {
            base.Exporting(part, context);
            context.Element(part.PartDefinition.Name).SetAttributeValue("NumberOfPosts", part.NumberOfPosts);
        }

        protected override void Importing(FacebookCommentsBoxPart part, ImportContentContext context)
        {
            base.Importing(part, context);
            context.ImportAttribute(part.PartDefinition.Name, "NumberOfPosts", value => part.NumberOfPosts = int.Parse(value));
        }
    }
}