using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyBaseState
{
    private readonly int DeadHash = Animator.StringToHash("Dead");
    private const float CrossFadeDuration = 0.1f;
    public EnemyDeadState(EnemyStateMachine stateMachine) : base(stateMachine){ }

    public override void Enter()
    {
        stateMachine.Ragdoll.ToggleRagdoll(true);
        stateMachine.Weapon.gameObject.SetActive(false);
        stateMachine.Animator.CrossFadeInFixedTime(DeadHash, CrossFadeDuration);
    }

    public override void Exit()
    {
        
    }

    public override void Tick(float deltaTime)
    {
            stateMachine.SwitchState(new EnemyDestroyState(stateMachine));      
    }
}
