using System.Data;
using Migrator.Framework;

namespace atomicf1.schema
{
    [Migration(7)]
    public class _007_CreateRaceTable : Migration
    {
        public override void Down()
        {
            Database.RemoveTable("Race");
        }

        public override void Up()
        {
            Database.AddTable("Race", new[]
                                          {
                                              new Column("RaceId", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                                              new Column("RaceDate", DbType.DateTime, ColumnProperty.NotNull),
                                              new Column("PercentLength", DbType.Int32, ColumnProperty.NotNull),
                                              new Column("SeasonId", DbType.Int32, ColumnProperty.Indexed),
                                              new Column("CircuitId", DbType.Int32,
                                                         ColumnProperty.NotNull | ColumnProperty.Indexed),
                                          });

            Database.AddForeignKey("FK_Race_Circuit", "Race", "CircuitId", "Circuit", "CircuitId");
            Database.AddForeignKey("FK_Race_Season", "Race", "SeasonId", "Season", "SeasonId");
        }
    }
}