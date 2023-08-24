using Lumen.Services;
using Lumen.Services.Character;
using UnityEngine;

namespace Lumen.Utils
{
    public static class Bootstrapper
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initiailze()
        {
            // Initialize service locator.
            ServiceLocator.Initialize();

            ServiceLocator.Instance.RegisterService(new CharacterCollisionService());
        }
    }
}
