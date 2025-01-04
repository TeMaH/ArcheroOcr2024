using UnityEngine;

public class StaticEnemyAnimator : MonoBehaviour
{
    Animator animator;
    ShooterEnemy shooterEnemy;
    HealthComponent healthComponent;
    bool death = false;

    void Start()
    {
        shooterEnemy = GetComponent<ShooterEnemy>();
        animator = GetComponent<Animator>();
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.death += TriggerDeath;
    }

    private void TriggerDeath()
    {
        death = true;
    }

    void Update ()
    {
        if(shooterEnemy.isAttack) 
        {
            animator.SetBool("Attack", true);
        }
        else
        {
            animator.SetBool("Attack", false);
        }

        if(death)
        {
            animator.SetTrigger("Death");
        }
    }

    void OnDisable()
    {
        healthComponent.death -= TriggerDeath;
    }
}
