using UnityEngine;
using UnityEngine.Scripting;

[assembly: AlwaysLinkAssembly]

namespace TF.Initializer
{
    internal class ServiceInitializer
    {
        protected ServiceInitializer() { }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
            ServiceContainer.Create(true);
            ServiceContainer.Default.InitServices();
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void DelayedInit()
        {
            ServiceContainer.Default.DelayedInitServices();
        }
    }
}