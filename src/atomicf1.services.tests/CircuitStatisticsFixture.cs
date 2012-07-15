using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace atomicf1.services.tests
{
    [TestFixture]
    public class CircuitStatisticsFixture
    {
        [Test]
        public void Can_convert_to_minutes_seconds()
        {
            var stat = new CircuitStatistics(null, null, 78.334M, null);

            Assert.AreEqual("1:18.334", stat.QualifyingRecord);

        }
    }
}
