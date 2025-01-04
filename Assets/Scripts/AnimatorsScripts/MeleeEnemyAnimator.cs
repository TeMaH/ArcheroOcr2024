using UnityEngine;

public class MeleeEnemyAnimator : MonoBehaviour
{
    Animator animator;
    EnemyMovement enemyMovement;
    HealthComponent healthComponent;
    bool death = false;

    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
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
            animator.SetBool("Attack", false);
        }
        else
        {
            animator.SetBool("Movement", false);
            animator.SetBool("Attack", true);
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
