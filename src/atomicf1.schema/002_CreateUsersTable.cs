using System.Data;
using Migrator.Framework;

namespace atomicf1.schema
{
    [Migration(2)]
    public class _002_CreateUsersTable : Migration
    {
        public override void Down()
        {
            Database.RemoveForeignKey("Users", "FK_Users_Drivers");
            Database.RemoveTable("Users");
        }

        public override void Up()
        {
            Database.AddTable("Users", new[]
                                           {
                                               new Column("UserId", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity)
                                               ,
                                               new Column("DriverId", DbType.Int32,
                                                          ColumnProperty.Unique | ColumnProperty.Indexed |
                                                          ColumnProperty.NotNull),
                                               new Column("Username", DbType.String, 30,
                                                          ColumnProperty.Unique | ColumnProperty.Indexed |
                                                          ColumnProperty.NotNull),
                                               new Column("Password", DbType.String, 50, ColumnProperty.NotNull),
                                               new Column("EmailAddress", DbType.String, 255, ColumnProperty.NotNull),
                                               new Column("IsLocked", DbType.Boolean, ColumnProperty.NotNull, false),
                                               new Column("DateJoined", DbType.DateTime, ColumnProperty.NotNull),
                                           });

            Database.AddForeignKey("FK_Users_Drivers", "Users", "DriverId", "Driver", "DriverId");
        }
    }
}