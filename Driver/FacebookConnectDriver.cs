using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard;
using Piedone.Facebook.Suite.Models;
using Orchard.Environment.Extensions;
using Piedone.Facebook.Suite.Services;
using Piedone.Facebook.Suite.Helpers;
using System.Dynamic;
using Orchard.UI.Notify;

namespace Piedone.Facebook.Suite.Drivers
{
    [OrchardFeature("Piedone.Facebook.Suite.Connect")]
    public class FacebookConnectsDriver : ContentPartDriver<FacebookConnectPart>
    {
        private readonly IFacebookConnectService _facebookConnectService;
        private readonly IFacebookSuiteService _facebookSuiteService;
        //private readonly INotifier _notifier;

        public FacebookConnectsDriver(
            IFacebookConnectService facebookConnectService,
            IFacebookSuiteService facebookSuiteService//, INotifier notifier
            )
        {
            _facebookConnectService = facebookConnectService;
            _facebookSuiteService = facebookSuiteService;
            //_notifier = notifier;
        }

        protected override DriverResult Display(FacebookConnectPart part, string displayType, dynamic shapeHelper)
        {
            var currentUserPart = _facebookConnectService.GetAuthenticatedFacebookUserPart();
            dynamic CurrentUser = new ExpandoObject();

            bool isAuthorized = currentUserPart != null;
            if (!isAuthorized) // Not authenticated
            {
                string[] permissions = FacebookConnectHelper.PermissionSettingsToArray(part.Permissions);

                if (part.AutoLogin)
                {
                    isAuthorized = _facebookConnectService.Authorize(
                        permissions: FacebookConnectHelper.PermissionSettingsToArray(part.Permissions),
                        onlyAllowVerified: part.OnlyAllowVerified);
                    // MAJD string loginUrl = "https://www.facebook.com/dialog/oauth?client_id=" +  _facebookSuiteService.FacebookSuiteSettingsPart.AppId + "&redirect_uri=YOUR_URL&scope=email,read_stream";
                    if (isAuthorized)
                    {
                        currentUserPart = _facebookConnectService.GetAuthenticatedFacebookUserPart();
                    }
                }
            }

            if (isAuthorized)
            {
                CurrentUser.Name = currentUserPart.Name;
                CurrentUser.PictureLink = currentUserPart.PictureLink;
                CurrentUser.Link = currentUserPart.Link;
            }


            return ContentShape("Parts_FacebookConnect",
                () => shapeHelper.Parts_FacebookConnect(
                                        IsAuthorized: isAuthorized,
                                        AutoLogin: part.AutoLogin,
                                        Permissions: part.Permissions,
                                        OnlyAllowVerified: part.OnlyAllowVerified,
                                        CurrentUser: CurrentUser));
        }

        // GET
        protected override DriverResult Editor(FacebookConnectPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_FacebookConnect_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/FacebookConnect",
                    Model: part,
                    Prefix: Prefix));
        }

        // POST
        protected override DriverResult Editor(FacebookConnectPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            _facebookConnectService.Authorize();
            ValidationDictionaryTranscriber.TranscribeValidationDictionaryErrorsToUpdater(
                _facebookConnectService.ValidationDictionary,
                updater);
            updater.TryUpdateModel(part, Prefix, null, null);

            return Editor(part, shapeHelper);
        }
    }
}