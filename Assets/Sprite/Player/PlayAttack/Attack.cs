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
    [Header("受伤相关")]
    public float time=1f;
    public bool isHurt=false;

    private void Awake()
    {
        inputSystem = GetComponent<InputSystem>();
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
    public void ChangeState(AttackState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter(this);
    }

    private void Update()
    {
        currentState?.LogicUpdate();
        WaitTime();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isHurt) return;
        collision.GetComponent<Character>()?.TakeDamage(this);
        isHurt = true;
    }
    private void WaitTime()
    {
        if (isHurt)
        {
            time-= Time.deltaTime;
            if (time < 0) {
             isHurt = false;
                time = 1f;
            }
        }
    }
}
