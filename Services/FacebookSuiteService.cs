﻿using System;
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

        private FacebookClient _client;
        public FacebookClient Client
        {
            get
            {
                if (_client == null)
                {
                    if (!AppSettingsSet) return null;

                    _client = new FacebookClient
                    {
                        AppId = SettingsPart.AppId,
                        AppSecret = SettingsPart.AppSecret,
                        UseFacebookBeta = SettingsPart.UseFacebookBeta,
                        IsSecureConnection = _httpContextAccessor.Current().Request.IsSecureConnection
                    };
                }
                return _client;
            }
        }

        private FacebookSuiteSettingsPart _settingsPart;
        public FacebookSuiteSettingsPart SettingsPart
        {
            get
            {
                if (_settingsPart == null)
                {
                    _settingsPart = _siteService.GetSiteSettings().As<FacebookSuiteSettingsPart>();
                }
                return _settingsPart;
            }
        }

        public bool AppSettingsSet
        {
            get
            {
                return !String.IsNullOrEmpty(SettingsPart.AppId);
            }
        }


        public FacebookSuiteService(
            IHttpContextAccessor httpContextAccessor,
            ISiteService siteService)
        {
            _httpContextAccessor = httpContextAccessor;
            _siteService = siteService;
        }


        public FacebookClient GetNewClient()
        {
            return new FacebookClient
            {
                UseFacebookBeta = SettingsPart.UseFacebookBeta,
                IsSecureConnection = _httpContextAccessor.Current().Request.IsSecureConnection
            };
        }
    }
}