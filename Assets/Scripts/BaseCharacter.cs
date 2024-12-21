using System;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private HealthComponent healthComponent;
    [SerializeField] private MovementComponent movementComponent;

    private HealthComponent HealthComponent
    {
        get { return healthComponent = healthComponent ? healthComponent : GetComponent<HealthComponent>(); }
    }

    private MovementComponent MovementComponent
    {
        get { return movementComponent = movementComponent ? movementComponent : GetComponent<MovementComponent>(); }
    }

    private void Start()
    {
        HealthComponent.SetHealth(health);
    }

    public HealthComponent GetHealthComponent() => HealthComponent;

    public MovementComponent GetMovementComponent() => MovementComponent;
}