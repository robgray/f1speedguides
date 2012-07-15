using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace atomicf1.domain.Tests
{
    [TestFixture]
    public class TeamFixture
    {
        [Test]
        public void Can_sign_driver_to_team()
        {
            var team = new Team {Name = "McLaren"};
            var driver = new Driver { Name = "Test Driver" };
            var season = new Season {Id = 1};

            Assert.AreEqual(0, team.Drivers.Count());

            var contract = team.SignDriver(driver, season);

            Assert.AreEqual(1, team.Drivers.Count());
            Assert.IsNotNull(contract);
            Assert.AreEqual(team, contract.Team);
        }

        [Test]
        public void Fire_driver_terminates_contract()
        {
            var driver = FakesFactory.Driver();
            var contract = new DriverContract { Id = 1, Driver = driver, SignedDate = DateTime.Parse("2010-05-01")};                        
            var team = FakesFactory.Team(new List<DriverContract> {contract});

            Assert.AreEqual(1, team.Drivers.Count());

            team.FireDriver(driver);
            //contract = team.Contracts.Single(c => c.Id == 1);

            Assert.AreEqual(0, team.Drivers.Count());
            Assert.IsNull(driver.CurrentTeam);
            Assert.IsTrue(contract.TerminatedDate.HasValue);
            Assert.IsFalse(contract.IsActive);
        }

        [Test]
        public void ActiveContracts_does_not_contain_terminated_contracts()
        {
            var driver = FakesFactory.Driver("Driver 1");
            var driver2 = FakesFactory.Driver("Driver 2");
            var contract = new DriverContract { Id = 1, Driver = driver, SignedDate = DateTime.Parse("2010-05-01"), TerminatedDate = DateTime.Parse("2011-05-01") };
            var contract2 = new DriverContract { Id = 2, Driver = driver2, SignedDate = DateTime.Parse("2010-05-01") };
            var team = FakesFactory.Team(new List<DriverContract> { contract, contract2 });

            Assert.AreEqual(1, team.ActiveContracts.Count());         
        }

        [Test]
        public void Drivers_contains_only_active_drivers()
        {
            var driver = FakesFactory.Driver("Driver 1");
            var driver2 = FakesFactory.Driver("Driver 2");
            var contract = new DriverContract { Id = 1, Driver = driver, SignedDate = DateTime.Parse("2010-05-01"), TerminatedDate = DateTime.Parse("2011-05-01") };
            var contract2 = new DriverContract { Id = 2, Driver = driver2, SignedDate = DateTime.Parse("2010-05-01") };
            var team = FakesFactory.Team(new List<DriverContract> { contract, contract2 });            

            Assert.AreEqual(1, team.Drivers.Count());
            Assert.AreEqual(driver2.Id, team.Drivers.First().Id);            
        }

        [Test]
        public void Cannot_sign_driver_already_on_a_contract_for_the_season()
        {
            var driver = FakesFactory.Driver("Driver 1");
            var team = FakesFactory.Team();     
            var season = new Season {Id = 1};

            var contract = team.SignDriver(driver, season);

            Assert.IsNotNull(contract);
            Assert.IsTrue(contract.IsActive);

            var exception = Assert.Throws<DriverAlreadyContractedException>(() => team.SignDriver(driver, season));
            Assert.AreEqual("Driver is already contracted to this team", exception.Message);
            
        }
    }    
}
