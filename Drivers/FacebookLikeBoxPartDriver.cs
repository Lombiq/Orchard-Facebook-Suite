using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Environment.Extensions;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Drivers
{
    [OrchardFeature("Piedone.Facebook.Suite.LikeBox")]
    public class FacebookLikeBoxPartDriver : ContentPartDriver<FacebookLikeBoxPart>
    {
        protected override DriverResult Display(FacebookLikeBoxPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_FacebookLikeBox",
                () => shapeHelper.Parts_FacebookLikeBox(
                                                PageUrl: part.PageUrl,
                                                NumberOfPosts: part.PageUrl,
                                                Width: part.Width,
                                                ColorScheme: part.ColorScheme,
                                                ShowFaces: part.ShowFaces,
                                                BorderColor: part.BorderColor,
                                                ShowStream: part.ShowStream,
                                                ShowHeader: part.ShowHeader));
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