using Fortis.Character;
using UnityEngine;

namespace Fortis.Services.Character
{
    public class CharacterCollisionService : GameServiceBase
    {
        public void OnCharacterCollide(CharacterBase characterOne, CharacterBase characterTwo)
        {
            if (characterOne.GetType() == characterTwo.GetType())
            {
                ServiceLocator.s_instance.Get<CharacterInstantiatorService>().InstantiateCharacter(characterOne, characterOne.transform.position);
            }
            else
            {
                Destroy(characterOne.gameObject);
                Destroy(characterTwo.gameObject);
            }
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