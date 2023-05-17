using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{
    private float previousFrameTime;
    private bool alreadyAppliedForce;

    private Attack attack;
    public PlayerAttackingState(PlayerStateMachine stateMachine, int id) : base(stateMachine) 
    {
        attack = stateMachine.Attacks[id];
    }

    public override void Enter()
    {
        stateMachine.Weapon.SetAttack(attack.Damage, attack.knockback);
        stateMachine.Animator.CrossFadeInFixedTime(attack.Animations, attack.TransitionDuration);
    }

    public override void Exit()
    {
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        float normalizedTime = GetNormalizedTime(stateMachine.Animator);

        if(normalizedTime >= previousFrameTime && normalizedTime < 1f)
        {
            if(normalizedTime >= attack.ForceTime)
            {
                TryApplyForce();
            }
            if(stateMachine.InputReader.IsAttacking)
            {
                TryComboAttack(normalizedTime);
            }
        }
        else
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
        }
        previousFrameTime = normalizedTime;
    }

    private void TryApplyForce()
    {
        if(alreadyAppliedForce) { return; }

        stateMachine.ForceReceiver.AddForce(stateMachine.transform.forward * attack.Force);
        alreadyAppliedForce = true;
    }

    private void TryComboAttack(float normalizedTime)
    {
        if (attack.ComboStateIndex == -1) return;
        if (normalizedTime < attack.ComboAttackTime) return;

        stateMachine.SwitchState
        (
            new PlayerAttackingState(stateMachine, attack.ComboStateIndex)
        );
    }

    private void OnCancel()
    {
        stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
    }
}
