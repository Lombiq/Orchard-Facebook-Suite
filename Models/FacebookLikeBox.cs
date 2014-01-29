using System.ComponentModel.DataAnnotations;
using Orchard.Environment.Extensions;

namespace Piedone.Facebook.Suite.Models
{
    [OrchardFeature("Piedone.Facebook.Suite.LikeBox")]
    public class FacebookLikeBoxPartRecord : SocialPluginWithHeightRecord
    {
        public virtual string PageUrl { get; set; }
        public virtual bool ShowFaces { get; set; }
        public virtual string BorderColor { get; set; }
        public virtual bool ShowStream { get; set; }
        public virtual bool ShowHeader { get; set; }

        public FacebookLikeBoxPartRecord() : base()
        {
            ShowFaces = true;
            BorderColor = "#fff";
            ShowStream = true;
            ShowHeader = true;
        }
    }

    [OrchardFeature("Piedone.Facebook.Suite.LikeBox")]
    public class FacebookLikeBoxPart : SocialPluginWithHeightPart<FacebookLikeBoxPartRecord>
    {
        [Required]
        public string PageUrl
        {
            get { return Retrieve(x => x.PageUrl); }
            set { Store(x => x.PageUrl, value); }
        }

        [Required]
        public bool ShowFaces
        {
            get { return Retrieve(x => x.ShowFaces); }
            set { Store(x => x.ShowFaces, value); }
        }

        [Required]
        public string BorderColor
        {
            get { return Retrieve(x => x.BorderColor); }
            set { Store(x => x.BorderColor, value); }
        }

        [Required]
        public bool ShowStream
        {
            get { return Retrieve(x => x.ShowStream); }
            set { Store(x => x.ShowStream, value); }
        }

        [Required]
        public bool ShowHeader
        {
            get { return Retrieve(x => x.ShowHeader); }
            set { Store(x => x.ShowHeader, value); }
        }
    }
}