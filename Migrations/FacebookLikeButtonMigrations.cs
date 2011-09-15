using System;
using System.Collections.Generic;
using System.Data;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
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
            SchemaBuilder.CreateTable("FacebookLikeButtonPartRecord", table => table
                .ContentPartRecord()
                .Column("EnableSendButton", DbType.Boolean)
                .Column("LayoutStyle", DbType.String)
                .Column("Width", DbType.Int32)
                .Column("ShowFaces", DbType.Boolean)
                .Column("VerbToDisplay", DbType.String)
                .Column("ColorScheme", DbType.String)
                .Column("Font", DbType.String)
            );


            ContentDefinitionManager.AlterPartDefinition(typeof(FacebookLikeButtonPart).Name,
                builder => builder.Attachable());

            ContentDefinitionManager.AlterTypeDefinition("FacebookLikeButtonWidget", cfg => cfg
                .WithPart("FacebookLikeButtonPart")
                .WithPart("WidgetPart")
                .WithPart("CommonPart")
                .WithSetting("Stereotype", "Widget"));


            return 1;
        }
    }
}