using Orchard.ContentManagement.Handlers;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Drivers
{
    public abstract class SocialPluginWithHeightDriver<TSocialPluginPart, TSocialPluginPartRecord> : SocialPluginPartDriver<TSocialPluginPart, TSocialPluginPartRecord>
        where TSocialPluginPart : SocialPluginWithHeightPart<TSocialPluginPartRecord>, new()
        where TSocialPluginPartRecord : SocialPluginWithHeightRecord
    {
    }
}