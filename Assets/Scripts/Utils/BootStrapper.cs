using Fortis.Services;
using Fortis.Services.Character;
using UnityEngine;

namespace Fortis.Utils
{
    public static class Bootstrapper
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initiailze()
        {
            // Initialize default service locator.
            ServiceLocator.Initialize();

            ServiceLocator.Instance.RegisterService(new CharacterCollisionService());
        }
    }
}
