using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Migrations
{
    [OrchardFeature("Piedone.Facebook.Suite.CommentsBox")]
    public class FacebookCommentsBoxMigrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable(typeof(FacebookCommentsBoxWidgetPartRecord).Name, 
                table => table
                    .ContentPartRecord()
                    .Column<int>("NumberOfPosts")
                    .Column<int>("Width")
                    .Column<string>("ColorScheme")
            );

            ContentDefinitionManager.AlterTypeDefinition("FacebookCommentsBoxWidget", 
                cfg => cfg
                    .WithPart(typeof(FacebookCommentsBoxWidgetPart).Name)
                    .WithPart("WidgetPart")
                    .WithPart("CommonPart")
                    .WithSetting("Stereotype", "Widget")
            );

            ContentDefinitionManager.AlterPartDefinition(typeof(FacebookCommentsBoxPart).Name,
                builder => builder.Attachable());


            return 1;
        }

        public int UpdateFrom1()
        {
            ContentDefinitionManager.DeletePartDefinition("FacebookCommentsBoxPart");

            SchemaBuilder.DropTable("FacebookCommentsBoxPartRecord");

            SchemaBuilder.CreateTable(typeof(FacebookCommentsBoxWidgetPartRecord).Name,
                table => table
                    .ContentPartRecord()
                    .Column<int>("NumberOfPosts")
                    .Column<int>("Width")
                    .Column<string>("ColorScheme")
            );

            // Hidden?
            //ContentDefinitionManager.AlterPartDefinition(typeof(FacebookCommentsBoxWidgetPart).Name,
            //    builder => builder.Attachable(false));

            ContentDefinitionManager.AlterPartDefinition(typeof(FacebookCommentsBoxPart).Name,
                builder => builder.Attachable());

            return 2;
        }
    }
}