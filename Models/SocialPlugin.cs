using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

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
    /// <typeparam name="TSocialPluginPartRecord">A child of SocialPluginPartRecord</typeparam>
    public abstract class SocialPluginPart<TRecord> : ContentPart<TRecord>
        where TRecord : SocialPluginPartRecord
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