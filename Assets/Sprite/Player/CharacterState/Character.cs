using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [Header("生命属性")]
    public float maxHealth;
    public float nowHealth;
    public float chaosLine;
    [Header("物理属性")]
    public float slashResistance;//斩击抗性
    public float strikeResistance;//打击抗性
    public float spikeResistance;//突刺抗性
    [Header("罪孽属性")]
    public float furyResistance;//暴怒抗性
    public float GluttonyResistance;//暴食抗性
    public float jealousyResistance;//嫉妒抗性
    public float lustResistance;//色欲抗性
    public float arroganceResistance;//傲慢抗性
    public float slothResistance;//怠惰抗性
    public float MelancholyResistance;//忧郁抗性

    [Header("混乱设置")]
    public float waitTime;
    public bool isChaos;
    private CharacterState characterState;
    private Chaos chaos;
    private Normal normal;
    
    public UnityEvent<Character> HealthChange;
    private void Awake()
    {
        nowHealth = maxHealth;
        chaos=new Chaos();
        normal = new Normal();
        characterState = normal;
    }
    private void OnEnable()
    {
        HealthChange?.Invoke(this);
    }
    private void Update()
    {
        characterState?.LogicUpdate();
        ChaosTime();
        HealthChange?.Invoke(this);
    }
    public void TakeDamage(Attack attacker)
    {
        var firstFactor = 1f;
        if (!isChaos)
        {
             firstFactor = 1 + AttributsFactor(attacker.physicalAttributs) + AttributsFactor(attacker.sinsAttributs);
        }
        else
        {
             firstFactor =3;
        }
        if (nowHealth - attacker.nowAttackDamage /** firstFactor*/ > 0)
        {
            nowHealth -= attacker.nowAttackDamage/* * firstFactor*/;
            
        }
        else
        {
            nowHealth = 0;
        }
         if (nowHealth < chaosLine && !isChaos)
            {
                EnterChoas();
            chaosLine = 0;
            }
    }
    public void EnterChoas()
    {
        characterState?.Exit();
        characterState = chaos;
        characterState?.Enter(this);
    }
    public void ChaosTime()
    {
        if (isChaos) {
            waitTime-=Time.deltaTime;
            if (waitTime <= 0)
            {
                characterState?.Exit();
                characterState=normal;
                characterState?.Enter(this);
                return;
            }
        }
    }
   public float AttributsFactor(Attributs attributs)
    {
        var num = attributs switch
        {
            Attributs.slash=> slashResistance,
            Attributs.strike=> strikeResistance,
            Attributs.spike=> spikeResistance,
            Attributs.fury=> furyResistance,
            Attributs.Gluttony=> GluttonyResistance,
            Attributs.jealousy=> jealousyResistance,
            Attributs.lust=> lustResistance,
            Attributs.arrogance=> arroganceResistance,
            Attributs.sloth=> slothResistance,
            Attributs.Melancholy=> MelancholyResistance,
            _ => 1f
        };
        if (num >= 1)
        {
            return num - 1;
        }
        else { 
            return (num-1)/2;
        }
    }
}
