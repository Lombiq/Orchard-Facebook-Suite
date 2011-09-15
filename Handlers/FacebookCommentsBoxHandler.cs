using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Piedone.Facebook.Suite.Models;
using Orchard.Environment.Extensions;

namespace Piedone.Facebook.Suite.Handlers
{
    [OrchardFeature("Piedone.Facebook.Suite.CommentsBox")]
    public class FacebookCommentsBoxHandler : ContentHandler
    {
        public FacebookCommentsBoxHandler(IRepository<FacebookCommentsBoxPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}