using Lumen.Services;
using Lumen.Services.Character;
using System.Collections;
using UnityEngine;

namespace Lumen.Character.Spawner
{
    public class CharacterSpawner : MonoBehaviour
    {
        [SerializeField]
        private SpawnerSettings _spawnerSettings;

        private Coroutine _spawnerCoroutine;

        public float CurrentMinSpawnDelay { get; set; } = 0;
        public float CurrentMaxSpawnDelay { get; set; } = 0;
        public SpawnerSettings SpawnerSettings => _spawnerSettings;

        public void InitializeSpawner()
        {
            CurrentMinSpawnDelay = _spawnerSettings.MinDelayToSpawn;
            CurrentMaxSpawnDelay = _spawnerSettings.MaxDelayToSpawn;
        }

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

            ServiceLocator.Instance.Get<CharacterInstantiatorService>().InstantiateCharacter(_spawnerSettings.CharacterPrefab, positionToSpawn);

            float delay = Random.Range(CurrentMinSpawnDelay, CurrentMaxSpawnDelay);
            yield return new WaitForSeconds(delay);
            ResetCoroutine();
        }
    }

    public enum SpawnerType
    {
        Red,
        Green,
        Blue,
        Yellow
    }
}

