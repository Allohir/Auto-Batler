using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedAttackCharacter : Character
{
    protected override void Attack()
    {
        Batler.CalculateAttackResult(this, enemy);
    }
}
