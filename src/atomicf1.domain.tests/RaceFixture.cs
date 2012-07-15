using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using atomicf1.common;

namespace atomicf1.domain.Tests
{
    [TestFixture]
    public class RaceFixture
    {
        private IPointsSystem _pointsSystem;
        
        [SetUp]
        public void SetUp()
        {            
            _pointsSystem = MockRepository.GenerateMock<IPointsSystem>();
            CacheHelper.InvalidateAll();
        }

        [Test]
        public void Race_results_order_correctly()
        {
            // Arrange
            var entry1 = new RaceEntry(_pointsSystem) { Entrant = FakesFactory.DriverContract(FakesFactory.Driver("Driver 1")), QualifyingTime = 10.001M, RacePlace = 2 };
            var entry2 = new RaceEntry(_pointsSystem) { Entrant = FakesFactory.DriverContract(FakesFactory.Driver("Driver 2")), QualifyingTime = 10.034M, RacePlace = 4 };
            var entry3 = new RaceEntry(_pointsSystem) { Entrant = FakesFactory.DriverContract(FakesFactory.Driver("Driver 3")), QualifyingTime = 9.889M, RacePlace = 1 };
            var entry4 = new RaceEntry(_pointsSystem) { Entrant = FakesFactory.DriverContract(FakesFactory.Driver("Driver 4")), QualifyingTime = 11.322M, RacePlace = 5 };
            var entry5 = new RaceEntry(_pointsSystem) { Entrant = FakesFactory.DriverContract(FakesFactory.Driver("Driver 5")), QualifyingTime = 10.002M, RacePlace = 3 };

            var entries = new List<RaceEntry> {entry1, entry2, entry3, entry4, entry5};
            var race = FakesFactory.Race(entries);

            // Act
            var results = race.GetRaceResults().ToList();

            // Assert
            Assert.AreEqual("Driver 3", results.Take(1).Single().Entrant.Driver.Name);
            Assert.AreEqual(1, results[0].Position);
            Assert.AreEqual("Driver 1", results.Skip(1).Take(1).Single().Entrant.Driver.Name);
            Assert.AreEqual(2, results[1].Position);
            Assert.AreEqual("Driver 5", results.Skip(2).Take(1).Single().Entrant.Driver.Name);
            Assert.AreEqual(3, results[2].Position);
            Assert.AreEqual("Driver 2", results.Skip(3).Take(1).Single().Entrant.Driver.Name);
            Assert.AreEqual(4, results[3].Position);
            Assert.AreEqual("Driver 4", results.Skip(4).Take(1).Single().Entrant.Driver.Name);
            Assert.AreEqual(5, results[4].Position);
        }

        [Test]
        public void Qualifying_results_order_correctly()
        {
            // Arrange
            var entry1 = new RaceEntry(_pointsSystem) { Entrant = FakesFactory.DriverContract(FakesFactory.Driver("Driver 1")), QualifyingPosition = 2, IsDisqualified = false };
            var entry2 = new RaceEntry(_pointsSystem) { Entrant = FakesFactory.DriverContract(FakesFactory.Driver("Driver 2")), QualifyingPosition = 4, IsDisqualified = false };
            var entry3 = new RaceEntry(_pointsSystem) { Entrant = FakesFactory.DriverContract(FakesFactory.Driver("Driver 3")), QualifyingPosition = 1, IsDisqualified = false };
            var entry4 = new RaceEntry(_pointsSystem) { Entrant = FakesFactory.DriverContract(FakesFactory.Driver("Driver 4")), QualifyingPosition = 5, IsDisqualified = false };
            var entry5 = new RaceEntry(_pointsSystem) { Entrant = FakesFactory.DriverContract(FakesFactory.Driver("Driver 5")), QualifyingPosition = 3, IsDisqualified = false };

            var entries = new List<RaceEntry> { entry1, entry2, entry3, entry4, entry5 };
            var race = FakesFactory.Race(entries);

            // Act
            var results = race.GetQualificationResults().ToList();

            // Assert
            Assert.AreEqual("Driver 3", results[0].Driver.Name);
            Assert.AreEqual(1, results[0].Position);
            Assert.AreEqual("Driver 1", results[1].Driver.Name);
            Assert.AreEqual(2, results[1].Position);
            Assert.AreEqual("Driver 5", results[2].Driver.Name);
            Assert.AreEqual(3, results[2].Position);
            Assert.AreEqual("Driver 2", results[3].Driver.Name);
            Assert.AreEqual(4, results[3].Position);
            Assert.AreEqual("Driver 4", results[4].Driver.Name);
            Assert.AreEqual(5, results[4].Position);
        }
       
        [Test]
        public void No_race_place_sets_driver_as_DNF_and_last_and_no_points()
        {
            // Arrange
            var entry1 = new RaceEntry(_pointsSystem) { Entrant = FakesFactory.DriverContract(FakesFactory.Driver("Driver 1")), QualifyingTime = 10.001M, RacePlace = 2 };
            var entry2 = new RaceEntry(_pointsSystem) { Entrant = FakesFactory.DriverContract(FakesFactory.Driver("Driver 2")), QualifyingTime = 10.034M, RacePlace = 4 };
            var entry3 = new RaceEntry(_pointsSystem) { Entrant = FakesFactory.DriverContract(FakesFactory.Driver("Driver 3")), QualifyingTime = 9.889M, RacePlace = 1};
            var entry4 = new RaceEntry(_pointsSystem) { Entrant = FakesFactory.DriverContract(FakesFactory.Driver("Driver 4")), QualifyingTime = 8.322M };
            var entry5 = new RaceEntry(_pointsSystem) { Entrant = FakesFactory.DriverContract(FakesFactory.Driver("Driver 5")), QualifyingTime = 10.002M, RacePlace = 3 };

            var entries = new List<RaceEntry> { entry1, entry2, entry3, entry4, entry5 };
            var race = FakesFactory.Race(entries);

            // Act
            var results = race.GetRaceResults().ToList();
            var driver = results.Last();
            Assert.AreEqual("Driver 4", driver.Entrant.Driver.Name);
            Assert.AreEqual(5, driver.Position);
            Assert.AreEqual(0, driver.Points);
            Assert.IsFalse(driver.HasFinished);
        }       
    }
}
