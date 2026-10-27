using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : AttackState
{

    public override void Enter(Attack attack)
    {
        nowAttack=attack;
        nowAttack.physicalAttributs = Attributs.slash;
        nowAttack.sinsAttributs = 0;
        nowAttack.nowAttackDamage = nowAttack.AttackDamage1;
    }
    public override void LogicUpdate()
    {
        
    }

    public override void Exit()
    {

    }
}
