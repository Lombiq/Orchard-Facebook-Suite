using Orchard.ContentManagement.MetaData;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;

namespace Piedone.Facebook.Suite.Migrations
{
    [OrchardFeature("Piedone.Facebook.Suite.Connect")]
    public class FacebookConnectMigrations : DataMigrationImpl {

        public int Create() {
			// Creating table FacebookConnectPartRecord
			SchemaBuilder.CreateTable("FacebookConnectPartRecord", table => table
				.ContentPartRecord()
				.Column<string>("Permissions")
                .Column<bool>("AutoLogin")
                .Column<bool>("OnlyAllowVerified")
			);

            ContentDefinitionManager.AlterTypeDefinition("FacebookConnectWidget", cfg => cfg
                .WithPart("FacebookConnectPart")
                .WithPart("WidgetPart")
                .WithPart("CommonPart")
                .WithSetting("Stereotype", "Widget"));

            // Creating table FacebookUserPartRecord
            SchemaBuilder.CreateTable("FacebookUserPartRecord", table => table
                .ContentPartRecord()
                .Column<long>("FacebookUserId")
                .Column<string>("Name")
                .Column<string>("FirstName")
                .Column<string>("LastName")
                .Column<string>("Link")
                .Column<string>("FacebookUserName")
                .Column<string>("Gender")
                .Column<int>("TimeZone")
                .Column<int>("Locale")
                .Column<bool>("IsVerified")
            );


            return 1;
        }

        public int UpdateFrom1()
        {
            SchemaBuilder.AlterTable("FacebookUserPartRecord",
                table => table
                    .CreateIndex("FacebookUser", new string[] { "FacebookUserId" })
                );

            return 2;
        }
    }
}