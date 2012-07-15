using System.Data;
using Migrator.Framework;

namespace atomicf1.schema
{
    [Migration(3)]
    public class _003_CreateTeamTable : Migration
    {
        public override void Down()
        {
            Database.RemoveTable("Team");
        }

        public override void Up()
        {
            Database.AddTable("Team", new[]
                                          {
                                              new Column("TeamId", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                                              new Column("Name", DbType.String, 50,
                                                         ColumnProperty.Unique | ColumnProperty.Indexed)
                                          });

            var teamNames = new[]
                                {
                                    "McLaren", "Red Bull", "Ferrari", "Mercedes GP", "Renault", "Williams",
                                    "Force India", "Toro Rosso", "Lotus", "Sauber", "HRT", "Virgin"
                                };

            foreach (string team in teamNames)
            {
                Database.Insert("Team", new[] {"Name"}, new[] {team});
            }
        }
    }
}