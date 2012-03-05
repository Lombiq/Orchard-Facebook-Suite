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
            get { return Record.PageUrl; }
            set { Record.PageUrl = value; }
        }

        [Required]
        public bool ShowFaces
        {
            get { return Record.ShowFaces; }
            set { Record.ShowFaces = value; }
        }

        [Required]
        public string BorderColor
        {
            get { return Record.BorderColor; }
            set { Record.BorderColor = value; }
        }

        [Required]
        public bool ShowStream
        {
            get { return Record.ShowStream; }
            set { Record.ShowStream = value; }
        }

        [Required]
        public bool ShowHeader
        {
            get { return Record.ShowHeader; }
            set { Record.ShowHeader = value; }
        }
    }
}