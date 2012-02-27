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
using Piedone.Facebook.Suite.Drivers;

namespace Piedone.Facebook.Suite.Settings
{
    [OrchardFeature("Piedone.Facebook.Suite.CommentsBox")]
    public class FacebookCommentsBoxSettingsHooks : ContentDefinitionEditorEventsBase
    {
        private readonly IContentManager _contentManager;

        public FacebookCommentsBoxSettingsHooks(IContentManager contentManager)
        {
            _contentManager = contentManager;
        }

        public override IEnumerable<TemplateViewModel> TypePartEditor(ContentTypePartDefinition definition)
        {
            if (definition.PartDefinition.Name != "FacebookCommentsBoxPart")
                yield break;

            var model = definition.Settings.GetModel<FacebookCommentsBoxTypePartSettings>();

            model.WidgetEditor = _contentManager.BuildEditor(GetWidget(model));

            yield return DefinitionTemplate(model, "SocialPluginTypePartSettings", "SocialPluginTypePartSettings");
        }

        public override IEnumerable<TemplateViewModel> TypePartEditorUpdate(ContentTypePartDefinitionBuilder builder, IUpdateModel updater)
        {
            if (builder.Name != "FacebookCommentsBoxPart")
                yield break;

            var model = new FacebookCommentsBoxTypePartSettings();

            // This update is necessary as there seems no way to get the current settings as in TypePartEditor()
            updater.TryUpdateModel(model, "SocialPluginTypePartSettings", null, null);

            var widget = GetWidget(model);
            updater.TryUpdateModel(widget.As<FacebookCommentsBoxWidgetPart>(), "SocialPluginTypePartSettings." + FacebookCommentsBoxWidgetPartDriver.EditorPrefix, null, null);
            //_contentManager.UpdateEditor(widget, updater);
            model.WidgetEditor = _contentManager.BuildEditor(widget);
            if (widget.Id == 0) _contentManager.Create(widget);

            builder.WithSetting("FacebookCommentsBoxTypePartSettings.WidgetId", widget.Id.ToString());

            yield return DefinitionTemplate(model, "SocialPluginTypePartSettings", "SocialPluginTypePartSettings");
        }

        private IContent GetWidget(FacebookCommentsBoxTypePartSettings settings)
        {
            return settings.WidgetId == 0 ? _contentManager.New("FacebookCommentsBoxPartWidget") : _contentManager.Get(settings.WidgetId);
        }
    }
}