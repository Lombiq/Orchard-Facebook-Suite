using System.ComponentModel.DataAnnotations;
using Orchard.Environment.Extensions;

namespace Piedone.Facebook.Suite.Models
{
    [OrchardFeature("Piedone.Facebook.Suite.Facepile")]
    public class FacebookFacepilePartRecord : SocialPluginPartRecord
    {
        public virtual int MaxRows { get; set; }
        public virtual string Size { get; set; }

        public FacebookFacepilePartRecord() : base()
        {
            MaxRows = 1;
            Size = "small";
        }
    }

    [OrchardFeature("Piedone.Facebook.Suite.Facepile")]
    public class FacebookFacepilePart : SocialPluginPart<FacebookFacepilePartRecord>
    {
        [Required]
        public int MaxRows
        {
            get { return Record.MaxRows; }
            set { Record.MaxRows = value; }
        }

        [Required]
        public string Size
        {
            get { return Record.Size; }
            set { Record.Size = value; }
        }
    }
}