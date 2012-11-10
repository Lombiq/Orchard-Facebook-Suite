using Orchard.Environment.Extensions;
using Orchard.UI.Resources;

namespace Piedone.Facebook.Suite
{
    [OrchardFeature("Piedone.Facebook.Suite")]
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            var manifest = builder.Add();
            manifest.DefineScript("FacebookSuite").SetUrl("piedone-facebook-suite.js").SetDependencies("jQuery");
        }
    }
}
