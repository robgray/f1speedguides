using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace atomicf1.domain.Tests
{
    [TestFixture]
    public class SeasonFixture
    {
        [Test] 
        public void Can_create_entry_for_season()
        {
            var team = FakesFactory.Team();
            var driver = FakesFactory.Driver();
            var season = FakesFactory.Season();

            var contract = season.RegisterForCompetition(driver, team);

            Assert.AreEqual(1, season.Entrants.Count());
            Assert.AreEqual(contract.Driver, driver);
            Assert.AreEqual(contract.Team, team);
            Assert.AreEqual(contract.Season, season);
        }

        [Test]
        public void GetDriverStandings_puts_driver_with_most_wins_ahead_when_points_are_equal()
        {
            var season = FakesFactory.Season();            
        }
    }
}
