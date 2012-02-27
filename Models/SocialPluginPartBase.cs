using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.Environment.Extensions;

namespace Piedone.Facebook.Suite.Models
{
    [OrchardFeature("Piedone.Facebook.Suite")]
    public abstract class SocialPluginPartBase<TRecord> : ContentPart<TRecord>
        where TRecord : SocialPluginPartRecordBase
    {
        public bool Enabled
        {
            get { return Record.Enabled; }
            set { Record.Enabled = value; }
        }
    }
}