using Lumen.Character;

namespace Lumen.Services.Character
{
    public class CharacterCollisionService : IGameService
    {
        public void OnCharacterCollide(CharacterBase characterOne, CharacterBase characterTwo, bool isAbleDuplicate)
        {
            bool isSameType = characterOne.GetType() == characterTwo.GetType();

            if (isSameType && isAbleDuplicate)
            {
                ServiceLocator.Instance.Get<CharacterInstantiatorService>().InstantiateCharacter(characterOne, characterOne.transform.position);
                characterOne.UpdateCurrentDelayToDuplicate();
                characterTwo.UpdateCurrentDelayToDuplicate();
            }
            else if(!isSameType)
            {
                characterOne.gameObject.SetActive(false);
                characterTwo.gameObject.SetActive(false);
            }
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