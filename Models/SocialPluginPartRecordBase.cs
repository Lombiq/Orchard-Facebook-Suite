using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;

namespace Piedone.Facebook.Suite.Models
{
    public class SocialPluginPartRecordBase : ContentPartRecord
    {
        public virtual bool Enabled { get; set; }
    }
}