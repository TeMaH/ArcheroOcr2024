using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private int damage = 15;
    private float _lastAttackTime;
    private void Update()
    {
        PerceptionComponent perception = GetPerceptionComponent();

        if (perception.currentTarget != null)
        {
            if (perception.currentTarget is Component targetComponent)
            {
                float distance = Vector3.Distance(transform.position, targetComponent.transform.position);
                float adjustedAttackRange = attackRange * 0.75f; //коэффициент 

                if (distance <= adjustedAttackRange)
                {
                    if (Time.time - _lastAttackTime >= attackCooldown)
                    {
                        Attack(perception.currentTarget);
                        _lastAttackTime = Time.time;
                    }
                }
                else
                {
                    Vector3 direction = (targetComponent.transform.position - transform.position).normalized;
                    GetMovementComponent().Move(direction);
                }
            }
        }
    }
    private void Attack(IDamageable target)
    {
        Debug.Log($"{gameObject.name} наносит удар по {target}!");
        target.TakeDamage(damage);
    }
}