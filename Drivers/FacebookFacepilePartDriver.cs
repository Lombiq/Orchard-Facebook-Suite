using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Environment.Extensions;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Drivers
{
    [OrchardFeature("Piedone.Facebook.Suite.Facepile")]
    public class FacebookFacepilePartDriver : SocialPluginPartDriver<FacebookFacepilePart, FacebookFacepilePartRecord>
    {
        protected override string Prefix
        {
            get { return "Facepile"; }
        }

        protected override DriverResult Display(FacebookFacepilePart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_FacebookFacepile",
                () => shapeHelper.Parts_FacebookFacepile());
        }

        // GET
        protected override DriverResult Editor(FacebookFacepilePart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_FacebookFacepile_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/FacebookFacepile",
                    Model: part,
                    Prefix: Prefix));
        }

        // POST
        protected override DriverResult Editor(FacebookFacepilePart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}