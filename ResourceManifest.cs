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
            manifest.DefineScript("FacebookSuite").SetUrl("FacebookSuite.js").SetDependencies("jQuery");
            manifest.DefineScript("FacebookConnect").SetUrl("FacebookConnect.js");
            manifest.DefineStyle("FacebookConnect").SetUrl("FacebookConnect.css");
        }
    }
}
