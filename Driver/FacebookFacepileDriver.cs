using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard;
using Piedone.Facebook.Suite.Models;
using Orchard.Environment.Extensions;

namespace Piedone.Facebook.Suite.Drivers
{
    [OrchardFeature("Piedone.Facebook.Suite.Facepile")]
    public class FacebookFacepileDriver : ContentPartDriver<FacebookFacepilePart>
    {
        protected override DriverResult Display(FacebookFacepilePart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_FacebookFacepile",
                () => shapeHelper.Parts_FacebookFacepile(
                                                Width: part.Width,
                                                ColorScheme: part.ColorScheme,
                                                MaxRows: part.MaxRows,
                                                Size: part.Size));
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