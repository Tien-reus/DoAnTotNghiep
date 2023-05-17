using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyAttack
{
    [field: SerializeField] public string Animations { get; private set; }
    [field: SerializeField] public int AttackDamage { get; private set; }
    public int AnimationHash()
    {
        return Animator.StringToHash(Animations);
    }
}
