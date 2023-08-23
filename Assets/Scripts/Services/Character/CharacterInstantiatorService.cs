using Fortis.Character;
using System.Collections.Generic;
using UnityEngine;

namespace Fortis.Services.Character
{
    public class CharacterInstantiatorService : GameServiceBase
    {
        public List<CharacterBase> CharacterBases { get; private set; } = new List<CharacterBase>();

        public CharacterBase InstantiateCharacter(CharacterBase reference, Vector3 position)
        {
            CharacterBase newCharacter = GetCharacterFromPooling(reference);
            newCharacter.transform.position = position;
            newCharacter.transform.rotation = Quaternion.identity;
            newCharacter.OnStart();
            newCharacter.gameObject.SetActive(true);

            return newCharacter;
        }

        public int GetCharactersQuantity(CharacterBase reference)
        {
            int charactersQuantity = 0;

            foreach (CharacterBase character in CharacterBases)
            {
                if (character.GetType() == reference.GetType())
                {
                    charactersQuantity++;
                }
            }

            return Mathf.Max(1, charactersQuantity);
        }

        private CharacterBase GetCharacterFromPooling(CharacterBase reference)
        {
            foreach (CharacterBase character in CharacterBases)
            {
                if(!character.gameObject.activeSelf && character.GetType() == reference.GetType())
                {
                    return character;
                }
            }

            CharacterBase newCharacter = Instantiate(reference);
            CharacterBases.Add(newCharacter);

            return newCharacter;
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