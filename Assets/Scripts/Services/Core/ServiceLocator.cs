using System.Collections.Generic;
using UnityEngine;

namespace Lumen.Services
{
    public class ServiceLocator
    {
        private ServiceLocator() { }

        public static ServiceLocator Instance { get; private set; }

        public Dictionary<string, IGameService> Services = new Dictionary<string, IGameService>();

        public static void Initialize()
        {
            Instance = new ServiceLocator();
        }

        public T Get<T>() where T : IGameService
        {
            string key = typeof(T).Name;
            if (!Services.ContainsKey(key))
            {
                Debug.LogError($"{key} not registered");
            }

            return (T)Services[key];
        }

        public void RegisterService<T>(T service) where T : IGameService
        {
            string key = typeof(T).Name;
            if (!Services.ContainsKey(key))
            {
                Services.Add(key, service);
            }
        }

        public void UnregisterService<T>(T service) where T : IGameService
        {
            string key = typeof(T).Name;
            if (Services.ContainsKey(key))
            {
                Services.Remove(key);
            }
        }
    }
}