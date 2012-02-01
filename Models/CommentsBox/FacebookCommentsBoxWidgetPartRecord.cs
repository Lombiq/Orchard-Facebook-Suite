using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Environment.Extensions;

namespace Piedone.Facebook.Suite.Models
{
    [OrchardFeature("Piedone.Facebook.Suite.CommentsBox")]
    public class FacebookCommentsBoxWidgetPartRecord : SocialPluginWidgetPartRecordBase, IFacebookCommentsBox
    {
        public virtual int NumberOfPosts { get; set; }

        public FacebookCommentsBoxWidgetPartRecord()
            : base()
        {
            NumberOfPosts = 15;
        }
    }
}