using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Migrations
{
    [OrchardFeature("Piedone.Facebook.Suite.LikeButton")]
    public class FacebookLikeButtonMigrations : DataMigrationImpl
    {
        public int Create()
        {
            // Creating table FacebookLikeButtonPartRecord
            SchemaBuilder.CreateTable(typeof(FacebookLikeButtonPartRecord).Name, 
                table => table
                    .ContentPartRecord()
                    .Column<bool>("EnableSendButton")
                    .Column<string>("LayoutStyle")
                    .Column<int>("Width")
                    .Column<bool>("ShowFaces")
                    .Column<string>("VerbToDisplay")
                    .Column<string>("ColorScheme")
                    .Column<string>("Font")
            );

            ContentDefinitionManager.AlterTypeDefinition("FacebookLikeButtonWidget", 
                cfg => cfg
                    .WithPart(typeof(FacebookLikeButtonPart).Name)
                    .WithPart("WidgetPart")
                    .WithPart("CommonPart")
                    .WithSetting("Stereotype", "Widget")
            );


            return 2;
        }

        public int UpdateFrom1()
        {
            ContentDefinitionManager.AlterPartDefinition(typeof(FacebookLikeButtonPart).Name,
                builder => builder.Attachable(false));

            return 2;
        }
    }
}