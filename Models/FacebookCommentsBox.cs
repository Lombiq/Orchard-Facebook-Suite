using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;
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