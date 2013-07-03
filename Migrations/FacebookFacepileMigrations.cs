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
            SchemaBuilder.CreateTable(typeof(FacebookFacepilePartRecord).Name, 
                table => table
                    .SocialPluginPartRecord()
                    .Column<int>("MaxRows")
                    .Column<string>("Size")
                );

            ContentDefinitionManager.AlterTypeDefinition("FacebookFacepileWidget", 
                cfg => cfg
                    .WithPart(typeof(FacebookFacepilePart).Name)
                    .WithPart("WidgetPart")
                    .WithPart("CommonPart")
                    .WithSetting("Stereotype", "Widget")
                );


            return 2;
        }

        public int UpdateFrom1()
        {
            ContentDefinitionManager.AlterPartDefinition(typeof(FacebookFacepilePart).Name,
                builder => builder.Attachable(false));

            return 2;
        }
    }
}