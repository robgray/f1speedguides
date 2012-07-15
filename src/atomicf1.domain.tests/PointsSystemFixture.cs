using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using atomicf1.common;

namespace atomicf1.domain.Tests
{
    [TestFixture]
    public class PointsSystemFixture 
    {
        private IPointsSystem _pointsSystem;

        [SetUp]
        public void SetUp()
        {            
            _pointsSystem = new PointsSystem2010();
            CacheHelper.InvalidateAll();
        }

        [Test]
        [TestCaseSource("Points2010Cases")]
        [TestCaseSource("Points2011Cases")]
        [TestCaseSource("Points1991Cases")]
        [TestCaseSource("Points1990Cases")]
        public void Points_are_correct_for_race_place(Type t, int place, decimal expectedPoints)
        {
            PointsSystem pointsSystem = (PointsSystem)Activator.CreateInstance(t);

            // Arrange
            var entry = FakesFactory.RaceEntry(pointsSystem, place);

            // Act
            var points = pointsSystem.CalculatePoints(entry);

            // Assert
            Assert.AreEqual(expectedPoints, points);
        }

        [Test]
        public void Calculate_season_points_respects_top_results()
        {
            var pointsSystem = new TopResultOnlyPointsSystem();

            var results = new List<RaceEntry> 
            {
                FakesFactory.RaceEntry(pointsSystem, 1),
                FakesFactory.RaceEntry(pointsSystem, 2),
                FakesFactory.RaceEntry(pointsSystem, 3)
            };


            var points = pointsSystem.CalculateSeasonPoints(results);

            Assert.AreEqual(9, points);
        }
        
        [Test]
        public void Calculate_points_respects_score_did_not_finish_false()
        {
            var pointsSystem = new TopResultOnlyPointsSystem();

            var results = new List<RaceEntry> 
            {
                FakesFactory.RaceEntry(pointsSystem, 1, true),
                FakesFactory.RaceEntry(pointsSystem, 2, true),
                FakesFactory.RaceEntry(pointsSystem, 3, true)
            };

            var points = pointsSystem.CalculateSeasonPoints(results);

            Assert.AreEqual(0, points);
        }

        [Test]
        public void Calculate_points_respects_score_did_not_finish_true()
        {
            var pointsSystem = new TopResultOnlyPointsSystemCountDnf();

            var results = new List<RaceEntry> 
            {
                FakesFactory.RaceEntry(pointsSystem, 1, true)
            };

            var points = pointsSystem.CalculateSeasonPoints(results);

            Assert.AreEqual(9, points);
        }

        private class TopResultOnlyPointsSystem : PointsSystem
        {
            public TopResultOnlyPointsSystem()
            {
                TopResults = 1;
            }

            protected override bool ScoreDidNotFinish()
            {
                return false;
            }

            protected override void BuildRacePoints()
            {
                _racePoints = new Dictionary<int, decimal>
                              {
                                  {1, 9M},
                                  {2, 6M},
                                  {3, 4M},
                                  {4, 3M},
                                  {5, 2M},
                                  {6, 1M}
                              };
            }
        }

        private class TopResultOnlyPointsSystemCountDnf : TopResultOnlyPointsSystem
        {
            public TopResultOnlyPointsSystemCountDnf()
            {
                TopResults = 1;
            }

            protected override bool  ScoreDidNotFinish()
            {
                return true; 	         
            }

            protected override void BuildRacePoints()
            {
                _racePoints = new Dictionary<int, decimal>
                              {
                                  {1, 9M},
                                  {2, 6M},
                                  {3, 4M},
                                  {4, 3M},
                                  {5, 2M},
                                  {6, 1M}
                              };
            }
        }

        static object[] Points2010Cases = 
        {
            new object[] { typeof(PointsSystem2010), 1, 30M }, 
            new object[] { typeof(PointsSystem2010), 2, 22M }, 
            new object[] { typeof(PointsSystem2010), 3, 18M }, 
            new object[] { typeof(PointsSystem2010), 4, 14M }, 
            new object[] { typeof(PointsSystem2010), 5, 11M }, 
            new object[] { typeof(PointsSystem2010), 6, 8M }, 
            new object[] { typeof(PointsSystem2010), 7, 6M }, 
            new object[] { typeof(PointsSystem2010), 8, 4M }, 
            new object[] { typeof(PointsSystem2010), 9, 2M }, 
            new object[] { typeof(PointsSystem2010), 10, 1M }, 
            new object[] { typeof(PointsSystem2010), 11, 0M }, 
        };

        static object[] Points2011Cases = 
        {
            new object[] { typeof(PointsSystem2011), 1, 25M }, 
            new object[] { typeof(PointsSystem2011), 2, 18M }, 
            new object[] { typeof(PointsSystem2011), 3, 15M }, 
            new object[] { typeof(PointsSystem2011), 4, 12M }, 
            new object[] { typeof(PointsSystem2011), 5, 10M }, 
            new object[] { typeof(PointsSystem2011), 6, 8M }, 
            new object[] { typeof(PointsSystem2011), 7, 6M }, 
            new object[] { typeof(PointsSystem2011), 8, 4M }, 
            new object[] { typeof(PointsSystem2011), 9, 2M }, 
            new object[] { typeof(PointsSystem2011), 10, 1M }, 
            new object[] { typeof(PointsSystem2011), 11, 0M }, 
        };

        static object[] Points1991Cases = 
        {
            new object[] { typeof(PointsSystem1991), 1, 10M }, 
            new object[] { typeof(PointsSystem1991), 2, 6M }, 
            new object[] { typeof(PointsSystem1991), 3, 4M }, 
            new object[] { typeof(PointsSystem1991), 4, 3M }, 
            new object[] { typeof(PointsSystem1991), 5, 2M }, 
            new object[] { typeof(PointsSystem1991), 6, 1M }, 
            new object[] { typeof(PointsSystem1991), 7, 0M }, 
            new object[] { typeof(PointsSystem1991), 8, 0M }, 
            new object[] { typeof(PointsSystem1991), 9, 0M }, 
            new object[] { typeof(PointsSystem1991), 10, 0M }, 
            new object[] { typeof(PointsSystem1991), 11, 0M }, 
        };

        static object[] Points1990Cases = 
        {
            new object[] { typeof(PointsSystem1990), 1, 10M }, 
            new object[] { typeof(PointsSystem1990), 2, 6M }, 
            new object[] { typeof(PointsSystem1990), 3, 4M }, 
            new object[] { typeof(PointsSystem1990), 4, 3M }, 
            new object[] { typeof(PointsSystem1990), 5, 2M }, 
            new object[] { typeof(PointsSystem1990), 6, 1M }, 
            new object[] { typeof(PointsSystem1990), 7, 0M }, 
            new object[] { typeof(PointsSystem1990), 8, 0M }, 
            new object[] { typeof(PointsSystem1990), 9, 0M }, 
            new object[] { typeof(PointsSystem1990), 10, 0M }, 
            new object[] { typeof(PointsSystem1990), 11, 0M }, 
        };
    }
}
