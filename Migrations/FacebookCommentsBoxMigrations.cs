using System;
using System.Collections.Generic;
using System.Data;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Piedone.Facebook.Suite.Models;
using Orchard.Environment.Extensions;

namespace Piedone.Facebook.Suite.Migrations
{
    [OrchardFeature("Piedone.Facebook.Suite.CommentsBox")]
    public class FacebookCommentsBoxMigrations : DataMigrationImpl
    {
        public int Create()
        {
            // Creating table FacebookCommentsBoxPartRecord
            SchemaBuilder.CreateTable("FacebookCommentsBoxPartRecord", table => table
                .ContentPartRecord()
                .Column("NumberOfPosts", DbType.Int32)
                .Column("Width", DbType.Int32)
                .Column("ColorScheme", DbType.String)
            );

            ContentDefinitionManager.AlterPartDefinition(typeof(FacebookCommentsBoxPart).Name,
                builder => builder.Attachable());

            ContentDefinitionManager.AlterTypeDefinition("FacebookCommentsBoxWidget", cfg => cfg
                .WithPart("FacebookCommentsBoxPart")
                .WithPart("WidgetPart")
                .WithPart("CommonPart")
                .WithSetting("Stereotype", "Widget"));


            return 1;
        }
    }
}