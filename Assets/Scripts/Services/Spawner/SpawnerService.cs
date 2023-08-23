using Fortis.Character;
using Fortis.Character.Spawner;
using System.Collections.Generic;
using UnityEngine;

namespace Fortis.Services
{
    public class SpawnerService : GameServiceBase
    {
        [SerializeField]
        private List<CharacterSpawner> _characterSpawners;

        private void Awake()
        {
            InitializeSpawners();
        }

        public CharacterSpawner GetSpawner(SpawnerType spawnerType)
        {
            switch (spawnerType)
            {
                case SpawnerType.Red:
                    return _characterSpawners.Find(spawner => spawner.SpawnerSettings.CharacterPrefab is RedCharacter);
                case SpawnerType.Green:
                    return _characterSpawners.Find(spawner => spawner.SpawnerSettings.CharacterPrefab is GreenCharacter);
                case SpawnerType.Blue:
                    return _characterSpawners.Find(spawner => spawner.SpawnerSettings.CharacterPrefab is BlueCharacter);
                case SpawnerType.Yellow:
                    return _characterSpawners.Find(spawner => spawner.SpawnerSettings.CharacterPrefab is YellowCharacter);
                default:
                    return null;
            }
        }

        public override void Register()
        {
            ServiceLocator.s_instance.RegisterService(this);
        }

        public override void Unregister()
        {
            ServiceLocator.s_instance.UnregisterService(this);
        }


        private void InitializeSpawners()
        {
            foreach (CharacterSpawner characterSpawner in _characterSpawners)
            {
                characterSpawner.InitializeSpawner();
            }
        }
    }
}