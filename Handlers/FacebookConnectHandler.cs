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
    public class FacebookConnectHandler : ContentHandler
    {
        public FacebookConnectHandler(IRepository<FacebookConnectPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}