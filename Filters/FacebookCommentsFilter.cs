using System.Web;
using System.Web.Mvc;
using Orchard.Environment.Extensions;
using Orchard.Mvc.Filters;

namespace Piedone.Facebook.Suite.Filters
{
    [OrchardFeature("Piedone.Facebook.Suite.CommentsBox")]
    public class FacebookCommentsFilter : FilterProvider, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // This strips out the fb_comment_id parameter from the URL and redirects to it.
            // This param is added to the URL of the link on FB on a user's timeline when she/he comments on a page.
            var request = filterContext.HttpContext.Request;

            if (request.QueryString["fb_comment_id"] != null)
            {
                var url = request.Url;
                var queryParams = HttpUtility.ParseQueryString(url.Query);
                if (queryParams["fb_comment_id"] != null)
                {
                    queryParams.Remove("fb_comment_id");
                }
                
                var cleanUrl = url.Scheme + "://" + url.Authority + url.AbsolutePath + ((queryParams.Count != 0) ? "?" + queryParams : "");

                filterContext.Result = new RedirectResult(cleanUrl, true);
            }
        }
    }
}