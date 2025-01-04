using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;
    PlayerInput playerInput;
    HealthComponent healthComponent;
    bool death = false;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
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
        if(playerInput.MoveInput != Vector2.zero)
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