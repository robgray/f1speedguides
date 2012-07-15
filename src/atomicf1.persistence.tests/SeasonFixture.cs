using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.domain;
using NUnit.Framework;

namespace atomicf1.persistence.Tests
{
    [TestFixture]
    public class SeasonFixture : InMemoryData
    {
        [Test]
        public void Can_add_season_to_database()
        {
            var season = new Season()
            {
                Name = "Season 1",
                Year = 2010,
                Description = "First Atomic championship"
            };

            Session.Save(season);
            Session.Flush();
            Session.Clear();

            var fromDb = Session.Get<Season>(season.Id);
            Assert.AreNotSame(season, fromDb);
            Assert.AreEqual(season.Name, fromDb.Name);
            Assert.AreEqual(season.Description, fromDb.Description);
            Assert.AreEqual(season.Year, fromDb.Year);
        }
    }
}
