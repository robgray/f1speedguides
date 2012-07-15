using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using atomicf1.domain.Repositories;
using Rhino.Mocks;
using atomicf1.domain.Tests;

namespace atomicf1.services.tests
{
    [TestFixture]
    public class StatisticianFixture
    {
        private Statistician _statistician;
        private IRaceRepository _raceRepository;
        private ISeasonRepository _seasonRepository;
        private IDriverRepository _driverRepository;
        private IDriverContractRepository _contractRepository;

        [SetUp]
        public void SetUp()
        {
            _raceRepository = MockRepository.GenerateMock<IRaceRepository>();
            _seasonRepository = MockRepository.GenerateMock<ISeasonRepository>();
            _driverRepository = MockRepository.GenerateMock<IDriverRepository>();
            _contractRepository = MockRepository.GenerateMock<IDriverContractRepository>();


            _statistician = new Statistician(_raceRepository, _seasonRepository, _driverRepository, _contractRepository);
        }

        [Test]
        public void Can_get_Detailed_Qualifying_Table()
        {
            var season = FakesFactory.GetSeasonWithOneRace();

            var table = _statistician.GetDetailedQualifyingTable(season);

            Assert.AreEqual("Driver", table.Columns[0].ColumnName);
            Assert.AreEqual("Rnd 1", table.Columns[1].ColumnName);

            Assert.AreEqual("Test Driver", table.Rows[0][0]);
        }

        [Test]
        public void Can_get_pole_positions_table()
        {
            var season = FakesFactory.GetSeasonWithOneRace();

            _raceRepository.Expect(x => x.GetAll()).Return(season.Races);

            var table = _statistician.GetPolesTable();           
        }
    }
}
