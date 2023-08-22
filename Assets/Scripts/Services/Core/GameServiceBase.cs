using UnityEngine;

namespace Fortis.Services
{
    public abstract class GameServiceBase : MonoBehaviour
    {
        private void OnEnable()
        {
             Register();
        }

        private void OnDisable()
        {
            Unregister();
        }

        private void OnDestroy()
        {
            Unregister();
        }

        public abstract void Register();

        public abstract void Unregister();
    }
}