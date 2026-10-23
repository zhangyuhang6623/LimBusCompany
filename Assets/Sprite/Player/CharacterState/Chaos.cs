using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaos : CharacterState
{
    public override void Enter(Character character)
    {
        nowState=character;
        nowState.isChaos=true;
    }
    public override void LogicUpdate()
    {
        
    }
    public override void Exit()
    {
       nowState.isChaos=false;
    }
}
