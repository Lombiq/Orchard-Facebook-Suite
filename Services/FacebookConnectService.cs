using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Security;
using Piedone.Facebook.Suite.Models;
using Facebook.Web;
using Orchard;
using Orchard.ContentManagement; // For generic ContentManager methods
using Piedone.Facebook.Suite.Helpers;
using Facebook;
using Orchard.Logging;
using Orchard.Localization;
using Piedone.Facebook.Suite.Validation;

namespace Piedone.Facebook.Suite.Services
{
    public class FacebookConnectService : IFacebookConnectService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMembershipService _membershipService;
        private readonly IOrchardServices _orchardServices;
        private readonly IContentManager _contentManager;
        private readonly IFacebookSuiteService _facebookSuiteService;

        public IValidationDictionary ValidationDictionary { get; private set; }
        public ILogger Logger { get; set; }
        public Localizer T { get; set; }

        public FacebookConnectService(
            IAuthenticationService authenticationService,
            IMembershipService membershipService,
            IOrchardServices orchardServices,
            IServiceValidationDictionary validationDictionary,
            IFacebookSuiteService facebookSuiteService)
        {
            _authenticationService = authenticationService;
            _membershipService = membershipService;
            _orchardServices = orchardServices;
            _contentManager = orchardServices.ContentManager;
            ValidationDictionary = validationDictionary;
            _facebookSuiteService = facebookSuiteService;

            Logger = NullLogger.Instance; // Constructor injection fails
            T = NullLocalizer.Instance;
        }


        /// <inheritdoc/>
        /// <summary>
        /// WARNING: does not check if the user is authenticated with Orchard.
        /// </summary>
        /// <returns>True if the user is logged in on Facebook and connected to the app, false otherwise.</returns>
        public bool IsAuthenticated()
        {
            return _facebookSuiteService.FacebookWebContext.IsAuthenticated();
        }

        /// <inheritdoc/>
        public bool IsAuthorized(string[] permissions = null)
        {
            return _facebookSuiteService.FacebookWebContext.IsAuthorized(permissions);
        }

        /// <inheritdoc/>
        /// <summary>
        /// Success is also if the user is only authenticated with Orchard.
        /// </summary>
        /// <seealso cref="FacebookConnectService.IsAuthorized()"/>
        /// <exception cref="Orchard.OrchardException">Thrown if Facebook API calls fail.</exception>
        public bool Authorize(string[] permissions = null, bool onlyAllowVerified = false)
        {
            var authenticatedUser = _authenticationService.GetAuthenticatedUser();

            // User is already authenticated with Orchard, no need to authenticate with Facebook.
            if (authenticatedUser != null) return true; 

            // User is not authenticated on Facebook or hasn't connected to our app or hasn't granted the needed permissions.
            if (!IsAuthorized(permissions))
            {
                if (!IsAuthenticated()) ValidationDictionary.AddError("notAuthenticated", T("User is not authenticated on Facebook."));
                else ValidationDictionary.AddError("noPermissions", T("The requested permissions were not granted."));

                return false;
            }

            // Now we know that the user is authenticated on Facebook and connected to our app.

            FacebookUserPart fbUserPart = GetFacebookUserPart(_facebookSuiteService.FacebookWebContext.UserId); // Check if we already have the user's data saved

            var fbClient = new FacebookWebClient(_facebookSuiteService.FacebookWebContext);

            Action<IUser> signIn =
                u =>
                {
                    _authenticationService.SignIn(
                        u,
                        true);
                };

            dynamic me = "";

            // We have previously saved the user's data
            if (fbUserPart != null)
            {
                signIn(fbUserPart.As<Orchard.Users.Models.UserPart>().As<IUser>());
                fbClient.GetCompleted +=
                    (sender, e) =>
                    {
                        if (e.Error == null)
                        {
                            me = e.GetResultData();

                            // It is not handled if the user's name changed
                            //bool nameHasChanged = fbUserPart.Name != me.name;

                            // Update saved user
                            fbUserPart = FacebookUserDataMapper.MapToFacebookUserPart(
                                new FacebookUserDataMapper(me),
                                fbUserPart);
                            _contentManager.Flush(); // Else the update would not commit.

                            //if (nameHasChanged)
                            //{
                            //    var userPart = _contentManager.Get<Orchard.Users.Models.UserPart>(fbUserPart.UserId);
                            //    userPart.UserName = fbUserPart.Name;
                            //    userPart.NormalizedUserName = fbUserPart.Name.ToLowerInvariant(); // This is taken from the implementation, but should reall be in a method of MembershipService 
                            //}
                        }
                        else
                        {
                            string message = "Error in retrieving Facebook user data: " + e.Error.Message;
                            Logger.Error(e.Error, message);
                            // Maybe not wise to throw an exception here
                        }
                    };
                fbClient.GetAsync("me"); // Updating user data can run in the background
            }
            // We don't currently have the user's data
            else
            {
                try
                {
                    me = fbClient.Get("me");
                    var dataMapper = new FacebookUserDataMapper(me);

                    if (onlyAllowVerified && !dataMapper.IsVerified)
                    {
                        ValidationDictionary.AddError("notVerified", T("User is not verified."));
                        return false;
                    }
                    //fbUserPart = mapFBApiResultFieldsToFacebookUserPartFields(
                    //    me, 
                    //    _contentManager.New<FacebookUserPart>("FacebookUser"));
                    //_contentManager.Create(fbUserPart);

                    // Does not need to verifiy user unicity as there can be more people with the same name.
                    // Or maybe it would be clever to get the email too, so users will be guaranteedly unique.
                    var random = new Random();
                    authenticatedUser = _membershipService.CreateUser(
                        new CreateUserParams(
                            dataMapper.Name,
                            random.Next().ToString(),
                            dataMapper.Email,
                            "",
                            "",
                            true));

                    fbUserPart = authenticatedUser.As<FacebookUserPart>();
                    fbUserPart = FacebookUserDataMapper.MapToFacebookUserPart(dataMapper, fbUserPart);

                    signIn(authenticatedUser);
                }
                catch (Exception e)
                {
                    string message = "Error in retrieving Facebook user data: " + e.Message;
                    Logger.Error(e, message);
                    throw new OrchardException(T(message), e); // Useless to localize
                }
            }

            return true;
        }

        /// <inheritdoc/>
        public FacebookUserPart GetFacebookUserPart(long facebookId)
        {
            return _contentManager
                .Query<FacebookUserPart, FacebookUserPartRecord>()
                .Where(u => u.FacebookUserId == facebookId).List().FirstOrDefault<FacebookUserPart>();
        }

        /// <inheritdoc/>
        public FacebookUserPart GetFacebookUserPart(int id)
        {
            // This way if no entry was found, null will be returned. This is preferred.
            // _contentManager.Get<FacebookUserPart>(id); would return an empty object.
            return _contentManager
                .Query<FacebookUserPart, FacebookUserPartRecord>()
                .Where(u => u.Id == id).List().FirstOrDefault<FacebookUserPart>();
        }


        public FacebookUserPart GetAuthenticatedFacebookUserPart()
        {
            // _authenticationService.GetAuthenticatedUser().As<FacebookUserPart>(); would
            // return an empty object, not null if no entry was found. See GetFacebookUserPart(int id).
            var authenticatedUser = _authenticationService.GetAuthenticatedUser();
            if (authenticatedUser == null) return null;
            return GetFacebookUserPart(authenticatedUser.Id);
        }
    }
}