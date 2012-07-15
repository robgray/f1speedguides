using System.Data;
using Migrator.Framework;

namespace atomicf1.schema
{
    [Migration(9)]
    public class _009_AddUrlFieldToTables : Migration
    {
        private readonly string[] _tables = new[] {"Driver", "Team", "Circuit", "Season", "Race"};

        public override void Down()
        {
            foreach (string table in _tables)
                Database.RemoveColumn(table, "Url");
        }

        public override void Up()
        {
            var col = new Column("Url", DbType.String, 255, ColumnProperty.Null);

            foreach (string table in _tables)
                Database.AddColumn(table, col);
        }
    }
}