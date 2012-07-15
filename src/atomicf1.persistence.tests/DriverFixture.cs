using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.domain;
using NUnit.Framework;

namespace atomicf1.persistence.Tests
{
    [TestFixture]
    public class DriverFixture : InMemoryData
    {
        [Test]
        public void Can_add_driver_to_database()
        {
            var driver = new Driver
                             {
                                 Name = "Robert Gray"
                             };

            Session.Save(driver);
            Session.Flush();
            Session.Clear();

            var fromDb = Session.Get<Driver>(driver.Id);
            Assert.AreNotSame(driver, fromDb);
            Assert.AreEqual(driver.Name, fromDb.Name);
        }
    }
}
