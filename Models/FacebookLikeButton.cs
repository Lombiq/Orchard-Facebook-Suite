using System.ComponentModel.DataAnnotations;
using Orchard.Environment.Extensions;

namespace Piedone.Facebook.Suite.Models
{
    [OrchardFeature("Piedone.Facebook.Suite.LikeButton")]
    public class FacebookLikeButtonPartRecord : SocialPluginPartRecord
    {
        public virtual bool EnableSendButton { get; set; }
        public virtual string LayoutStyle { get; set; }
        public virtual bool ShowFaces { get; set; }
        public virtual string VerbToDisplay { get; set; }
        public virtual string Font { get; set; }

        public FacebookLikeButtonPartRecord() : base()
        {
            EnableSendButton = true;
            LayoutStyle = "standard";
            ShowFaces = false;
            VerbToDisplay = "like";
            Font = "arial";
        }
    }

    [OrchardFeature("Piedone.Facebook.Suite.LikeButton")]
    public class FacebookLikeButtonPart : SocialPluginPart<FacebookLikeButtonPartRecord>
    {
        [Required]
        public bool EnableSendButton
        {
            get { return Record.EnableSendButton; }
            set { Record.EnableSendButton = value; }
        }

        [Required]
        public string LayoutStyle
        {
            get { return Record.LayoutStyle; }
            set { Record.LayoutStyle = value; }
        }

        [Required]
        public bool ShowFaces
        {
            get { return Record.ShowFaces; }
            set { Record.ShowFaces = value; }
        }

        [Required]
        public string VerbToDisplay
        {
            get { return Record.VerbToDisplay; }
            set { Record.VerbToDisplay = value; }
        }

        [Required]
        public string Font
        {
            get { return Record.Font; }
            set { Record.Font = value; }
        }
    }
}