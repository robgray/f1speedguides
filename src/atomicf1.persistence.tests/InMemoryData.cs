using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.domain;

namespace atomicf1.persistence.Tests
{
    public abstract class InMemoryData : InMemoryDatabase
    {
        protected InMemoryData()
        {
            // populate the in memory database here with test data.
            var circuit = new Circuit { Id = 1, ImageUri = "http://imagesource.com/img.png", Location = "Test Location", Name = "Test Circuit" };
            var circuit2 = new Circuit {Id = 2, Name = "Albert Park", Location = "Melbourne", Country = "Australia"};

            Session.Save(circuit);
            Session.Save(circuit2);

            Session.Flush();
        }
    }
}
