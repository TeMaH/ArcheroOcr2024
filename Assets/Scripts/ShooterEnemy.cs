using UnityEngine;

public class ShooterEnemy : Enemy
{
    [SerializeField] private float attackCooldown = 1.5f;
    private float _lastAttackTime;
    public bool isAttack{get; private set;} = false ;
    private void Update()
    {
        PerceptionComponent perception = GetPerceptionComponent();

        if (perception.currentTarget != null)
        {
            isAttack = true;
            if (Time.time - _lastAttackTime >= attackCooldown)
            {
                Shoot(perception.currentTarget);
                _lastAttackTime = Time.time;
            }
        }
        else
        {
            isAttack = false;
        }
    }
    private void Shoot(IDamageable target)
    {
        Debug.Log($"{gameObject.name} стреляет в {target}!");
        target.TakeDamage(10);
    }
}