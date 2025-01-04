using UnityEngine;

public class ShooterEnemy : Enemy
{
    [SerializeField] private float attackCooldown = 1.5f;
    private float _lastAttackTime;
    private void Update()
    {
        PerceptionComponent perception = GetPerceptionComponent();

        if (perception.currentTarget != null)
        {
            if (Time.time - _lastAttackTime >= attackCooldown)
            {
                Shoot(perception.currentTarget);
                _lastAttackTime = Time.time;
            }
        }
    }
    private void Shoot(IDamageable target)
    {
        Debug.Log($"{gameObject.name} стреляет в {target}!");
        target.TakeDamage(10);
    }
}