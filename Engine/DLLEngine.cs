using System;
using System.Linq;
using System.Reflection;

namespace jp.tamagotchi.engine.csharp.Engine
{
    public class DLLEngine : IRenderer
    {
        public object Render(string fileName)
        {
            var assembly = Assembly.LoadFrom(fileName);

            var type = assembly.GetTypes()
                .SingleOrDefault(t => t.GetCustomAttribute(typeof(object)) != null);

            var instance = Activator.CreateInstance(type) as object;

            return instance;
        }
    }
}