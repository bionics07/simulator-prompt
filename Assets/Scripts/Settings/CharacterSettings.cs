using UnityEngine;

namespace Fortis.Character
{
    [CreateAssetMenu(fileName = "CharacterSettings", menuName = "ScriptableObjects/Settings/Character")]
    public class CharacterSettings : ScriptableObject
    {
        public float Speed = 1f;
        public float DelayToCollide = 0.5f;
    }
}