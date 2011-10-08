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
                .Column<string>("AppId")
                .Column<string>("AppSecret")
                .Column<string>("CancelUrlPath")
                .Column<string>("CanvasPage")
                .Column<string>("CanvasUrl")
                .Column<string>("SecureCanvasUrl")
                .Column<string>("SiteUrl")
				.Column<bool>("UseFacebookBeta")
			);



            return 1;
        }
    }
}