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
    [OrchardFeature("Piedone.Facebook.Suite.Connect")]
    public class FacebookConnectMigrations : DataMigrationImpl {

        public int Create() {
			// Creating table FacebookConnectPartRecord
			SchemaBuilder.CreateTable("FacebookConnectPartRecord", table => table
				.ContentPartRecord()
				.Column("Permissions", DbType.String)
                .Column("AutoLogin", DbType.Boolean)
                .Column("OnlyAllowVerified", DbType.Boolean)
			);

            ContentDefinitionManager.AlterTypeDefinition("FacebookConnectWidget", cfg => cfg
                .WithPart("FacebookConnectPart")
                .WithPart("WidgetPart")
                .WithPart("CommonPart")
                .WithSetting("Stereotype", "Widget"));

            // Creating table FacebookUserPartRecord
            SchemaBuilder.CreateTable("FacebookUserPartRecord", table => table
                .ContentPartRecord()
                //.Column("UserId", DbType.Int32)
                .Column("FacebookUserId", DbType.Int64)
                .Column("Name", DbType.String)
                .Column("FirstName", DbType.String)
                .Column("LastName", DbType.String)
                .Column("Link", DbType.String)
                .Column("FacebookUserName", DbType.String)
                .Column("Gender", DbType.String)
                .Column("TimeZone", DbType.Int32)
                .Column("Locale", DbType.String)
                .Column("IsVerified", DbType.Boolean)
            );

            //ContentDefinitionManager.AlterTypeDefinition("User",
            //    cfg => cfg
            //        .WithPart(typeof(FacebookUserPart).Name)
            //    );

            //ContentDefinitionManager.AlterTypeDefinition("FacebookUser",
            //   cfg => cfg
            //       .WithPart(typeof(FacebookUserPart).Name)
            //    );


            return 1;
        }
    }
}