using System.Data;
using Migrator.Framework;

namespace atomicf1.schema
{
    [Migration(5)]
    public class _005_CreateCircuitTable : Migration
    {
        public override void Down()
        {
            Database.RemoveTable("Circuit");
        }

        public override void Up()
        {
            Database.AddTable("Circuit", new[]
                                             {
                                                 new Column("CircuitId", DbType.Int32,
                                                            ColumnProperty.PrimaryKeyWithIdentity),
                                                 new Column("Name", DbType.String, 50,
                                                            ColumnProperty.NotNull | ColumnProperty.Unique |
                                                            ColumnProperty.Indexed),
                                                 new Column("Location", DbType.String, 50),
                                                 new Column("Country", DbType.String, 50),
                                                 new Column("CircuitMapUri", DbType.String, 255)
                                             });

            var circuitNames = new[]
                                   {
                                       new[] {"Bahrain", "Sakhir", "Bahrain"},
                                       new[] {"Australian", "Melbourne", "Australia"},
                                       new[] {"Malaysian", "Kuala Lumpur", "Malaysia"},
                                       new[] {"Chinese", "Shanghai", "China"},
                                       new[] {"Spainish", "Catalunya", "Spain"},
                                       new[] {"Monaco", "Monte Carlo", "Monaco"},
                                       new[] {"Turkish", "Istanbul", "Turkey"},
                                       new[] {"Canadian", "Montreal", "Canada"},
                                       new[] {"European", "Valencia", "Spain"},
                                       new[] {"British", "Silverstone", "Britian"},
                                       new[] {"German", "Hockenheim", "Germany"},
                                       new[] {"Hungarian", "Budapest", "Hungary"},
                                       new[] {"Belgian", "Spa-Francorchamps", "Belgium"},
                                       new[] {"Italian", "Monza", "Italy"},
                                       new[] {"Singapore", "Singapore", "Singapore"},
                                       new[] {"Japanese", "Suzuka", "Japan"},
                                       new[] {"Korean", "Yeongam", "Korea"},
                                       new[] {"Brazilian", "Interlagos", "Brazil"},
                                       new[] {"Abu Dhabi", "Yas Marina", "Abu Dhabi"}
                                   };

            foreach (var circuit in circuitNames)
            {
                Database.Insert("Circuit", new[] {"Name", "Location", "Country"}, circuit);
            }
        }
    }
}