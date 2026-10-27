using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : Dot
{
    public Bleed()
    {
        maxDotLenel = 10;
        dotLevel = 0;
        dotDuration = 10;
        dotHurt = 10;
        dotTimeInterval = 0;
    }
    public override void DotAchive(Character character)
    {
        if (character == null) return;
        character.nowHealth = Mathf.Max(0, character.nowHealth - dotHurt * dotLevel);
        character.HealthChange?.Invoke(character);
        character?.EnterChoas();
    }

    public override void DotApply(int level)
    {
        dotLevel = Mathf.Min(maxDotLenel, dotLevel + level);
        dotDuration = 10;
    }

    public override void Timer()
    {
        dotDuration -= Time.deltaTime;
        if (dotDuration <= 0)
        {
            dotDuration = 10;
            dotLevel = 0;
        }
       
    }
}

