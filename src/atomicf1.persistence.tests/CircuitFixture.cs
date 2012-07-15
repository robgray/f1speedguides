using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.domain;
using NUnit.Framework;

namespace atomicf1.persistence.Tests
{
    [TestFixture]
    public class CircuitFixture : InMemoryData
    {
        [Test]
        public void Can_add_circuit_to_database()
        {
            // Arrange
            var circuit = new Circuit
                              {
                                  Name = "Test Circuit",
                                  Location = "Bellbowrie",
                                  ImageUri = "http://imgserver.com/testtrack.png"
                              };

            // Act
            Session.Save(circuit);

            // Assert
            Session.Flush();
            Session.Clear();
            var fromDb = Session.Get<Circuit>(circuit.Id);
            Assert.AreNotSame(circuit, fromDb);
            Assert.AreEqual(circuit.Name, fromDb.Name);
            Assert.AreEqual(circuit.Location, fromDb.Location);
            Assert.AreEqual(circuit.ImageUri, fromDb.ImageUri);
        }

        [Test]
        public void Can_retrieve_circuit_from_database()
        {
            var circuit = Session.Get<Circuit>(1);
            Assert.IsNotNull(circuit);
            Assert.AreEqual(1, circuit.Id);
        }
    }
}
