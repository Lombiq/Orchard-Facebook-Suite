using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;

namespace Piedone.Facebook.Suite.Models
{
    /// <summary>
    /// Base class for social plugin type part settings (settings for a social plugin part, on a content type)
    /// </summary>
    public abstract class SocialPluginTypePartSettingsBase : ISocialPlugin
    {
        public int Width { get; set; }
        public string ColorScheme { get; set; }

        public SocialPluginTypePartSettingsBase()
        {
            Width = 500;
            ColorScheme = "light";
        }
    }
}