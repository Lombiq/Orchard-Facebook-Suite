using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard.Mvc.Extensions;
using Piedone.Facebook.Suite.Services;
using Piedone.Facebook.Suite.Helpers;

namespace Piedone.Facebook.Suite.Controllers
{
    [HandleError]
    public class ConnectController : Controller
    {
        private readonly IFacebookConnectService _facebookConnectService;

        public ConnectController(IFacebookConnectService facebookConnectService)
        {
            _facebookConnectService = facebookConnectService;
        }

        //
        // GET: /Connect/

        public ActionResult Connect(string permissions = "", bool onlyAllowVerified = false, string returnUrl = "")
        {
            _facebookConnectService.Authorize(
                permissions: FacebookConnectHelper.PermissionSettingsToArray(permissions), 
                onlyAllowVerified: onlyAllowVerified);

            return this.RedirectLocal(returnUrl); // this necessary, as this is from an extension (Orchard.Mvc.Extensions.ControllerExtensions)
        }

    }
}
