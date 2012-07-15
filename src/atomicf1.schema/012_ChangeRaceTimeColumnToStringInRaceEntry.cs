using System;
using System.Data;
using Migrator.Framework;

namespace atomicf1.schema
{
    [Migration(12)]
    public class _012_ChangeRaceTimeColumnToStringInRaceEntry : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Database.RemoveColumn("RaceEntry", "RaceTime");
            Database.AddColumn("RaceEntry", "RaceTime", DbType.String, 10);
        }
    }
}