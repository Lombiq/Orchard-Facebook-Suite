using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace Piedone.Facebook.Suite.Models
{
    /// <summary>
    /// Base class for social plugin settings parts
    /// </summary>
    /// <typeparam name="TSocialPluginPartRecord">A child of SocialPluginPartRecord</typeparam>
    public abstract class SocialPluginWidgetPartBase<TRecord> : ContentPart<TRecord>, ISocialPlugin
        where TRecord : SocialPluginWidgetPartRecordBase
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