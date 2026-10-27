using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Burns : Dot
{
    public Burns()
    {
        maxDotLenel = 3;
        dotLevel = 0;
        dotDuration = 10;
        dotHurt = 10;
        dotTimeInterval = 1;
    } 
    public override void DotAchive(Character character)
    {
        if(character==null)return;
        if (dotTimeInterval <= 0)
        {
            character.nowHealth = Mathf.Max(0,character.nowHealth-dotHurt*dotLevel);
            character.HealthChange?.Invoke(character);
            character.EnterChoas();
            dotTimeInterval = 1;
        }
    }

    public override void DotApply(int level)
    {
        dotLevel = Mathf.Min(maxDotLenel,dotLevel+level);
        dotDuration = 10;
    }
    public override void Timer()
    {
        dotTimeInterval-=Time.deltaTime;
        dotDuration -= Time.deltaTime;
        if(dotDuration <= 0)
        {
            dotDuration = 10;
            dotLevel=0;
        }
    }
}
