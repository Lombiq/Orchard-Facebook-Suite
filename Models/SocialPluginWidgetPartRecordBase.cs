using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;

namespace Piedone.Facebook.Suite.Models
{
    /// <summary>
    /// Base class for social plugin settings part records
    /// </summary>
    public abstract class SocialPluginWidgetPartRecordBase : ContentPartRecord, ISocialPlugin
    {
        public virtual int Width { get; set; }
        public virtual string ColorScheme { get; set; }

        public SocialPluginWidgetPartRecordBase()
        {
            Width = 500;
            ColorScheme = "light";
        }
    }
}