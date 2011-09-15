using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;
using Orchard.ContentManagement;
using System.ComponentModel.DataAnnotations;

namespace Piedone.Facebook.Suite.Models
{
    /// <summary>
    /// Base class for social plugin settings part records
    /// </summary>
    public abstract class SocialPluginPartRecord : ContentPartRecord
    {
        public virtual int Width { get; set; }
        public virtual string ColorScheme { get; set; }

        public SocialPluginPartRecord()
        {
            Width = 500;
            ColorScheme = "light";
        }
    }

    /// <summary>
    /// Base class for social plugin settings parts
    /// </summary>
    /// <typeparam name="T">A child of SocialPluginPartRecord</typeparam>
    public abstract class SocialPluginPart<T> : ContentPart<T> where T : SocialPluginPartRecord
    {
        [Required]
        public int Width
        {
            get { return Record.Width; }
            set { Record.Width = value; }
        }

        [Required]
        public string ColorScheme
        {
            get { return Record.ColorScheme; }
            set { Record.ColorScheme = value; }
        }
    }
}