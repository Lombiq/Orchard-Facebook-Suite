using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Migrations
{
    [OrchardFeature("Piedone.Facebook.Suite.LikeBox")]
    public class FacebookLikeBoxMigrations : DataMigrationImpl
    {
        public int Create()
        {
            // Creating table FacebookLikeBoxPartRecord
            SchemaBuilder.CreateTable(typeof(FacebookLikeBoxPartRecord).Name, 
                table => table
                    .SocialPluginWithHeightPartRecord()
                    .Column<string>("PageUrl")
                    .Column<bool>("ShowFaces")
                    .Column<string>("BorderColor")
                    .Column<bool>("ShowStream")
                    .Column<bool>("ShowHeader")
                );

            ContentDefinitionManager.AlterTypeDefinition("FacebookLikeBoxWidget", 
                cfg => cfg
                    .WithPart(typeof(FacebookLikeBoxPart).Name)
                    .WithPart("WidgetPart")
                    .WithPart("CommonPart")
                    .WithSetting("Stereotype", "Widget")
                );


            return 3;
        }

        public int UpdateFrom1()
        {
            SchemaBuilder.AlterTable(typeof(FacebookLikeBoxPartRecord).Name,
                table => table
                    .AddColumn<int>("Height"));

            return 2;
        }

        public int UpdateFrom2()
        {
            ContentDefinitionManager.AlterPartDefinition(typeof(FacebookLikeBoxPart).Name,
                builder => builder.Attachable(false));

            return 3;
        }
    }
}