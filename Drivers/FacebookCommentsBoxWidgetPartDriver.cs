﻿using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Environment.Extensions;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Drivers
{
    [OrchardFeature("Piedone.Facebook.Suite.CommentsBox")]
    public class FacebookCommentsBoxWidgetPartDriver : ContentPartDriver<FacebookCommentsBoxWidgetPart>
    {
        public static string EditorPrefix
        {
            get { return "CommentsBox"; }
        }

        protected override string Prefix
        {
            get { return EditorPrefix; }
        }

        protected override DriverResult Display(FacebookCommentsBoxWidgetPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_FacebookCommentsBox",
                () => shapeHelper.Parts_FacebookCommentsBox(
                                                NumberOfPosts: part.NumberOfPosts,
                                                Width: part.Width,
                                                ColorScheme: part.ColorScheme));
        }

        // GET
        protected override DriverResult Editor(FacebookCommentsBoxWidgetPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_FacebookCommentsBox_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/FacebookCommentsBox",
                    Model: part,
                    Prefix: Prefix));
        }

        // POST
        protected override DriverResult Editor(FacebookCommentsBoxWidgetPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}