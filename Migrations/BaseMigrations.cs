using System;
using System.Collections.Generic;
using System.Data;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;

namespace Piedone.Facebook.Suite.Migrations
{
    [OrchardFeature("Piedone.Facebook.Suite")]
    public class BaseMigrations : DataMigrationImpl {

        public int Create() {
			// Creating table FacebookSuiteSettingsPartRecord
			SchemaBuilder.CreateTable("FacebookSuiteSettingsPartRecord", table => table
				.ContentPartRecord()
				.Column("AppId", DbType.String)
				.Column("AppSecret", DbType.String)
				.Column("CancelUrlPath", DbType.String)
				.Column("CanvasPage", DbType.String)
				.Column("CanvasUrl", DbType.String)
				.Column("SecureCanvasUrl", DbType.String)
				.Column("SiteUrl", DbType.String)
				.Column("UseFacebookBeta", DbType.Boolean)
			);



            return 1;
        }
    }
}