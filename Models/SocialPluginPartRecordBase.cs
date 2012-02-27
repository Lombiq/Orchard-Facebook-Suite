using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;
using Orchard.Environment.Extensions;

namespace Piedone.Facebook.Suite.Models
{
    [OrchardFeature("Piedone.Facebook.Suite")]
    public abstract class SocialPluginPartRecordBase : ContentPartRecord
    {
        public virtual bool Enabled { get; set; }

        protected SocialPluginPartRecordBase()
        {
            Enabled = true;
        }
    }
}