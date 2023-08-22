using Fortis.Character;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Fortis.Services.Character
{
    public class CharacterInstantiatorService : GameServiceBase
    {
        public CharacterBase InstantiateCharacter(CharacterBase prefab, Vector3 position)
        {
            CharacterBase newCharacter = Instantiate(prefab, position, Quaternion.identity);

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