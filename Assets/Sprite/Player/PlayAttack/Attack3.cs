using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack3 : AttackState
{
    public override void Enter(Attack attack)
    {
        nowAttack = attack;
        nowAttack.physicalAttributs = (Attributs)2;
        nowAttack.sinsAttributs = (Attributs)2;
        nowAttack.nowAttackDamage = nowAttack.AttackDamage3;
    }
    public override void LogicUpdate()
    {
        
    }

    public override void Exit()
    {

    }
}
