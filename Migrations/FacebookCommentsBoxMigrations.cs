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
            SchemaBuilder.CreateTable(typeof(FacebookCommentsBoxPartRecord).Name, 
                table => table
                    .SocialPluginPartRecord()
                    .Column<int>("NumberOfPosts")
                );

            ContentDefinitionManager.AlterTypeDefinition("FacebookCommentsBoxWidget", 
                cfg => cfg
                    .WithPart(typeof(FacebookCommentsBoxPart).Name)
                    .WithPart("WidgetPart")
                    .WithPart("CommonPart")
                    .WithSetting("Stereotype", "Widget")
                );


            return 2;
        }

        public int UpdateFrom1()
        {
            ContentDefinitionManager.AlterPartDefinition(typeof(FacebookCommentsBoxPart).Name,
                builder => builder.Attachable(false));

            return 2;
        }
    }
}