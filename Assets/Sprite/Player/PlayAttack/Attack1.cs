using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttackState;

public class Attack1 : ISkill
{
    private Attack nowAttack;
    public void Enter(Attack attack)
    {
        nowAttack= attack;
    }
    public  void Stay()
    {
        
    }
    public void Exit()
    {
        
    }
}