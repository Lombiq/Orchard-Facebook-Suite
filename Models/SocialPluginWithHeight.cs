using System.ComponentModel.DataAnnotations;

namespace Piedone.Facebook.Suite.Models
{
    /// <summary>
    /// This is used with Like Box but could also be used with Live Stream.
    /// </summary>
    public abstract class SocialPluginWithHeightRecord : SocialPluginPartRecord
    {
        public virtual int Height { get; set; }

        public SocialPluginWithHeightRecord()
        {
            Height = 400;
        }
    }


    public abstract class SocialPluginWithHeightPart<TRecord> : SocialPluginPart<TRecord>
        where TRecord : SocialPluginWithHeightRecord
    {
        [Required]
        public int Height
        {
            get { return Retrieve(x => x.Height); }
            set { Store(x => x.Height, value); }
        }
    }
}