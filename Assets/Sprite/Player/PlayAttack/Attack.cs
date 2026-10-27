using UnityEngine;

public class Attack : MonoBehaviour
{
    public InputSystem inputSystem;
    [Header("技能转换")]
    public AttackState currentState;
    private Attack1 attack1;
    private Attack2 attack2;
    private Attack3 attack3;
    [Header("技能属性")]
    public Attributs physicalAttributs;
    public Attributs sinsAttributs;
    [Header("技能基础攻击力")]
    public float nowAttackDamage;
    public float AttackDamage1;
    public float AttackDamage2;
    public float AttackDamage3;
    [Header("组件")] 
    public DotManage dotManage;
    public Character character;
    private void Awake()
    {
        inputSystem = new InputSystem();
        character = GetComponent<Character>();
        dotManage = GetComponent<DotManage>();
        attack1 = new Attack1();
        attack2 = new Attack2();
        attack3 = new Attack3();
        if (inputSystem != null)
        {
            inputSystem.Player.Attack1.started += ctx => ChangeState(attack1);
            inputSystem.Player.Attack2.started += ctx => ChangeState(attack2);
            inputSystem.Player.Attack3.started += ctx => ChangeState(attack3);
        }
    }
    private void OnEnable()
    {
        inputSystem.Enable();
    }
    private void OnDisable()
    {
        
        inputSystem.Disable();
    }
    public void ChangeState(AttackState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter(this);
        if (dotManage == null || character == null) return;
        dotManage.bleed.DotAchive(character);
    }

    private void Update()
    {
        currentState?.LogicUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var a = collision.GetComponent<Character>();

        // [修复B] 目标可能没有 Character 或 DotManage，先判空再访问
        if (a == null) return;

        a.FirstFactorCalculation(this);
        a.TakeDamage(this);

        if (a.dotManage != null)
        {
            a.dotManage.ruptur.DotAchive(a);
        }
    }
}
