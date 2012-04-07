(function ($) {
    $.extend({
        facebookSuite: {
            initialize: function (appId, culture) {
                // If events should be subscribed, see this: http://stackoverflow.com/questions/9219785/multiple-fbasyncinits
                // For "extending" the fbAsyncInit callback.
                window.fbAsyncInit = function () {
                    FB.init({
                        appId: appId,
                        status: true, // check login status
                        cookie: true, // enable cookies to allow the server to access the session
                        xfbml: true, // parse XFBML
                        oauth: true // enable OAuth 2.0
                    });

                    // Trick taken from http://pivotallabs.com/users/jdean/blog/articles/1400-working-with-asynchronously-loaded-javascript
                    $(document).trigger("facebook:ready");
                };

                culture = culture.replace("-", "_"); // Handle incompatibility between Orchard and FB culture format

                (function (d) {
                    var js, id = "facebook-jssdk"; if (d.getElementById(id)) { return; }
                    js = d.createElement("script"); js.id = id; js.async = true;
                    js.src = "//connect.facebook.net/" + culture + "/all.js#xfbml=1";
                    d.getElementsByTagName("head")[0].appendChild(js);
                } (document));
            }
        }
    });
})(jQuery);