using System.Collections.Generic;
using UnityEngine;

namespace Fortis.Services
{
    public class ServiceLocator : MonoBehaviour
    {
        public static ServiceLocator s_instance;

        public Dictionary<string, GameServiceBase> Services = new Dictionary<string, GameServiceBase>();

        private void Awake()
        {
            if(s_instance == null)
            {
                s_instance = this;
            }
        }

        public T Get<T>() where T : GameServiceBase
        {
            string key = typeof(T).Name;
            if (!Services.ContainsKey(key))
            {
                Debug.LogError($"{key} not registered");
            }

            return (T)Services[key];
        }

        public void RegisterService<T>(T service) where T : GameServiceBase
        {
            string key = typeof(T).Name;
            if (!Services.ContainsKey(key))
            {
                Services.Add(key, service);
            }
        }

        public void UnregisterService<T>(T service) where T : GameServiceBase
        {
            string key = typeof(T).Name;
            if (Services.ContainsKey(key))
            {
                Services.Remove(key);
            }
        }
    }
}