using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;
using Orchard.Environment.Extensions;

namespace Piedone.Facebook.Suite.Models
{
    /// <summary>
    /// Base class for social plugin type part settings (settings for a social plugin part, on a content type)
    /// </summary>
    [OrchardFeature("Piedone.Facebook.Suite")]
    public abstract class SocialPluginTypePartSettingsBase
    {
        public int WidgetId { get; set; }
        public dynamic WidgetEditor { get; set; }
    }
}