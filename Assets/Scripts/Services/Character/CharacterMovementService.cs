using UnityEngine;

namespace Fortis.Services.Character
{
    public class CharacterMovementService : MonoBehaviour, IGameService
    {
        [SerializeField]
        private CharacterMovementSettings _movementSettings;

        private void Awake()
        {
            Register();
        }

        public Vector3 GetDestination()
        {
            float xPosition = Random.Range(_movementSettings.MinDestinationValue.x, _movementSettings.MaxDestinationValue.x);
            float zPosition = Random.Range(_movementSettings.MinDestinationValue.z, _movementSettings.MaxDestinationValue.z);

            return new Vector3(xPosition, 0, zPosition);
        }

        public void Register()
        {
            ServiceLocator.Instance.RegisterService(this);
        }

        public void Unregister()
        {
            ServiceLocator.Instance.UnregisterService(this);
        }
    }
}

