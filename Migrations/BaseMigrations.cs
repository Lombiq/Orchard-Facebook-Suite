using Orchard.Data.Migration;
using Orchard.Environment.Extensions;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Migrations
{
    [OrchardFeature("Piedone.Facebook.Suite")]
    public class BaseMigrations : DataMigrationImpl {

        public int Create() {
			// Creating table FacebookSuiteSettingsPartRecord
			SchemaBuilder.CreateTable(typeof(FacebookSuiteSettingsPartRecord).Name, 
                table => table
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