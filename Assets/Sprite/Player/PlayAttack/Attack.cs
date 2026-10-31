using UnityEngine;
using UnityEngine.InputSystem;
using AttackState;
using System;
using System.Collections.Generic;

public class Attack : MonoBehaviour
{
    public AttackFSM fsm;
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
    private Dictionary<InputAction, Action<InputAction.CallbackContext>> _action = new();
    private void Awake()
    {
        character = GetComponent<Character>();
        dotManage = GetComponent<DotManage>();
    }
    private void OnEnable()
    {
        var player=InputDetection.inputDetection.Player;
        Blnd(player.Attack1,AttackEnum.attack1);
        Blnd(player.Attack2,AttackEnum.attack2);
        Blnd (player.Attack3,AttackEnum.attack3);
    }
    private void Blnd(InputAction action,AttackEnum attack)
    {
        Action<InputAction.CallbackContext> callback = ctx => fsm.AttackChange(attack, this);
        _action.Add(action, callback);
        action.started += callback;
    }
    private void OnDisable()
    {
        var player = InputDetection.inputDetection.Player;
        player.Attack1.started -= _action[player.Attack1];
        player.Attack2.started -= _action[player.Attack2];
        player.Attack3.started -= _action[player.Attack3];  
        _action.Clear();
    }
   

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Other"))
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
            dotManage.burns.DotApply(1);
        }
    }
   
}
