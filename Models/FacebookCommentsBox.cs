using System.ComponentModel.DataAnnotations;
using Orchard.Environment.Extensions;

namespace Piedone.Facebook.Suite.Models
{
    [OrchardFeature("Piedone.Facebook.Suite.CommentsBox")]
    public class FacebookCommentsBoxPartRecord : SocialPluginPartRecord
    {
        public virtual int NumberOfPosts { get; set; }

        public FacebookCommentsBoxPartRecord() : base()
        {
            NumberOfPosts = 15;
        }
    }

    [OrchardFeature("Piedone.Facebook.Suite.CommentsBox")]
    public class FacebookCommentsBoxPart : SocialPluginPart<FacebookCommentsBoxPartRecord>
    {
        [Required]
        public int NumberOfPosts
        {
            get { return Record.NumberOfPosts; }
            set { Record.NumberOfPosts = value; }
        }
    }
}