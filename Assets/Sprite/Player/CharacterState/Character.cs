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
    public bool isChaos=false;
    private CharacterState characterState;
    private Chaos chaos;
    private Normal normal;
    [Header("伤害乘区")]
    public float firstFactor;//第一伤害乘区
    public float factor1;
    [Header("事件设置")]
    public UnityEvent<Character> HealthChange;
    [Header("组件获取")]
    public DotManage dotManage;
    private void Awake()
    {
        dotManage = GetComponent<DotManage>();
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
        if (dotManage != null)
        {
            dotManage.burns.DotAchive(this);
        }
    }
    public void TakeDamage(Attack attacker)
    {
        float damageSum = DamageSum(attacker);
        if (nowHealth - damageSum > 0)
        {
            nowHealth -= damageSum;
        }
        else
        {
            nowHealth = 0;
        }
        EnterChoas();
        HealthChange?.Invoke(this);
    }
    public float DamageSum(Attack attack)
    {
        // [修复A] 原来读 firstFactor，但乘区只写进 factor1，开局 firstFactor 恒为 0
        factor1 = 1 + AttributsFactor(attack.sinsAttributs) + AttributsFactor(attack.physicalAttributs);
        firstFactor = factor1;
        float damageSum = attack.nowAttackDamage * firstFactor;
        return damageSum;
    }

    public void EnterChoas()
    {
        if (nowHealth < chaosLine && !isChaos)
        {
            characterState?.Exit();
            characterState = chaos;
            characterState?.Enter(this);
        }
    }
    //混乱时间计时器
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
    //抗性计算函数
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
    //第一乘区计算
    public void FirstFactorCalculation(Attack attacker)
    {
       factor1 = 1 + AttributsFactor(attacker.sinsAttributs) + AttributsFactor(attacker.physicalAttributs);

    }
}
