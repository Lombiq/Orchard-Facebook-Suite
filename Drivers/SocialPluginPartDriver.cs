using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Drivers
{
    public abstract class SocialPluginPartDriver<TSocialPluginPart, TSocialPluginPartRecord> : ContentPartDriver<TSocialPluginPart>
        where TSocialPluginPart : SocialPluginPart<TSocialPluginPartRecord>, new()
        where TSocialPluginPartRecord : SocialPluginPartRecord
    {
    }
}