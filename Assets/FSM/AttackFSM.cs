using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace AttackState
{
    public enum AttackEnum
    {
        Null,
        attack1,
        attack2,
        attack3,
    } 
    public interface ISkill
    {
        void Enter(Attack attack);
        void Stay();
        void Exit();
    }
    public class AttackFSM
    {
        private AttackEnum nowAttack;
        public readonly Dictionary<AttackEnum, ISkill> attackTransform = new ();
        public AttackFSM()
        {
            nowAttack = AttackEnum.Null;
            attackTransform.Add(AttackEnum.attack1,new Attack1());
            attackTransform.Add(AttackEnum.attack2 ,new Attack2());
            attackTransform.Add(AttackEnum.attack3,new Attack3());
        }
        public void AttackChange(AttackEnum attackEnum,Attack attacker)
        {
            if (nowAttack == attackEnum) return;
            if (!(nowAttack == AttackEnum.Null))
            {
                if (attackTransform.TryGetValue(nowAttack, out var attac))
                {
                    attac.Exit();
                }
            }
            nowAttack=attackEnum;
            if(attackTransform.TryGetValue(nowAttack, out var attack))
            {
                attack.Enter(attacker);
            }
        }
        public void AttackStay()
        {
            if (!(nowAttack == AttackEnum.Null))
            {
                if (attackTransform.TryGetValue(nowAttack, out var attac))
                {
                    attac.Stay();
                }
            }
        }
        public void AnimationExit(AttackEnum attackEnum)
        {
            if (nowAttack != attackEnum) return;//防止越权执行推出，技能变滚木-
            if (attackTransform.TryGetValue(nowAttack, out var attac))
            {
                attac.Exit();
                nowAttack=AttackEnum.Null;
            }
        }
    }
}

