using System.Text;
using System.Web.Mvc;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Environment.Extensions;
using Orchard.Mvc;
using Orchard.Mvc.Filters;
using Orchard.UI.Resources;
using Orchard.DisplayManagement;
using Piedone.Facebook.Suite.Services;

namespace Piedone.Facebook.Suite.Filters
{
    [OrchardFeature("Piedone.Facebook.Suite")]
    public class FacebookSuiteFilter : FilterProvider, IResultFilter
    {
        private readonly IResourceManager _resourceManager;
        private readonly IWorkContextAccessor _workContextAccessor;
        private readonly dynamic _shapeFactory;
        private readonly IOrchardServices _orchardServices;
        private readonly IFacebookSuiteService _facebookSuiteService;

        public FacebookSuiteFilter(
            IResourceManager resourceManager, 
            IWorkContextAccessor workContextAccessor,
            IShapeFactory shapeFactory,
            IOrchardServices orchardServices,
            IFacebookSuiteService facebookSuiteService)
        {
            _resourceManager = resourceManager;
            _workContextAccessor = workContextAccessor;
            _shapeFactory = shapeFactory;
            _orchardServices = orchardServices;
            _facebookSuiteService = facebookSuiteService;
        }

        #region IResultFilter Members

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            // Should only run on a full view rendering result
            if (!(filterContext.Result is ViewResult))
                return;

            if (!_facebookSuiteService.AppSettingsSet) return;

            var settings = _facebookSuiteService.FacebookSuiteSettingsPart;

            _resourceManager.Require("script", "FacebookSuite").AtHead(); // As Script.AtHead() is not working in FacebookInit shape

            // Get culture maybe from ICultureManager with GetCurrentCulture()?
            _workContextAccessor.GetContext(filterContext).Layout.Body.Items.Insert( // Include the shape at the beginning of body
                0,
                _shapeFactory.FacebookInit(
                    AppId: settings.AppId,
                    Session: (_facebookSuiteService.FacebookWebContext.Session != null) ? _facebookSuiteService.FacebookWebContext.Session.Data : "",
                    Culture: _orchardServices.WorkContext.CurrentSite.SiteCulture
                    )
                );
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }

        #endregion
    }
}