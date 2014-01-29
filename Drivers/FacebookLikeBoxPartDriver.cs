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
    }
}