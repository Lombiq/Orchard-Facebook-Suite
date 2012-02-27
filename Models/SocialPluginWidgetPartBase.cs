using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;
using Orchard.Environment.Extensions;

namespace Piedone.Facebook.Suite.Models
{
    /// <summary>
    /// Base class for social plugin settings parts
    /// </summary>
    /// <typeparam name="TSocialPluginPartRecord">A child of SocialPluginPartRecord</typeparam>
    [OrchardFeature("Piedone.Facebook.Suite")]
    public abstract class SocialPluginWidgetPartBase<TRecord> : ContentPart<TRecord>
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