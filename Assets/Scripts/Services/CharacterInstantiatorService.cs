using Fortis.Character;
using UnityEngine;

namespace Fortis.Services
{
    public class CharacterInstantiatorService : GameServiceBase
    {
        public CharacterBase InstantiateCharacter(CharacterBase prefab, Vector3 position)
        {
            CharacterBase newCharacter = Instantiate(prefab, position, Quaternion.identity);

            return newCharacter;
        }
    }
}