using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace atomicf1.domain.Tests
{    
    [TestFixture]
    public class WindsorFixture
    {
        [SetUp]
        public virtual void SetUp()
        {
            new WindsorStarter().Start();
        }
    }
}
