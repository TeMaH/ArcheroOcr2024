using UnityEngine;

public class RangeEnemyAnimator : MonoBehaviour
{
    Animator animator;
    EnemyMovement enemyMovement;
    RangedEnemy rangedEnemy;
    HealthComponent healthComponent;
    bool death = false;

    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        rangedEnemy = GetComponent<RangedEnemy>();
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
        if(enemyMovement._moveDirection != Vector3.zero)
        {
            animator.SetBool("Movement", true);
        }
        else
        {
            animator.SetBool("Movement", false);
        }

        if(rangedEnemy.isAttack)
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
