using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
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

        protected override void Exporting(FacebookSuiteSettingsPart part, ExportContentContext context)
        {
            var element = context.Element(part.PartDefinition.Name);

            element.SetAttributeValue("AppId", part.AppId);
            element.SetAttributeValue("AppSecret", part.AppSecret);
            element.SetAttributeValue("CancelUrlPath", part.CancelUrlPath);
            element.SetAttributeValue("CanvasPage", part.CanvasPage);
            element.SetAttributeValue("CanvasUrl", part.CanvasUrl);
            element.SetAttributeValue("SecureCanvasUrl", part.SecureCanvasUrl);
            element.SetAttributeValue("SiteUrl", part.SiteUrl);
            element.SetAttributeValue("UseFacebookBeta", part.UseFacebookBeta);
        }

        protected override void Importing(FacebookSuiteSettingsPart part, ImportContentContext context)
        {
            var partName = part.PartDefinition.Name;

            context.ImportAttribute(partName, "AppId", value => part.AppId = value);
            context.ImportAttribute(partName, "AppSecret", value => part.AppSecret = value);
            context.ImportAttribute(partName, "CancelUrlPath", value => part.CancelUrlPath = value);
            context.ImportAttribute(partName, "CanvasPage", value => part.CanvasPage = value);
            context.ImportAttribute(partName, "CanvasUrl", value => part.CanvasUrl = value);
            context.ImportAttribute(partName, "SecureCanvasUrl", value => part.SecureCanvasUrl = value);
            context.ImportAttribute(partName, "SiteUrl", value => part.SiteUrl = value);
            context.ImportAttribute(partName, "UseFacebookBeta", value => part.UseFacebookBeta = bool.Parse(value));
        }
    }
}