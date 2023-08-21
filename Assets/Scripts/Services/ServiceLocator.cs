using System.Collections.Generic;
using UnityEngine;

namespace Fortis.Services
{
    public class ServiceLocator : MonoBehaviour
    {
        public static ServiceLocator s_instance;

        public Dictionary<string, IGameService> Services = new Dictionary<string, IGameService>();

        private void Awake()
        {
            if (s_instance == null)
            {
                s_instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }
    }
}