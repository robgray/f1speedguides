using System;
using System.Collections;
using Castle.Windsor;

namespace atomicf1.common
{
    public static class IoC
    {
        public static void Initialize(IWindsorContainer windsorContainer)
        {
            GlobalContainer = windsorContainer;
        }

        public static object Resolve(Type serviceType)
        {
            return Container.Resolve(serviceType);
        }

        public static object Resolve(Type serviceType, string serviceName)
        {
            return Container.Resolve(serviceName, serviceType);
        }

        /// <summary>
        /// Tries to resolve the component, but return null
        /// instead of throwing if it is not there.
        /// Useful for optional dependencies.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T TryResolve<T>()
        {
            return TryResolve(default(T));
        }

        /// <summary>
        /// Tries to resolve the compoennt, but return the default 
        /// value if could not find it, instead of throwing.
        /// Useful for optional dependencies.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static T TryResolve<T>(T defaultValue)
        {
            if (Container.Kernel.HasComponent(typeof(T)) == false)
                return defaultValue;
            return Container.Resolve<T>();
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public static T Resolve<T>(string name)
        {
            return Container.Resolve<T>(name);
        }

        public static T Resolve<T>(IDictionary parameters)
        {
            return Container.Resolve<T>(parameters);
        }

        public static IWindsorContainer Container
        {
            get
            {
                IWindsorContainer result = GlobalContainer;
                if (result == null)
                    throw new InvalidOperationException("The container has not been initialized! Please call IoC.Initialize(container) before using it.");
                return result;
            }
        }

        public static bool IsInitialized
        {
            get { return GlobalContainer != null; }
        }

        internal static IWindsorContainer GlobalContainer { get; set; }

        public static void Release(object obj)
        {
            Container.Release(obj);
        }
    }
}
