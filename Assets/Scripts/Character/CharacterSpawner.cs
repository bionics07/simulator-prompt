using Fortis.Services;
using Fortis.Services.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fortis.Character.Spawner
{
    public class CharacterSpawner : MonoBehaviour
    {
        [SerializeField]
        private SpawnerSettings _spawnerSettings;

        private Coroutine _spawnerCoroutine;

        public SpawnerSettings SpawnerSettings => _spawnerSettings;

        private void Start()
        {
            ResetCoroutine();
        }

        public void ForceRefresh()
        {
            ResetCoroutine();
        }

        private void ResetCoroutine()
        {
            if (_spawnerCoroutine != null)
            {
                StopCoroutine(_spawnerCoroutine);
                _spawnerCoroutine = null;
            }

            _spawnerCoroutine = StartCoroutine(SpawnCharacter());
        }

        private IEnumerator SpawnCharacter()
        {
            float xPosition = Random.Range(-_spawnerSettings.RaidousRange, _spawnerSettings.RaidousRange) + transform.position.x;
            float zPosition = Random.Range(-_spawnerSettings.RaidousRange, _spawnerSettings.RaidousRange) + transform.position.z;

            Vector3 positionToSpawn = new Vector3(xPosition, 0, zPosition);

            ServiceLocator.s_instance.Get<CharacterInstantiatorService>().InstantiateCharacter(_spawnerSettings.CharacterPrefab, positionToSpawn);

            float delay = Random.Range(_spawnerSettings.MinDelayToSpawn, _spawnerSettings.MaxDelayToSpawn);
            yield return new WaitForSeconds(delay);
            ResetCoroutine();
        }
    }
}

