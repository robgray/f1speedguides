using System.Data;
using Migrator.Framework;

namespace atomicf1.schema
{
    [Migration(6)]
    public class _006_CreateSeasonTable : Migration
    {
        public override void Down()
        {
            Database.RemoveForeignKey("DriverContract", "FK_DriverContract_Season");
            Database.RemoveColumn("DriverContract", "SeasonId");
            Database.RemoveTable("Season");
        }

        public override void Up()
        {
            Database.AddTable("Season", new[]
                                            {
                                                new Column("SeasonId", DbType.Int32,
                                                           ColumnProperty.PrimaryKeyWithIdentity),
                                                new Column("Name", DbType.String, 100, ColumnProperty.None),
                                                new Column("Description", DbType.String, ColumnProperty.None),
                                                new Column("Year", DbType.Int32, ColumnProperty.None),
                                                new Column("IsCurrent", DbType.Boolean, ColumnProperty.None)
                                            });

            Database.AddForeignKey("FK_DriverContract_Season", "DriverContract", "SeasonId", "Season", "SeasonId");
        }
    }
}