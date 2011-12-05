using System;
using Facebook.Web;
using Orchard;
using Orchard.ContentManagement; // For generic ContentManager methods
using Orchard.Environment.Extensions;
using Orchard.Mvc;
using Piedone.Facebook.Suite.Models;
using Facebook;
using Orchard.Settings;

namespace Piedone.Facebook.Suite.Services
{
    [OrchardFeature("Piedone.Facebook.Suite")]
    public class FacebookSuiteService : IFacebookSuiteService
    {
        private readonly ISiteService _siteService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FacebookSuiteService(
            IHttpContextAccessor httpContextAccessor,
            ISiteService siteService)
        {
            _httpContextAccessor = httpContextAccessor;
            _siteService = siteService;
        }

        private FacebookWebContext _facebookWebContextCache;
        public FacebookWebContext FacebookWebContext
        {
            get
            {
                // Lazy loading the Facebook Web Context
                if (_facebookWebContextCache == null)
                {
                    if (!AppSettingsSet) return null;

                    _facebookWebContextCache = new FacebookWebContext(
                        FacebookSuiteSettingsPart,
                        _httpContextAccessor.Current());

                    FacebookApplication.SetApplication(FacebookSuiteSettingsPart); // A workaround for a bug: http://facebooksdk.codeplex.com/workitem/5917
                }
                return _facebookWebContextCache;
            }
        }

        private FacebookSuiteSettingsPart _facebookSuiteSettingsPartCache;
        public FacebookSuiteSettingsPart FacebookSuiteSettingsPart
        {
            get
            {
                if (_facebookSuiteSettingsPartCache == null)
                {
                    _facebookSuiteSettingsPartCache = _siteService.GetSiteSettings().As<FacebookSuiteSettingsPart>();
                }
                return _facebookSuiteSettingsPartCache;
            }
        }


        public bool AppSettingsSet
        {
            get
            {
                return !String.IsNullOrEmpty(FacebookSuiteSettingsPart.AppId);
            }
        }
        
    }
}