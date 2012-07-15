using System.Data;
using Migrator.Framework;

namespace atomicf1.schema
{
    [Migration(8)]
    public class _008_CreateRaceEntryTable : Migration
    {
        public override void Down()
        {
            Database.RemoveForeignKey("RaceEntry", "FK_RaceEntry_Race");
            Database.RemoveForeignKey("RaceEntry", "FK_RaceEntry_DriverContract");
            Database.RemoveTable("RaceEntry");
        }

        public override void Up()
        {
            Database.AddTable("RaceEntry", new[]
                                               {
                                                   new Column("RaceEntryId", DbType.Int32,
                                                              ColumnProperty.PrimaryKeyWithIdentity),
                                                   new Column("DriverContractId", DbType.Int32,
                                                              ColumnProperty.NotNull | ColumnProperty.Indexed),
                                                   new Column("RaceId", DbType.Int32),
                                                   new Column("QualifyingTime", DbType.Decimal),
                                                   new Column("RaceTime", DbType.Decimal),
                                                   new Column("DidNotStart", DbType.Boolean, ColumnProperty.NotNull),
                                                   new Column("DidNotFinish", DbType.Boolean, ColumnProperty.NotNull),
                                                   new Column("Disqualified", DbType.Boolean, ColumnProperty.NotNull)
                                               });

            Database.AddForeignKey("FK_RaceEntry_Race", "RaceEntry", "RaceId", "Race", "RaceId");
            Database.AddForeignKey("FK_RaceEntry_DriverContract", "RaceEntry", "DriverContractId", "DriverContract",
                                   "DriverContractId");
        }
    }
}