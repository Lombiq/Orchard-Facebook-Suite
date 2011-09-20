using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard;
using Piedone.Facebook.Suite.Models;
using Facebook.Web;

namespace Piedone.Facebook.Suite.Services
{
    /// <summary>
    /// Service to access general Facebook Suite data
    /// </summary>
    public interface IFacebookSuiteService : IDependency
    {
        /// <summary>
        /// The current FacebookWebContext object
        /// </summary>
        FacebookWebContext FacebookWebContext { get; }

        /// <summary>
        /// The Facebook Suite settings
        /// </summary>
        FacebookSuiteSettingsPart FacebookSuiteSettingsPart { get; }

        /// <summary>
        /// Checks if the app settings were properly set
        /// </summary>
        bool AppSettingsSet { get; }
    }
}