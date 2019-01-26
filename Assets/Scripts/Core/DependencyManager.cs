using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class DI
    {
        public static void Add<T>(object dependency)
        {
            DependencyManager.Add<T>(dependency);
        }

        public static void Add(Type type, object dependency)
        {
            DependencyManager.Add(type, dependency);
        }

        public static T Get<T>()
        {
            return DependencyManager.Get<T>();
        }
    }

    public class DependencyManager
    {
        private static Dictionary<Type, object> Dependencies = new Dictionary<Type, object>();
        
        public static void Add<T>(object dependency)
        {
            Add(typeof(T), dependency);
        }

        public static void Add(Type type, object dependency)
        {
            if (!Dependencies.ContainsKey(type))
            {
                Dependencies.Add(type,dependency);
            }
            else
            {
                Dependencies[type] = dependency;
            }
        }

        public static T Get<T>()
        {
            if (Dependencies.ContainsKey(typeof(T)))
            {
                return (T) Dependencies[typeof(T)];
            }

            return default(T);
        }
    }
}