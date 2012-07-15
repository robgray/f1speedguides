using System.Data;
using Migrator.Framework;

namespace atomicf1.schema
{
    [Migration(4)]
    public class _004_CreateDriverContractTable : Migration
    {
        public override void Down()
        {
            Database.RemoveForeignKey("DriverContract", "FK_DriverContract_Team");
            Database.RemoveForeignKey("DriverContract", "FK_DriverContract_Driver");
            Database.RemoveForeignKey("DriverContract", "FK_DriverContract_Season");
            Database.RemoveTable("DriverContract");
        }

        public override void Up()
        {
            Database.AddTable("DriverContract", new[]
                                                    {
                                                        new Column("DriverContractId", DbType.Int32,
                                                                   ColumnProperty.PrimaryKeyWithIdentity),
                                                        new Column("DateCommenced", DbType.DateTime, ColumnProperty.Null)
                                                        ,
                                                        new Column("DateTerminated", DbType.DateTime,
                                                                   ColumnProperty.Null),
                                                        new Column("SeasonId", DbType.Int32, ColumnProperty.NotNull),
                                                        new Column("TeamId", DbType.Int32,
                                                                   ColumnProperty.NotNull | ColumnProperty.ForeignKey |
                                                                   ColumnProperty.Indexed),
                                                        new Column("DriverId", DbType.Int32,
                                                                   ColumnProperty.NotNull | ColumnProperty.ForeignKey |
                                                                   ColumnProperty.Indexed)
                                                    });

            Database.AddForeignKey("FK_DriverContract_Team", "DriverContract", "TeamId", "Team", "TeamId");
            Database.AddForeignKey("FK_DriverContract_Driver", "DriverContract", "DriverId", "Driver", "DriverId");
        }
    }
}