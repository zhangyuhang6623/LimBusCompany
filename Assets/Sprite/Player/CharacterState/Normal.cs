using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal : CharacterState
{
    public override void Enter(Character character)
    {
        nowState = character;
        nowState.firstFactor=nowState.factor1;
    }
    public override void LogicUpdate()
    {
        
    }
    public override void Exit()
    {
        
    }
}
