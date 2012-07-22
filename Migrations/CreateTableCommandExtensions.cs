using Orchard.Data.Migration.Schema;

namespace Piedone.Facebook.Suite.Migrations
{
    public static class CreateTableCommandExtensions
    {
        public static CreateTableCommand SocialPluginPartRecord(this CreateTableCommand table)
        {
            table
                .ContentPartRecord()
                .Column<int>("Width")
                .Column<string>("ColorScheme");

            return table;
        }

        public static CreateTableCommand SocialPluginWithHeightPartRecord(this CreateTableCommand table)
        {
            table
                .SocialPluginPartRecord()
                .Column<int>("Height");

            return table;
        }
    }
}