using System;
using Facebook.Web;
using Orchard;
using Orchard.ContentManagement; // For generic ContentManager methods
using Orchard.Environment.Extensions;
using Orchard.Mvc;
using Piedone.Facebook.Suite.Models;
using Facebook;

namespace Piedone.Facebook.Suite.Services
{
    [OrchardFeature("Piedone.Facebook.Suite")]
    public class FacebookSuiteService : IFacebookSuiteService
    {
        private readonly IOrchardServices _orchardServices;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FacebookSuiteService(
            IHttpContextAccessor httpContextAccessor, 
            IOrchardServices orchardServices)
        {
            _httpContextAccessor = httpContextAccessor;
            _orchardServices = orchardServices;
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
                    _facebookSuiteSettingsPartCache = _orchardServices.WorkContext.CurrentSite.As<FacebookSuiteSettingsPart>();
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