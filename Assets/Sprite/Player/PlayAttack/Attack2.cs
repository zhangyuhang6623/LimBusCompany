using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2 : AttackState
{
    public override void Enter(Attack attack)
    {
        nowAttack = attack;
        nowAttack.physicalAttributs = (Attributs)1;
        nowAttack.sinsAttributs = (Attributs)1;
        nowAttack.nowAttackDamage = nowAttack.AttackDamage2;
    }
    public override void LogicUpdate()
    {
     
    }

    public override void Exit()
    {

    }
}
