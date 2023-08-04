using System;

namespace TF.Initializer
{
    public static class ServiceLocator
    {
        public static T GetService<T>() where T : IServiceBase
        {
            return ServiceContainer.Default.GetService<T>();
        }

        public static IServiceBase GetService(Type serviceType)
        {
            if (serviceType == typeof(IServiceBase))
            { return null; }

            return ServiceContainer.Default.GetService(serviceType);
        }
    }
}