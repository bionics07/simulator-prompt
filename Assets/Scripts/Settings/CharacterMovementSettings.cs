using UnityEngine;

namespace Fortis.Services.Character
{
    [CreateAssetMenu(fileName = "CharacterMovementSettings", menuName = "ScriptableObjects/Settings/CharacterMovement")]
    public class CharacterMovementSettings : ScriptableObject
    {
        public Vector3 MaxDestinationValue;
        public Vector3 MinDestinationValue;
    }
}

