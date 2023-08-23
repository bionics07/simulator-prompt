using Fortis.Character;

namespace Fortis.Services.Character
{
    public class CharacterCollisionService : GameServiceBase
    {
        public void OnCharacterCollide(CharacterBase characterOne, CharacterBase characterTwo, bool isAbleMultiplier)
        {
            bool isSameType = characterOne.GetType() == characterTwo.GetType();

            if (isSameType && isAbleMultiplier)
            {
                ServiceLocator.s_instance.Get<CharacterInstantiatorService>().InstantiateCharacter(characterOne, characterOne.transform.position);
                characterOne.UpdateCurrentDelayToDuplicate();
                characterTwo.UpdateCurrentDelayToDuplicate();
            }
            else if(!isSameType)
            {
                characterOne.gameObject.SetActive(false);
                characterTwo.gameObject.SetActive(false);
            }
        }

        public bool CollisionWithSameType(CharacterBase characterOne, CharacterBase characterTwo)
        {
            return characterOne.GetType() == characterTwo.GetType();
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