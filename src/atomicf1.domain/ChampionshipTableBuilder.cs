using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public class ChampionshipTableBuilder
    {
        private Season _season;

        public ChampionshipTableBuilder(Season season)
        {
            _season = season;
        }

        public DataTable Build()
        {
            var table = new DataTable();

            BuildColumns(table);

            return table;
        }

        private void BuildColumns(DataTable table)
        {
            table.Columns.Add("Driver", Type.GetType("System.String"));

            int raceNumber = 1;
            foreach(var race in _season.Races) {

                table.Columns.Add(string.Format("Race {0}", raceNumber), Type.GetType("System.String"));

                raceNumber++;
            }
        }
    }
}
