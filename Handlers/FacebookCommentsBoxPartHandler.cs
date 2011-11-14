using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Environment.Extensions;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Handlers
{
    [OrchardFeature("Piedone.Facebook.Suite.CommentsBox")]
    public class FacebookCommentsPartBoxHandler : ContentHandler
    {
        public FacebookCommentsPartBoxHandler(IRepository<FacebookCommentsBoxPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}