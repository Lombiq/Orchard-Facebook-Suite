using Orchard.UI.Resources;
using Orchard.Environment.Extensions;

namespace Piedone.Facebook.Suite {
    [OrchardFeature("Piedone.Facebook.Suite")]
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();
            manifest.DefineScript("FacebookSuite").SetUrl("FacebookSuite.js").SetDependencies("jQuery");
            manifest.DefineScript("FacebookConnect").SetUrl("FacebookConnect.js");

            //manifest.DefineStyle("jQueryUI_Orchard").SetUrl("jquery-ui-1.8.11.custom.css").SetVersion("1.8.11");
        }
    }
}
