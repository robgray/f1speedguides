using System.Data;
using Migrator.Framework;

namespace atomicf1.schema
{
    [Migration(13)]
    public class _013_AddPointsSystemFieldToSeason : Migration
    {
        public override void Down()
        {
            Database.RemoveColumn("Season", "PointsSystemType");
        }

        public override void Up()
        {
            Database.AddColumn("Season", "PointsSystemType", DbType.String, 255);
            Database.ExecuteNonQuery(
                "UPDATE Season SET PointsSystemType='atomicf1.domain.PointsSystem2010, atomicf1.domain'");
        }
    }
}