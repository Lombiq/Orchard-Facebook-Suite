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