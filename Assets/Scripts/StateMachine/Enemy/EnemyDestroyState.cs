using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyState : EnemyBaseState
{
    public EnemyDestroyState(EnemyStateMachine stateMachine) : base(stateMachine){ }

    public override void Enter()
    {
        stateMachine.HandleDestroyEnemy();
    }

    public override void Exit(){ }

    public override void Tick(float deltaTime){ }
}
