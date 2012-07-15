using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.common;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Releasers;
using Castle.Windsor;

namespace atomicf1.domain
{
    public class WindsorStarter
    {
        public void Start()
        {
            IWindsorContainer container;
            
            if (!IoC.IsInitialized)
            {
                container = new WindsorContainer();
                container.Kernel.ReleasePolicy = new NoTrackingReleasePolicy();
                IoC.Initialize(container);                
            }
            else
            {
                container = IoC.Container;
            }

            container.Register(Component.For<IPointsSystem>().ImplementedBy<PointsSystem2011>());
        }
    }
}
