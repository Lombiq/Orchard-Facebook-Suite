using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Piedone.Facebook.Suite.Models;
using JetBrains.Annotations;
using Orchard.Localization;
using Orchard.ContentManagement;
using Orchard.Environment.Extensions;

namespace Piedone.Facebook.Suite.Handlers
{
    [OrchardFeature("Piedone.Facebook.Suite.Connect")]
    public class FacebookUserHandler : ContentHandler
    {
        public FacebookUserHandler(IRepository<FacebookUserPartRecord> repository)
        {
            Filters.Add(new ActivatingFilter<FacebookUserPart>("User"));
            // Enable the FacebookUser content type so we can use the content manager to manage FacebookUserParts
            //Filters.Add(new ActivatingFilter<FacebookUserPart>("FacebookUser"));
            Filters.Add(StorageFilter.For(repository));
        }

        //protected override void GetItemMetadata(GetContentItemMetadataContext context)
        //{
        //    var part = context.ContentItem.As<UserPart>();

        //    if (part != null)
        //    {
        //        context.Metadata.Identity.Add("User.UserName", part.UserName);
        //    }
        //}
    }
}