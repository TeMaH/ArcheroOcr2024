using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField] private float attackRange = 7f;
    [SerializeField] private float attackCooldown = 1.5f;
    [SerializeField] private int damage = 5;
    private float _lastAttackTime;
    public bool isAttack{get; private set;} = false ;
    private void Update()
    {
        PerceptionComponent perception = GetPerceptionComponent();

        if (perception.currentTarget != null)
        {
            isAttack = true;
            if (perception.currentTarget is Component targetComponent)
            {
                float distance = Vector3.Distance(transform.position, targetComponent.transform.position);

                if (distance <= attackRange)
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
        else
        {
            isAttack = false;
        }
    }
    private void Attack(IDamageable target)
    {
        Debug.Log($"{gameObject.name} атакует издалека {target}!");
        target.TakeDamage(damage);
    }
}