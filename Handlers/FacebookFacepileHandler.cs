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
    [OrchardFeature("Piedone.Facebook.Suite.Facepile")]
    public class FacebookFacepileHandler : ContentHandler
    {
        public FacebookFacepileHandler(IRepository<FacebookFacepilePartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}