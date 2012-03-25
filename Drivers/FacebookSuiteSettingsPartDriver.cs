using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Piedone.Facebook.Suite.Models;
using Orchard.ContentManagement.Handlers;

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
            context.Element(part.PartDefinition.Name).SetAttributeValue("AppId", part.AppId);
            context.Element(part.PartDefinition.Name).SetAttributeValue("AppSecret", part.AppSecret);
            context.Element(part.PartDefinition.Name).SetAttributeValue("CancelUrlPath", part.CancelUrlPath);
            context.Element(part.PartDefinition.Name).SetAttributeValue("CanvasPage", part.CanvasPage);
            context.Element(part.PartDefinition.Name).SetAttributeValue("CanvasUrl", part.CanvasUrl);
            context.Element(part.PartDefinition.Name).SetAttributeValue("IsSecureConnection", part.IsSecureConnection);
            context.Element(part.PartDefinition.Name).SetAttributeValue("SecureCanvasUrl", part.SecureCanvasUrl);
            context.Element(part.PartDefinition.Name).SetAttributeValue("SiteUrl", part.SiteUrl);
            context.Element(part.PartDefinition.Name).SetAttributeValue("UseFacebookBeta", part.UseFacebookBeta);
        }

        protected override void Importing(FacebookSuiteSettingsPart part, ImportContentContext context)
        {
            part.AppId = context.Attribute(part.PartDefinition.Name, "AppId");
            part.AppSecret = context.Attribute(part.PartDefinition.Name, "AppSecret");
            part.CancelUrlPath = context.Attribute(part.PartDefinition.Name, "CancelUrlPath");
            part.CanvasPage = context.Attribute(part.PartDefinition.Name, "CanvasPage");
            part.CanvasUrl = context.Attribute(part.PartDefinition.Name, "CanvasUrl");
            part.IsSecureConnection = bool.Parse(context.Attribute(part.PartDefinition.Name, "IsSecureConnection"));
            part.SecureCanvasUrl = context.Attribute(part.PartDefinition.Name, "SecureCanvasUrl");
            part.SiteUrl = context.Attribute(part.PartDefinition.Name, "SiteUrl");
            part.UseFacebookBeta = bool.Parse(context.Attribute(part.PartDefinition.Name, "UseFacebookBeta"));
        }
    }
}