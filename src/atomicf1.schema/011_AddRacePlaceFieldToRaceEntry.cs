using System.Data;
using Migrator.Framework;

namespace atomicf1.schema
{
    [Migration(11)]
    public class _011_AddRacePlaceFieldToRaceEntry : Migration
    {
        public override void Down()
        {
            Database.RemoveColumn("RaceEntry", "RacePlace");
        }

        public override void Up()
        {
            Database.AddColumn("RaceEntry", "RacePlace", DbType.Int32);
            Database.ExecuteNonQuery("UPDATE RaceEntry SET RacePlace=RaceTime");
        }
    }
}