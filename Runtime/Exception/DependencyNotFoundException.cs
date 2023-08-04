using System;

namespace TF.Initializer
{
    public class DependencyNotFoundException : Exception
    {
        public DependencyNotFoundException(Type system, Type param) : base($"No System Found of Type {param} from injection of {system}") { }
    }
}
