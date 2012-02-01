using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;

namespace Piedone.Facebook.Suite.Models
{
    public class SocialPluginPartBase<TRecord> : ContentPart<TRecord>
        where TRecord : SocialPluginPartRecordBase
    {
        public bool Enabled
        {
            get { return Record.Enabled; }
            set { Record.Enabled = value; }
        }
    }
}