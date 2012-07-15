using System.Data;
using Migrator.Framework;

namespace atomicf1.schema
{
    [Migration(15)]
    public class _015_AddGridPenaltyFieldToRaceEntry : Migration
    {
        public override void Down()
        {
            Database.RemoveColumn("RaceEntry", "GridPenalty");
        }

        public override void Up()
        {
            Database.AddColumn("RaceEntry", new Column("GridPenalty", DbType.Int32));            
        }
    }
}