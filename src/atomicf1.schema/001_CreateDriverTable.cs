using System.Data;
using Migrator.Framework;

namespace atomicf1.schema
{
    [Migration(1)]
    public class _001_CreateDriverTable : Migration
    {
        public override void Down()
        {
            Database.RemoveTable("Driver");
        }

        public override void Up()
        {
            Database.AddTable("Driver", new[]
                                            {
                                                new Column("DriverId", DbType.Int32,
                                                           ColumnProperty.PrimaryKeyWithIdentity),
                                                new Column("Name", DbType.String, 40),
                                                new Column("Nationality", DbType.String, 40),
                                                new Column("ImageUri", DbType.String, 255),
                                                new Column("AtomicName", DbType.String, 50),
                                                new Column("AtomicUserId", DbType.Int32),
                                            });
        }
    }
}