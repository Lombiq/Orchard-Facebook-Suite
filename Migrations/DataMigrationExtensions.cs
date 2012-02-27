using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Environment.Extensions;
using Orchard.Data.Migration;
using Orchard.Data.Migration.Schema;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;

namespace Piedone.Facebook.Suite.Migrations
{
    [OrchardFeature("Piedone.Facebook.Suite")]
    public static class DataMigrationExtensions
    {
        public static void CreateSocialPluginWidget<TPart, TPartRecord, TWidgetPart>(this DataMigrationImpl migration, string widgetTypeName)
        {
            migration.ContentDefinitionManager.AlterPartDefinition(typeof(TPart).Name,
                builder => builder.Attachable());

            migration.SchemaBuilder.CreateTable(typeof(TPartRecord).Name,
                table => table
                    .SocialPluginPartRecord()
            );

            migration.ContentDefinitionManager.AlterTypeDefinition(widgetTypeName,
                cfg => cfg
                    .WithPart(typeof(TWidgetPart).Name)
                    .WithPart("WidgetPart")
                    .WithPart("CommonPart")
                    .WithSetting("Stereotype", "Widget")
            );
        }

        public static CreateTableCommand SocialPluginPartRecord(this CreateTableCommand table)
        {
            table
                .ContentPartRecord()
                .Column<bool>("Enabled", column => column.NotNull());


            return table;
        }
    }
}