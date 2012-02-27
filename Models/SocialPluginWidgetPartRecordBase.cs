using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;
using Orchard.Environment.Extensions;

namespace Piedone.Facebook.Suite.Models
{
    /// <summary>
    /// Base class for social plugin settings part records
    /// </summary>
    [OrchardFeature("Piedone.Facebook.Suite")]
    public abstract class SocialPluginWidgetPartRecordBase : ContentPartRecord
    {
        public virtual int Width { get; set; }
        public virtual string ColorScheme { get; set; }

        protected SocialPluginWidgetPartRecordBase()
        {
            Width = 500;
            ColorScheme = "light";
        }
    }
}