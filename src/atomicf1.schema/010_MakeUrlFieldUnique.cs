using Migrator.Framework;

namespace atomicf1.schema
{
    [Migration(10)]
    public class _010_MakeUrlFieldUnique : Migration
    {
        private readonly string[] _tables = new[] {"Driver", "Team", "Circuit", "Season"};

        public override void Down()
        {
            foreach (string table in _tables)
                Database.RemoveConstraint(table, string.Format("UX_{0}_Url", table));
        }

        public override void Up()
        {
            foreach (string table in _tables)
                Database.AddUniqueConstraint(string.Format("UX_{0}_Url", table), table, "Url");
        }
    }
}