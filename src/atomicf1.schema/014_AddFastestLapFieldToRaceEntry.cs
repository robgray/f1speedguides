using System.Data;
using Migrator.Framework;

namespace atomicf1.schema
{
    [Migration(14)]
    public class _014_AddFastestLapFieldToRaceEntry : Migration
    {
        public override void Down()
        {
            Database.RemoveColumn("RaceEntry", "FastestLap");
        }

        public override void Up()
        {
            Database.AddColumn("RaceEntry", new Column("FastestLap", DbType.Decimal));
        }
    }
}