using System;
using System.Collections.Generic;
using System.Linq;
#if TF_HAS_TFODINEXTENDER
using TF.OdinExtendedInspector;
#elif TF_HAS_TYPEREFERENCES
using TypeReferences;
#endif
using UnityEngine;

namespace TF.Initializer
{
    [CreateAssetMenu(fileName = "New Service Group", menuName = "Twin Faerie/Initializer/New Service Group", order = -200)]
    public class ServiceGroup : ScriptableObject
    {
#if TF_HAS_TFODINEXTENDER
        [TypeConstraint(typeof(IService))]
        [SerializeField] private List<TypeRef> services = new();
        [TypeConstraint(typeof(IServiceMono))]
        [SerializeField] private List<TypeRef> monoServices = new();
#elif TF_HAS_TYPEREFERENCES
        [Inherits(typeof(IService), ShortName = true,  IncludeAdditionalAssemblies = new[] { "Assembly-CSharp" })]
        [SerializeField] private List<TypeReference> services;
        [Inherits(typeof(IServiceMono), ShortName = true, IncludeAdditionalAssemblies = new[] { "Assembly-CSharp" })]
        [SerializeField] private List<TypeReference> monoServices;
#else
        [SerializeReference] private List<Type> services = new();
        [SerializeReference] private List<Type> monoServices = new();
#endif
        [SerializeField] private List<MonoBehaviour> prefabServices;

#if TF_HAS_TFODINEXTENDER || TF_HAS_TYPEREFERENCES
        public IEnumerable<Type> Services => services.Select(item => item.Type);
        public IEnumerable<Type> MonoServices => monoServices.Select(item => item.Type);
#else
        public IEnumerable<Type> Services => services.Select(item => Type.GetType(item));
        public IEnumerable<Type> MonoServices => monoServices.Select(item => Type.GetType(item));
#endif
        public IEnumerable<MonoBehaviour> PrefabServices => prefabServices;
    }
}
