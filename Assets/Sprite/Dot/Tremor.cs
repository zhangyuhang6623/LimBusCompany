using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tremor : Dot
{
    public Tremor()
    {
        maxDotLenel = 40;
        dotLevel = 0;
    }
    public override void DotAchive(Character character)
    {
        if (character == null) return;
        character.chaosLine=Mathf.Min(character.maxHealth,character.chaosLine+dotLevel);
        character?.EnterChoas();
    }
    public override void DotApply(int level)
    {
        dotLevel = Mathf.Min(maxDotLenel, dotLevel + level);
    }
    public override void Timer()
    {
        
    }
}
