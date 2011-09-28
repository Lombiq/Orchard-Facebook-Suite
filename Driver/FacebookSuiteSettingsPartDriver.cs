using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard;
using Piedone.Facebook.Suite.Models;
using Orchard.Localization;

namespace Piedone.Facebook.Suite.Drivers
{
    public class FacebookSuiteSettingsPartDriver : ContentPartDriver<FacebookSuiteSettingsPart>
    {
        protected override string Prefix { get { return "FacebookSuiteSettings"; } }

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

        //// GET
        //protected override DriverResult Editor(FacebookSuiteSettingsPart part, dynamic shapeHelper)
        //{
        //    return Editor(part, null, shapeHelper);
        //}

        //// POST
        //protected override DriverResult Editor(FacebookSuiteSettingsPart part, IUpdateModel updater, dynamic shapeHelper)
        //{
        //    return ContentShape("Parts_FacebookSuiteSettings_SiteSettings", () =>
        //    {
        //        if (updater != null)
        //        {
        //            updater.TryUpdateModel(part.Record, Prefix, null, null);
        //        }
        //        return shapeHelper.EditorTemplate(TemplateName: "Parts.FacebookSuiteSettings.SiteSettings", Model: part, Prefix: Prefix);
        //    })
        //    .OnGroup("FacebookSuiteSettings");
        //}
    }
}