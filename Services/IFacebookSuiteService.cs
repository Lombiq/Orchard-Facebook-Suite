using Facebook;
using Orchard;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Services
{
    /// <summary>
    /// Service to access general Facebook Suite data
    /// </summary>
    public interface IFacebookSuiteService : IDependency
    {
        /// <summary>
        /// The current FacebookClient object, filled with settings
        /// </summary>
        FacebookClient ClientForApp { get; }

        /// <summary>
        /// The Facebook Suite settings
        /// </summary>
        FacebookSuiteSettingsPart SettingsPart { get; }

        /// <summary>
        /// Checks if the app settings were properly set
        /// </summary>
        bool AppSettingsSet { get; }

        /// <summary>
        /// Returns a new FacebookClient to be used with any acess token, but filled with settings from the request context and applicable settings
        /// </summary>
        FacebookClient GetNewClient();
    }
}