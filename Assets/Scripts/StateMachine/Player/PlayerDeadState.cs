using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    public PlayerDeadState(PlayerStateMachine stateMachine) : base(stateMachine){ }

    public override void Enter()
    {
        stateMachine.Ragdoll.ToggleRagdoll(true);
        stateMachine.Weapon.gameObject.SetActive(false);
        stateMachine.YouDie.SetActive(true);
    }

    public override void Exit()
    {
        
    }

    public override void Tick(float deltaTime)
    {
        
    }
}
