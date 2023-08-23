using Fortis.Services;
using Fortis.Services.Character;
using UnityEngine;
using UnityEngine.Timeline;

namespace Fortis.Character
{
    public class CharacterBase : MonoBehaviour
    {
        [SerializeField]
        private CharacterSettings _characterSettings;

        private const float COMPENSATION_TO_FINISH = 1f;
        private Vector3 _currentDestination = Vector3.zero;
        private float _elapsedDuplicateTime = 0;
        private float _currentDelayToDuplicate = 0;


        private void Start()
        {
            
        }

        public void OnStart()
        {
            SetDestination();
            UpdateCurrentDelayToDuplicate();
        }

        private void SetDestination()
        {
            _currentDestination = ServiceLocator.s_instance.Get<CharacterMovementService>().GetDestination();
            transform.LookAt(_currentDestination);
        }

        private void Update()
        {
            if(!IsAbleToDuplicate())
            {
                _elapsedDuplicateTime += Time.deltaTime;
            }

            if (Vector3.Distance(_currentDestination, transform.position) <= COMPENSATION_TO_FINISH)
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
                ServiceLocator.s_instance.Get<CharacterCollisionService>().OnCharacterCollide(this, collidedCharacter, IsAbleToDuplicate());
                _elapsedDuplicateTime = 0;
                UpdateCurrentDelayToDuplicate();
                //collidedCharacter.UpdateCurrentDelayToDuplicate();
                //collidedCharacter._elapsedDuplicateTime = _elapsedDuplicateTime;
            }
        }

        private bool IsAbleToDuplicate()
        {
            return _elapsedDuplicateTime >= _currentDelayToDuplicate;
        }

        public void UpdateCurrentDelayToDuplicate()
        {
            _currentDelayToDuplicate = GetCurrentDelayToDuplicate();
        }

        private float GetCurrentDelayToDuplicate()
        {
            int charactersQuantity = ServiceLocator.s_instance.Get<CharacterInstantiatorService>().GetCharactersQuantity(this);
            float currentIncreaseDelay = _characterSettings.DelayIncreasage * charactersQuantity;
            
            return currentIncreaseDelay + _characterSettings.DelayToCollide; 
        }
    }
}