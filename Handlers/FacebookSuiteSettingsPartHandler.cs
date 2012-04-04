using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Environment.Extensions;
using Orchard.Localization;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Handlers
{
    [OrchardFeature("Piedone.Facebook.Suite")]
    public class FacebookSuiteSettingsPartHandler : ContentHandler
    {
        public Localizer T { get; set; }

        public FacebookSuiteSettingsPartHandler(IRepository<FacebookSuiteSettingsPartRecord> repository)
        {
            T = NullLocalizer.Instance;

            // We attach the settings part to the "Site" part as site settings is also a part.
            // This way our settings become part of the site settings and we can edit them from
            // the "Settings" admin menu.
            Filters.Add(new ActivatingFilter<FacebookSuiteSettingsPart>("Site"));

            Filters.Add(StorageFilter.For(repository));
        }

        protected override void GetItemMetadata(GetContentItemMetadataContext context)
        {
            if (context.ContentItem.ContentType != "Site")
                return;

            base.GetItemMetadata(context);

            var groupInfo = new GroupInfo(T("Facebook Suite")); // Addig a new group to the "Settings" menu.
            groupInfo.Id = "FacebookSuiteSettings";
            context.Metadata.EditorGroupInfo.Add(groupInfo);
        }
    }
}