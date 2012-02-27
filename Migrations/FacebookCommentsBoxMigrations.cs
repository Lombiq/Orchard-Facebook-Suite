using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;
using Piedone.Facebook.Suite.Models;
using Orchard.Data;
using Orchard.Core.Settings.Metadata.Records;
using System.Linq;
using Orchard.ContentManagement;

namespace Piedone.Facebook.Suite.Migrations
{
    [OrchardFeature("Piedone.Facebook.Suite.CommentsBox")]
    public class FacebookCommentsBoxMigrations : DataMigrationImpl
    {
        private readonly IRepository<ContentPartDefinitionRecord> _partDefinitionRepository;
        private readonly IContentManager _contentManager;

        public FacebookCommentsBoxMigrations(
            IRepository<ContentPartDefinitionRecord> partDefinitionRepository,
            IContentManager contentManager)
        {
            _partDefinitionRepository = partDefinitionRepository;
            _contentManager = contentManager;
        }

        public int Create()
        {
            this.CreateSocialPluginWidget<FacebookCommentsBoxPart, FacebookCommentsBoxPartRecord, FacebookCommentsBoxWidgetPart>("FacebookCommentsBoxWidget");

            SchemaBuilder.CreateTable(typeof(FacebookCommentsBoxWidgetPartRecord).Name, 
                table => table
                    .ContentPartRecord()
                    .Column<int>("NumberOfPosts")
                    .Column<int>("Width")
                    .Column<string>("ColorScheme")
            );


            //var partDefinition = _partDefinitionRepository.Fetch(p => p.Name == "FacebookCommentsBoxWidgetPart").FirstOrDefault();
            //partDefinition.Hidden = true;


            return 2;
        }

        public int UpdateFrom1()
        {
            ContentDefinitionManager.AlterPartDefinition("FacebookCommentsBoxPart",
                builder =>
                {
                    builder.Named("FacebookCommentsBoxWidgetPart");
                    builder.Attachable(false);
                });
            _contentManager.Flush(); // Otherwise the rename would not happen before the next line

            //var partDefinition = _partDefinitionRepository.Fetch(p => p.Name == "FacebookCommentsBoxWidgetPart").FirstOrDefault();
            //partDefinition.Hidden = true;

            // This is ugly but will work most of the time. If someone uses something other than SQL Server, the tables should be manually renamed
            SchemaBuilder.ExecuteSql("EXEC sp_rename 'Piedone_Facebook_Suite_FacebookCommentsBoxPartRecord', 'Piedone_Facebook_Suite_FacebookCommentsBoxWidgetPartRecord'");

            SchemaBuilder.CreateTable(typeof(FacebookCommentsBoxPartRecord).Name,
                table => table
                    .SocialPluginPartRecord()
            );

            ContentDefinitionManager.AlterPartDefinition(typeof(FacebookCommentsBoxPart).Name,
                builder => builder.Attachable());


            return 2;
        }

        //public int UpdateFrom2()
        //{


        //    return 3;
        //}
    }
}