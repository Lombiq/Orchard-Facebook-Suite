using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Piedone.Facebook.Suite.Models;
using JetBrains.Annotations;
using Orchard.Localization;
using Orchard.ContentManagement;
using Orchard.Environment.Extensions;

namespace Piedone.Facebook.Suite.Handlers
{
    [OrchardFeature("Piedone.Facebook.Suite")]
    public class FacebookSuiteSettingsHandler : ContentHandler
    {
        public FacebookSuiteSettingsHandler(IRepository<FacebookSuiteSettingsPartRecord> repository)
        {
            T = NullLocalizer.Instance;

            // We attach the settings part to the "Site" part as site settings is also a part.
            // This way our settings become part of the site settings and we can edit them from
            // the "Settings" admin menu.
            Filters.Add(new ActivatingFilter<FacebookSuiteSettingsPart>("Site"));

            Filters.Add(StorageFilter.For(repository));
        }

        public Localizer T { get; set; }

        protected override void GetItemMetadata(GetContentItemMetadataContext context) {
            if (context.ContentItem.ContentType != "Site")
                return;
            base.GetItemMetadata(context);
            var groupInfo = new GroupInfo(T("Facebook Suite Settings")); // Addig a new group to the "Settings" menu.
            groupInfo.Id = "FacebookSuiteSettings";
            context.Metadata.EditorGroupInfo.Add(groupInfo);
        }
    }
}