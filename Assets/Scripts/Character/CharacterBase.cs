using Fortis.Services;
using Fortis.Services.Character;
using UnityEngine;

namespace Fortis.Character
{
    public class CharacterBase : MonoBehaviour
    {
        [SerializeField]
        private CharacterSettings _characterSettings;

        private const float COMPENSATION_TO_FINISH = 1f;
        private Vector3 _currentDestination = Vector3.zero;
        private float _elapsedCollideTime = 0;


        private void Start()
        {
            SetDestination();
        }

        private void Update()
        {
            if(!IsAbleToCollide())
            {
                _elapsedCollideTime += Time.deltaTime;
            }

            if (Vector3.Distance(_currentDestination, transform.position) <= COMPENSATION_TO_FINISH)
            {
                SetDestination();
            }

            float step = _characterSettings.Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _currentDestination, step);
        }

        private void SetDestination()
        {
            _currentDestination = ServiceLocator.s_instance.Get<CharacterMovementService>().GetDestination();
            transform.LookAt(_currentDestination);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(IsAbleToCollide())
            {
                if (other.TryGetComponent(out CharacterBase collidedCharacter))
                {
                    ServiceLocator.s_instance.Get<CharacterCollisionService>().OnCharacterCollide(this, collidedCharacter);
                    _elapsedCollideTime = 0;
                }
            }

        }

        private bool IsAbleToCollide()
        {
            return _elapsedCollideTime >= _characterSettings.DelayToCollide;
        }
    }
}