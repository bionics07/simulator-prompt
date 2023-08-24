using Fortis.Services;
using Fortis.Services.Character;
using UnityEngine;

namespace Fortis.Character
{
    public class CharacterBase : MonoBehaviour
    {
        [SerializeField]
        private CharacterSettings _characterSettings;

        private const float COMPENSATION_TO_FINISH_RUNNING = 1f;
        private Vector3 _currentDestination = Vector3.zero;
        private float _elapsedTimeToDuplicate = 0;
        private float _currentDelayToDuplicate = 0;

        public void OnStart()
        {
            SetDestination();
            UpdateCurrentDelayToDuplicate();
        }

        private void SetDestination()
        {
            _currentDestination = ServiceLocator.Instance.Get<CharacterMovementService>().GetDestination();
            transform.LookAt(_currentDestination);
        }

        private void Update()
        {
            if(!IsAbleToDuplicate())
            {
                _elapsedTimeToDuplicate += Time.deltaTime;
            }

            if (Vector3.Distance(_currentDestination, transform.position) <= COMPENSATION_TO_FINISH_RUNNING)
            {
                SetDestination();
            }

            float step = _characterSettings.Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _currentDestination, step);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CharacterBase collidedCharacter))
            {
                ServiceLocator.Instance.Get<CharacterCollisionService>().OnCharacterCollide(this, collidedCharacter, IsAbleToDuplicate());
            }
        }

        private bool IsAbleToDuplicate()
        {
            return _elapsedTimeToDuplicate >= _currentDelayToDuplicate;
        }

        public void UpdateCurrentDelayToDuplicate()
        {
            _elapsedTimeToDuplicate = 0;
            _currentDelayToDuplicate = GetCurrentDelayToDuplicate();
        }

        private float GetCurrentDelayToDuplicate()
        {
            int charactersQuantity = ServiceLocator.Instance.Get<CharacterInstantiatorService>().GetCharactersQuantity(this);
            float currentIncreaseDelay = _characterSettings.DelayIncreasage * charactersQuantity;
            
            return currentIncreaseDelay + _characterSettings.DelayToCollide; 
        }
    }
}