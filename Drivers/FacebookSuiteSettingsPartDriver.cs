using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Drivers
{
    public class FacebookSuiteSettingsPartDriver : ContentPartDriver<FacebookSuiteSettingsPart>
    {
        protected override string Prefix
        {
            get { return "FacebookSuite"; }
        }

        // GET
        protected override DriverResult Editor(FacebookSuiteSettingsPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_FacebookSuiteSettings_SiteSettings",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts.FacebookSuiteSettings.SiteSettings",
                    Model: part,
                    Prefix: Prefix))
                    .OnGroup("FacebookSuiteSettings");
        }

        // POST
        protected override DriverResult Editor(FacebookSuiteSettingsPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}