using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Environment.Extensions;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.ViewModels;
using Orchard.ContentManagement.MetaData.Models;
using Piedone.Facebook.Suite.Models;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.ContentManagement;

namespace Piedone.Facebook.Suite.Settings
{
    [OrchardFeature("Piedone.Facebook.Suite.CommentsBox")]
    public class FacebookCommentsBoxSettingsHooks : ContentDefinitionEditorEventsBase
    {
        public override IEnumerable<TemplateViewModel> TypePartEditor(ContentTypePartDefinition definition)
        {
            if (definition.PartDefinition.Name != "FacebookCommentsBoxPart")
                yield break;

            var model = definition.Settings.GetModel<FacebookCommentsBoxTypePartSettings>();

            yield return DefinitionTemplate(model);
        }

        public override IEnumerable<TemplateViewModel> TypePartEditorUpdate(ContentTypePartDefinitionBuilder builder, IUpdateModel updateModel)
        {
            if (builder.Name != "FacebookCommentsBoxPart")
                yield break;

            var model = new FacebookCommentsBoxTypePartSettings();

            updateModel.TryUpdateModel(model, "FacebookCommentsBoxTypePartSettings", null, null);

            builder.WithSetting("FacebookCommentsBoxTypePartSettings.Width", model.Width.ToString());
            builder.WithSetting("FacebookCommentsBoxTypePartSettings.ColorScheme", model.ColorScheme);
            builder.WithSetting("FacebookCommentsBoxTypePartSettings.NumberOfPosts", model.NumberOfPosts.ToString());

            yield return DefinitionTemplate(model);
        }
    }
}