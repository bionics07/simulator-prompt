using UnityEngine;

namespace Fortis.Services.Character
{
    public class CharacterMovementService : GameServiceBase
    {
        [SerializeField]
        private CharacterMovementSettings _movementSettings;

        public Vector3 GetDestination()
        {
            float xPosition = Random.Range(_movementSettings.MinDestinationValue.x, _movementSettings.MaxDestinationValue.x);
            float zPosition = Random.Range(_movementSettings.MinDestinationValue.z, _movementSettings.MaxDestinationValue.z);

            return new Vector3(xPosition, 0, zPosition);
        }

        public override void Register()
        {
            ServiceLocator.s_instance.RegisterService(this);
        }

        public override void Unregister()
        {
            ServiceLocator.s_instance.UnregisterService(this);
        }
    }
}

