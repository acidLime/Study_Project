using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

    override protected void InitCharacterType()
    {
        _characterType = CharacterType.ENEMY;
    }
}
