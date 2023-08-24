using UnityEngine;

namespace Lumen.Character.Spawner
{
    [CreateAssetMenu(fileName = "SpawnerSettings", menuName = "ScriptableObjects/Settings/Spawner")]
    public class SpawnerSettings : ScriptableObject
    {
        public CharacterBase CharacterPrefab;
        public float MinDelayToSpawn;
        public float MaxDelayToSpawn;
        public float RaidousRange;
    }
}

