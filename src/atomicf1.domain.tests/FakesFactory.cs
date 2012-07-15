using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain.Tests
{
    public static class FakesFactory
    {
        public static Race Race()
        {            
            var circuit = new Circuit { Name = "Test Track" };
            var season = new Season { Year = 2010 };
            var race = new Race()
            {
                Circuit = circuit,
                StartDate = DateTime.Parse("2010-10-22"),
                EndDate = DateTime.Parse("2010-10-24"),
                Season = season
            };

            return race;
        }
        
        public static Race Race(IList<RaceEntry> entries)
        {
            var circuit = new Circuit {Name = "Test Track"};
            var season = new Season {Year = 2010};
            Race race = new RaceProxy(entries)
                            {
                                Circuit = circuit,
                                StartDate = DateTime.Parse("2010-10-22"),
                                EndDate = DateTime.Parse("2010-10-24"),
                                Season = season
                            };

            return race;
        }

        public static Race Race(Season season, IList<RaceEntry> entries)
        {
            var circuit = new Circuit {Name = "Test Track"};            
            Race race = new RaceProxy(entries)
                            {
                                Circuit = circuit,
                                StartDate = DateTime.Parse("2010-10-22"),
                                EndDate = DateTime.Parse("2010-10-24"),
                                Season = season
                            };

            return race;
        }

        public static Team Team(IList<DriverContract> contracts)
        {
            Team team = new TeamProxy(contracts)
                            {
                                Name = "Test Team"
                            };

            return team;
        }

        public static Team Team()
        {
            return new Team() {Name = "Test Team"};
        }

        public static RaceEntry RaceEntry(IPointsSystem pointsSystem)
        {
            return RaceEntry(pointsSystem, false);
        }

        public static RaceEntry RaceEntry(IPointsSystem pointsSystem, bool didNotFinish)
        {
               var entry = new RaceEntry(pointsSystem) { Entrant = FakesFactory.DriverContract(), QualifyingTime = 72.21M, RacePlace = 1, DidNotFinish = didNotFinish };

            var race = FakesFactory.Race(new List<RaceEntry>() {entry});

            return entry;
        }

        public static RaceEntry RaceEntry(IPointsSystem pointsSystem, int racePosition, bool didNotFinish)
        {
            var first = new RaceEntry(pointsSystem) { Entrant = DriverContract(), QualifyingTime = 1M, RacePlace = 1, DidNotFinish = didNotFinish };
            var second = new RaceEntry(pointsSystem) { Entrant = DriverContract(), QualifyingTime = 2M, RacePlace = 2, DidNotFinish = didNotFinish };
            var third = new RaceEntry(pointsSystem) { Entrant = DriverContract(), QualifyingTime = 3M, RacePlace = 3, DidNotFinish = didNotFinish };
            var fourth = new RaceEntry(pointsSystem) { Entrant = DriverContract(), QualifyingTime = 4M, RacePlace = 4, DidNotFinish = didNotFinish };
            var fifth = new RaceEntry(pointsSystem) { Entrant = DriverContract(), QualifyingTime = 5M, RacePlace = 5, DidNotFinish = didNotFinish };
            var sixth = new RaceEntry(pointsSystem) { Entrant = DriverContract(), QualifyingTime = 6M, RacePlace = 6, DidNotFinish = didNotFinish };
            var seventh = new RaceEntry(pointsSystem) { Entrant = DriverContract(), QualifyingTime = 7M, RacePlace = 7, DidNotFinish = didNotFinish };
            var eighth = new RaceEntry(pointsSystem) { Entrant = DriverContract(), QualifyingTime = 8M, RacePlace = 8, DidNotFinish = didNotFinish };
            var nineth = new RaceEntry(pointsSystem) { Entrant = DriverContract(), QualifyingTime = 9M, RacePlace = 9, DidNotFinish = didNotFinish };
            var tenth = new RaceEntry(pointsSystem) { Entrant = DriverContract(), QualifyingTime = 10M, RacePlace = 10, DidNotFinish = didNotFinish };
            var eleventh = new RaceEntry(pointsSystem) { Entrant = DriverContract(), QualifyingTime = 11M, RacePlace = 11, DidNotFinish = didNotFinish };

            var race = FakesFactory.Race(new List<RaceEntry>() { first, second, third, fourth, fifth, sixth, seventh, eighth, nineth, tenth, eleventh });

            return race.Entries.Single(e => e.RacePlace == racePosition);
        }

        public static RaceEntry RaceEntry(IPointsSystem pointsSystem, int racePosition)
        {
            var first = new RaceEntry(pointsSystem) { Entrant = DriverContract(), QualifyingTime = 1M, RacePlace = 1, QualifyingPosition = 1};
            var second = new RaceEntry(pointsSystem) { Entrant = DriverContract(), QualifyingTime = 2M, RacePlace = 2, QualifyingPosition = 2 };
            var third = new RaceEntry(pointsSystem) { Entrant = DriverContract(), QualifyingTime = 3M, RacePlace = 3, QualifyingPosition = 3 };
            var fourth = new RaceEntry(pointsSystem) { Entrant = DriverContract(), QualifyingTime = 4M, RacePlace = 4 , QualifyingPosition = 4};
            var fifth = new RaceEntry(pointsSystem) { Entrant = DriverContract(), QualifyingTime = 5M, RacePlace = 5, QualifyingPosition = 5};
            var sixth = new RaceEntry(pointsSystem) { Entrant = DriverContract(), QualifyingTime = 6M, RacePlace = 6, QualifyingPosition = 6};
            var seventh = new RaceEntry(pointsSystem) { Entrant = DriverContract(), QualifyingTime = 7M, RacePlace = 7, QualifyingPosition = 7};
            var eighth = new RaceEntry(pointsSystem) { Entrant = DriverContract(), QualifyingTime = 8M, RacePlace = 8, QualifyingPosition = 8};
            var nineth = new RaceEntry(pointsSystem) { Entrant = DriverContract(), QualifyingTime = 9M, RacePlace = 9, QualifyingPosition = 9};
            var tenth = new RaceEntry(pointsSystem) { Entrant = DriverContract(), QualifyingTime = 10M, RacePlace = 10, QualifyingPosition = 10};
            var eleventh = new RaceEntry(pointsSystem) { Entrant = DriverContract(), QualifyingTime = 11M, RacePlace = 11, QualifyingPosition = 11 };

            var race = FakesFactory.Race(new List<RaceEntry>() { first, second, third, fourth, fifth, sixth, seventh, eighth, nineth, tenth, eleventh });

            return race.Entries.Single(e => e.RacePlace == racePosition);        
        }
    
        public static Driver Driver()
        {
            var driver = new Driver
                             {
                                 Name = "Test Driver"
                             };

            return driver;  
        }

        private static int DriverContractId;
        public static DriverContract DriverContract()
        {
            return DriverContract(Driver());
        }

        public static DriverContract DriverContract(Driver driver)
        {
            var contract = Team().SignDriver(driver, Season());
            contract.Id = ++DriverContractId;
            return contract;
        }

        private static int SeasonId;
        public static Season Season()
        {
            var season = new Season()
                             {
                                 Id = ++SeasonId,
                                 Name = "Test Season"                                 
                             };

            season.AddRace(new Race() {Id = 1});
            season.AddRace(new Race() {Id = 2});

            return season;
        }

        private static int DriverId;
        public static Driver Driver(string name)
        {
            
            var driver = new Driver
            {
                Id = ++DriverId,
                Name = name
            };

            return driver;
        }

        public static Season GetSeasonWithOneRace()
        {
            var season = new Season()
            {
                Id = ++SeasonId,
                Name = "Test Season",
                PointsSystemTypeName = "atomicf1.domain.PointsSystem2011, atomicf1.domain"
            };

            season.AddRace(Race(season, new List<RaceEntry>() { 
                RaceEntry(season.PointsSystem, 1),
                RaceEntry(season.PointsSystem, 2),
                RaceEntry(season.PointsSystem, 3),
                RaceEntry(season.PointsSystem, 4),
                RaceEntry(season.PointsSystem, 5),
                RaceEntry(season.PointsSystem, 6),
                RaceEntry(season.PointsSystem, 7),
                RaceEntry(season.PointsSystem, 8),
                RaceEntry(season.PointsSystem, 9),
                RaceEntry(season.PointsSystem, 10),
                RaceEntry(season.PointsSystem, 11) }
                ));

            return season;
        }
    }
}
