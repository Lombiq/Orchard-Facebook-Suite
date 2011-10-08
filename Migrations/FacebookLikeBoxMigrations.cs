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
    [OrchardFeature("Piedone.Facebook.Suite.LikeBox")]
    public class FacebookLikeBoxMigrations : DataMigrationImpl
    {
        public int Create()
        {
            // Creating table FacebookLikeBoxPartRecord
            SchemaBuilder.CreateTable("FacebookLikeBoxPartRecord", table => table
                .ContentPartRecord()
                .Column<string>("PageUrl")
                .Column<int>("Width")
                .Column<string>("ColorScheme")
                .Column<bool>("ShowFaces")
                .Column<string>("BorderColor")
                .Column<bool>("ShowStream")
                .Column<bool>("ShowHeader")
            );

            ContentDefinitionManager.AlterPartDefinition(typeof(FacebookLikeBoxPart).Name,
                builder => builder.Attachable());

            ContentDefinitionManager.AlterTypeDefinition("FacebookLikeBoxWidget", cfg => cfg
                .WithPart("FacebookLikeBoxPart")
                .WithPart("WidgetPart")
                .WithPart("CommonPart")
                .WithSetting("Stereotype", "Widget"));


            return 1;
        }
    }
}