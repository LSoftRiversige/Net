using System;
using System.Reflection;
using System.Linq;

namespace AppNet
{
    internal static class ControllerResolver
    {
        internal static IResponceController FindByName(string dllName, string className)
        {
            var assembly = Assembly.LoadFrom(dllName);

            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name.Equals(className, StringComparison.InvariantCultureIgnoreCase));
            if (type!=null)
            {
                object obj = Activator.CreateInstance(type);
                if (obj is IResponceController controller)
                {
                    return controller;
                }
            }
            return null;
        }
    }
}