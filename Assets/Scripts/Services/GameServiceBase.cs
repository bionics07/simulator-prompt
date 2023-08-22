using UnityEngine;

namespace Fortis.Services
{
    public class GameServiceBase : MonoBehaviour
    {
        public void Register()
        {
            ServiceLocator.s_instance.RegisterService(this);
        }

        public void Unregister()
        {
            ServiceLocator.s_instance.UnregisterService(this);
        }
    }
}