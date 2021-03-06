﻿using System.ComponentModel.DataAnnotations;
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
            get { return Retrieve(x => x.EnableSendButton); }
            set { Store(x => x.EnableSendButton, value); }
        }

        [Required]
        public string LayoutStyle
        {
            get { return Retrieve(x => x.LayoutStyle); }
            set { Store(x => x.LayoutStyle, value); }
        }

        [Required]
        public bool ShowFaces
        {
            get { return Retrieve(x => x.ShowFaces); }
            set { Store(x => x.ShowFaces, value); }
        }

        [Required]
        public string VerbToDisplay
        {
            get { return Retrieve(x => x.VerbToDisplay); }
            set { Store(x => x.VerbToDisplay, value); }
        }

        [Required]
        public string Font
        {
            get { return Retrieve(x => x.Font); }
            set { Store(x => x.Font, value); }
        }
    }
}