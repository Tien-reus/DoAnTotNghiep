using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponDamage : MonoBehaviour
{
    [SerializeField] private Collider myCollider;

    private List<Collider> alreadyCollideWith = new List<Collider>();
    private int damage;
    private float knockback;
    private void OnEnable()
    {
        alreadyCollideWith.Clear();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == myCollider) return;
        if (alreadyCollideWith.Contains(other)) return;

        alreadyCollideWith.Add(other);

        if(other.TryGetComponent<EnemyHealth>(out EnemyHealth health))
        {
            health.DealDamage(damage);
        }
        if(other.TryGetComponent<ForceReceiver>(out ForceReceiver forceReceiver))
        {
            Vector3 direction = (other.transform.position -
                myCollider.transform.position).normalized;
            forceReceiver.AddForce(direction * knockback);
        }
    }
    public void SetAttack(int damage, float knockback)
    {
        this.damage = damage;
        this.knockback = knockback;
    }
}
