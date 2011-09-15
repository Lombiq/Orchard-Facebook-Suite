using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard;
using Piedone.Facebook.Suite.Models;
using Facebook.Web;

namespace Piedone.Facebook.Suite.Services
{
    // TODO: docs
    public interface IFacebookSuiteService : IDependency
    {
        FacebookWebContext FacebookWebContext { get; }

        FacebookSuiteSettingsPart FacebookSuiteSettingsPart { get; }

        bool AppSettingsSet { get; }
    }
}