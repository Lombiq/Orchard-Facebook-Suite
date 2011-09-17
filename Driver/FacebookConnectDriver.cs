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
using Orchard.Security;

namespace Piedone.Facebook.Suite.Drivers
{
    [OrchardFeature("Piedone.Facebook.Suite.Connect")]
    public class FacebookConnectsDriver : ContentPartDriver<FacebookConnectPart>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IFacebookConnectService _facebookConnectService;
        private readonly IFacebookSuiteService _facebookSuiteService;

        public FacebookConnectsDriver(
            IAuthenticationService authenticationService,
            IFacebookConnectService facebookConnectService,
            IFacebookSuiteService facebookSuiteService
            )
        {
            _authenticationService = authenticationService;
            _facebookConnectService = facebookConnectService;
            _facebookSuiteService = facebookSuiteService;
        }

        protected override DriverResult Display(FacebookConnectPart part, string displayType, dynamic shapeHelper)
        {
            bool isAuthenticated = _authenticationService.GetAuthenticatedUser() != null;
            var currentUserPart = _facebookConnectService.GetAuthenticatedFacebookUserPart();
            bool isConnected = currentUserPart != null;
            
            dynamic CurrentUser = new ExpandoObject();

            if (!isAuthenticated)
            {
                string[] permissions = FacebookConnectHelper.PermissionSettingsToArray(part.Permissions);

                if (part.AutoLogin)
                {
                    isConnected = _facebookConnectService.Authorize(
                        permissions: FacebookConnectHelper.PermissionSettingsToArray(part.Permissions),
                        onlyAllowVerified: part.OnlyAllowVerified);
                    // string loginUrl = "https://www.facebook.com/dialog/oauth?client_id=" +  _facebookSuiteService.FacebookSuiteSettingsPart.AppId + "&redirect_uri=YOUR_URL&scope=email,read_stream";
                    if (isConnected)
                    {
                        currentUserPart = _facebookConnectService.GetAuthenticatedFacebookUserPart();
                    }
                }
            }

            if (isConnected)
            {
                CurrentUser.Name = currentUserPart.Name;
                CurrentUser.PictureLink = currentUserPart.PictureLink;
                CurrentUser.Link = currentUserPart.Link;
            }


            return ContentShape("Parts_FacebookConnect",
                () => shapeHelper.Parts_FacebookConnect(
                                        IsAuthenticated: isAuthenticated,
                                        IsConnected: isConnected,
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
            updater.TryUpdateModel(part, Prefix, null, null);

            return Editor(part, shapeHelper);
        }
    }
}