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
    [OrchardFeature("Piedone.Facebook.Suite.CommentsBox")]
    public class FacebookCommentsBoxDriver : ContentPartDriver<FacebookCommentsBoxPart>
    {
        protected override DriverResult Display(FacebookCommentsBoxPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_FacebookCommentsBox",
                () => shapeHelper.Parts_FacebookCommentsBox(
                                                NumberOfPosts: part.NumberOfPosts,
                                                Width: part.Width,
                                                ColorScheme: part.ColorScheme));
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
    }
}