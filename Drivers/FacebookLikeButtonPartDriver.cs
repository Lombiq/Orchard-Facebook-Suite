using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Environment.Extensions;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Drivers
{
    [OrchardFeature("Piedone.Facebook.Suite.LikeButton")]
    public class FacebookLikeButtonPartDriver : ContentPartDriver<FacebookLikeButtonPart>
    {
        protected override DriverResult Display(FacebookLikeButtonPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_FacebookLikeButton",
                () => shapeHelper.Parts_FacebookLikeButton(
                                                EnableSendButton: part.EnableSendButton,
                                                LayoutStyle: part.LayoutStyle,
                                                Width: part.Width,
                                                ShowFaces: part.ShowFaces,
                                                VerbToDisplay: part.VerbToDisplay,
                                                ColorScheme: part.ColorScheme,
                                                Font: part.Font));
        }

        // GET
        protected override DriverResult Editor(FacebookLikeButtonPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_FacebookLikeButton_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/FacebookLikeButton",
                    Model: part,
                    Prefix: Prefix));
        }

        // POST
        protected override DriverResult Editor(FacebookLikeButtonPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}