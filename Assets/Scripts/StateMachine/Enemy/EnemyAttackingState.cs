using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackingState : EnemyBaseState
{
    private const float TransitionDuration = 0.1f;

    public EnemyAttackingState(EnemyStateMachine stateMachine) : base(stateMachine) { }
    public override void Enter()
    {
        if (stateMachine.AttackAnimation.Length == 0) return;
        int randomIndex = Random.Range(0, stateMachine.AttackAnimation.Length);
        int AttackHash = stateMachine.AttackAnimation[randomIndex].AnimationHash();

        stateMachine.Weapon.SetAttack(stateMachine.AttackAnimation[randomIndex].AttackDamage,
            stateMachine.AttackKnockback);

        stateMachine.Animator.CrossFadeInFixedTime(AttackHash, TransitionDuration);
    }

    public override void Exit()
    {
        
    }

    public override void Tick(float deltaTime)
    {
        if (GetNormalizedTime(stateMachine.Animator) >= 1)
        {
            stateMachine.SwitchState(new EnemyChasingState(stateMachine));
        }
    }
}
