using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using atomicf1.common;

namespace atomicf1.domain.Tests
{
    [TestFixture]
    public class RaceEntryFixture 
    {
        private IPointsSystem _pointsSystem;
        
        [SetUp]
        public void SetUp()
        {            
            _pointsSystem = MockRepository.GenerateMock<IPointsSystem>();
            CacheHelper.InvalidateAll();
        }

        [Test]
        public void QualifyLap_is_pole_lap_when_no_other_competitors()
        {
            var entry = new RaceEntry(_pointsSystem) { Entrant = FakesFactory.DriverContract(), QualifyingTime = 73.123M};
            var race = FakesFactory.Race(new List<RaceEntry>{ entry });

            var position = entry.QualifyingPosition;

            Assert.AreEqual(1, position);
        }

        [Test]
        public void RacePlace_is_win_when_no_other_competitors()
        {                        
            var entry = new RaceEntry(_pointsSystem) { Entrant = FakesFactory.DriverContract(), QualifyingTime = 22.223M, RacePlace = 1 };
            var race = FakesFactory.Race(new List<RaceEntry> {entry});

            var position = entry.RacePlace;

            Assert.AreEqual(1, position);
        }

        [Test]
        public void Faster_of_two_qualifying_laps_is_pole_lap()
        {
            var entry1 = new RaceEntry(_pointsSystem) { Entrant = FakesFactory.DriverContract(), QualifyingTime = 73.332M };
            var entry2 = new RaceEntry(_pointsSystem) { Entrant = FakesFactory.DriverContract(), QualifyingTime = 73.123M };

            var entries = new List<RaceEntry> {entry1, entry2};
            var race = FakesFactory.Race(entries);

            Assert.AreEqual(2, race.Entries.Count(), "Entry Count");
            Assert.AreEqual(2, entry1.QualifyingPosition, "Slower QP");
            Assert.AreEqual(1, entry2.QualifyingPosition, "Faster QP");
        }

        [Test]
        public void Faster_of_two_race_times_is_winner()
        {
            var entry1 = new RaceEntry(_pointsSystem) { Entrant = FakesFactory.DriverContract(), QualifyingTime = 23.232M, RacePlace = 2 };
            var entry2 = new RaceEntry(_pointsSystem) { Entrant = FakesFactory.DriverContract(), QualifyingTime = 11.232M, RacePlace = 1 };

            var entries = new List<RaceEntry> { entry1, entry2 };
            var race = FakesFactory.Race(entries);

            Assert.AreEqual(2, race.Entries.Count(), "Entry Count");
            Assert.AreEqual(2, entry1.RacePlace, "Second Place");
            Assert.AreEqual(1, entry2.RacePlace, "Winner");
        }

        [Test]
        public void Cannot_be_classified_as_finisher_with_no_qualifying_time()
        {
            var entry = new RaceEntry(_pointsSystem) { Entrant = FakesFactory.DriverContract(), QualifyingTime = 0, RacePlace = 1 };

            Assert.IsFalse(entry.HasFinished);
        }

        [Test]
        public void Entry_receives_points()
        {
            _pointsSystem.Stub(s => s.CalculatePoints(Arg<RaceEntry>.Is.Anything)).Return(10M);

            var entry = FakesFactory.RaceEntry(_pointsSystem);

            Assert.AreEqual(10, entry.Points);
        }
    }
}
