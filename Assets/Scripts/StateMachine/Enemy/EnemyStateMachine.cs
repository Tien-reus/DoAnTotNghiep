using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : StateMachine
{
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public EnemyWeaponDamage Weapon { get; private set; }
    [field: SerializeField] public NavMeshAgent Agent { get; private set; }
    [field: SerializeField] public float MovementSpeed { get; private set; }
    [field: SerializeField] public float PlayerChasingRange { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; }
    [field: SerializeField] public float AttackKnockback { get; private set; }
    [field: SerializeField] public EnemyHealth Health { get; private set; }
    [field: SerializeField] public GameObject GameObject { get; private set; }
    [field: SerializeField] public bool UseImpact { get; private set; }
    [field: SerializeField] public EnemyAttack[] AttackAnimation { get; private set; }
    [field: SerializeField] public Ragdoll Ragdoll { get; private set; }

    public GameObject Player { get; private set; }
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        Agent.updatePosition = false;
        Agent.updateRotation = false;

        SwitchState(new EnemyIdleState(this));
    }

    private void OnEnable()
    {
        Health.OnTakeDamage += HandleTakeDamage;
        Health.OnDie += HandleDie;
    }

    private void OnDisable()
    {
        Health.OnTakeDamage -= HandleTakeDamage;
        Health.OnDie -= HandleDie;
    }

    private void HandleTakeDamage()
    {
        if(!UseImpact) return;
        SwitchState(new EnemyImpactState(this));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, PlayerChasingRange);
    }
    private void HandleDie()
    {
        SwitchState(new EnemyDeadState(this));
    }

    public void HandleDestroyEnemy()
    {
        Destroy(GameObject, 4f);
    }
}
