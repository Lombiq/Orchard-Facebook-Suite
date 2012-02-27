using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Environment.Extensions;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Models
{
    [OrchardFeature("Piedone.Facebook.Suite.CommentsBox")]
    public class FacebookCommentsBoxPart : SocialPluginPartBase<FacebookCommentsBoxPartRecord>
    {
    }
}