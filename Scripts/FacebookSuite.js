(function ($) {
    $.extend({
        facebookSuite: {
            initialize: function (appId, session, culture) {
                window.fbAsyncInit = function () {
                    FB.init({
                        appId: appId,
                        session: session,
                        status: true, // check login status
                        cookie: true, // enable cookies to allow the server to access the session
                        xfbml: true, // parse XFBML
                        oauth: true // enable OAuth 2.0
                    });
                };

                culture = culture.replace("-", "_"); // Handle incompatibility between Orchard and FB culture format

                (function (d) {
                    var js, id = "facebook-jssdk"; if (d.getElementById(id)) { return; }
                    js = d.createElement("script"); js.id = id; js.async = true;
                    js.src = "//connect.facebook.net/" + culture + "/all.js#xfbml=1";
                    d.getElementsByTagName("head")[0].appendChild(js);
                } (document));

                
//                var e = document.createElement("script");
//                e.async = true;
//                e.src = document.location.protocol + "//connect.facebook.net/" + culture + "/all.js";
//                document.getElementById("fb-root").appendChild(e);
            }
        }
    });
})(jQuery);