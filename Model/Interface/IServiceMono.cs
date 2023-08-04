using UnityEngine;

namespace TF.Initializer
{
    public interface IServiceMono : IServiceBase
    {
        GameObject gameObject { get; }
    }
}