using System.ComponentModel.DataAnnotations;
using Orchard.Environment.Extensions;

namespace Piedone.Facebook.Suite.Models
{
    [OrchardFeature("Piedone.Facebook.Suite.CommentsBox")]
    public class FacebookCommentsBoxWidgetPart : SocialPluginWidgetPartBase<FacebookCommentsBoxWidgetPartRecord>, IFacebookCommentsBox
    {
        [Required]
        public int NumberOfPosts
        {
            get { return Record.NumberOfPosts; }
            set { Record.NumberOfPosts = value; }
        }
    }
}