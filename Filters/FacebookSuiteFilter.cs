using System.Web.Mvc;
using Orchard;
using Orchard.DisplayManagement;
using Orchard.Environment.Extensions;
using Orchard.Mvc.Filters;
using Orchard.UI.Resources;
using Piedone.Facebook.Suite.Services;

namespace Piedone.Facebook.Suite.Filters
{
    [OrchardFeature("Piedone.Facebook.Suite")]
    public class FacebookSuiteFilter : FilterProvider, IResultFilter
    {
        private readonly IResourceManager _resourceManager;
        private readonly IWorkContextAccessor _workContextAccessor;
        private readonly dynamic _shapeFactory;
        private readonly IFacebookSuiteService _facebookSuiteService;

        public FacebookSuiteFilter(
            IResourceManager resourceManager, 
            IWorkContextAccessor workContextAccessor,
            IShapeFactory shapeFactory,
            IFacebookSuiteService facebookSuiteService)
        {
            _resourceManager = resourceManager;
            _workContextAccessor = workContextAccessor;
            _shapeFactory = shapeFactory;
            _facebookSuiteService = facebookSuiteService;
        }

        #region IResultFilter Members

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            // Should only run on a full view rendering result
            if (!(filterContext.Result is ViewResult)) return;

            // Don't run if we're on the admin
            if (Orchard.UI.Admin.AdminFilter.IsApplied(filterContext.RequestContext)) return;

            _resourceManager.Require("script", "FacebookSuite").AtFoot();

            _workContextAccessor.GetContext(filterContext).Layout.Body.Items.Insert( // Include the shape at the beginning of body
                0,
                _shapeFactory.FacebookInit(
                    AppId: _facebookSuiteService.SettingsPart.AppId,
                    Culture: _workContextAccessor.GetContext(filterContext).CurrentCulture
                    )
                );
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }

        #endregion
    }
}