using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Migrations
{
    [OrchardFeature("Piedone.Facebook.Suite.Facepile")]
    public class FacebookFacepileMigrations : DataMigrationImpl
    {
        public int Create()
        {
            // Creating table FacebookFacepilePartRecord
            SchemaBuilder.CreateTable("FacebookFacepilePartRecord", table => table
                .ContentPartRecord()
                .Column<int>("Width")
                .Column<string>("ColorScheme")
                .Column<int>("MaxRows")
                .Column<string>("Size")

            );

            ContentDefinitionManager.AlterPartDefinition(typeof(FacebookFacepilePart).Name,
                builder => builder.Attachable());

            ContentDefinitionManager.AlterTypeDefinition("FacebookFacepileWidget", cfg => cfg
                .WithPart("FacebookFacepilePart")
                .WithPart("WidgetPart")
                .WithPart("CommonPart")
                .WithSetting("Stereotype", "Widget"));


            return 1;
        }
    }
}