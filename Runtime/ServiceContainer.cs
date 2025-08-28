using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace TF.Initializer
{
    using Object = UnityEngine.Object;
    
    public class ServiceContainer
    {
        internal static ServiceContainer Default { get; private set; }
        internal static ServiceGroup ServiceGroup { get; private set; }

        private readonly Dictionary<Type, IServiceBase> services = new();
        private Transform objectParent;

        internal static void Create(bool forced = false)
        {
            if (forced)
            {
                Default = null;
            }
            
            Default ??= new ServiceContainer();
        }

        internal void InitServices()
        {
            ServiceGroup = InitializerSetupSetting.GetInstance().ServiceGroup;

            InitAllServices();
            InjectDependencies();
        }

        internal void DelayedInitServices()
        {
            DelayedInitAllServices();
        }

        private void InitAllServices()
        {
            foreach (var item in ServiceGroup.Services)
            {
                InitService(Activator.CreateInstance(item) as IService);
            }

            objectParent = new GameObject("TF Service Container").transform;
            Object.DontDestroyOnLoad(objectParent.gameObject);

            foreach (var item in ServiceGroup.MonoServices)
            {
                InitService(new GameObject().AddComponent(item) as IServiceMono);
            }

            foreach (var item in ServiceGroup.PrefabServices)
            {
                InitService(Object.Instantiate(item.gameObject).GetComponent(item.GetType()) as IServiceMono);
            }
        }

        private void InjectDependencies()
        {
            foreach (var service in services.Keys)
            {
                var methodBase = service.GetMethod("Inject", BindingFlags.NonPublic | BindingFlags.Instance);

                if (methodBase is null)
                { continue; }

                var paramList = methodBase.GetParameters();

                if (paramList.Length == 0)
                { continue; }

                var serviceParam = new List<IServiceBase>();
                foreach (var param in paramList)
                {
                    var inject = GetService(param.ParameterType) ?? throw new DependencyNotFoundException(service, param.ParameterType);
                    serviceParam.Add(inject);
                }

                methodBase.Invoke(GetService(service), serviceParam.ToArray());
            }
        }

        private void DelayedInitAllServices()
        {
            foreach (var system in services.Keys)
            {
                var methodBase = system.GetMethod("DelayedInit", BindingFlags.NonPublic | BindingFlags.Instance);

                if (methodBase is null)
                { continue; }

                methodBase.Invoke(GetService(system), null);
            }
        }

        private void InitService(IServiceBase service)
        {
            service.Init();
            services.Add(service.GetType(), service);
        }

        private void InitService(IServiceMono service)
        {
            Object.DontDestroyOnLoad(service.gameObject);

            service.gameObject.name = service.GetType().Name;
            service.gameObject.transform.SetParent(objectParent);

            InitService(service as IServiceBase);
        }

        internal T GetService<T>() where T : IServiceBase
        {
            var service = GetService(typeof(T));

            if (service == null)
            { return default; }

            return (T)service;
        }

        internal IServiceBase GetService(Type type)
        {
            services.TryGetValue(type, out IServiceBase data);

            return data;
        }
    }
}