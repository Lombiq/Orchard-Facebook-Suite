using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Environment.Extensions;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Handlers
{
    [OrchardFeature("Piedone.Facebook.Suite.Facepile")]
    public class FacebookFacepilePartHandler : ContentHandler
    {
        public FacebookFacepilePartHandler(IRepository<FacebookFacepilePartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}