using System;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private HealthComponent healthComponent;
    [SerializeField] private MovementComponent movementComponent;
    [SerializeField] private PerceptionComponent perceptionComponent;

    private HealthComponent HealthComponent
    {
        get { return healthComponent = healthComponent ? healthComponent : GetComponent<HealthComponent>(); }
    }

    private MovementComponent MovementComponent
    {
        get { return movementComponent = movementComponent ? movementComponent : GetComponent<MovementComponent>(); }
    }

    private PerceptionComponent PerceptionComponent
    {
        get { return perceptionComponent = perceptionComponent ? perceptionComponent : GetComponent<PerceptionComponent>(); }
    }
    

    protected virtual void Start()
    {
        HealthComponent.SetHealth(health);
    }

    public HealthComponent GetHealthComponent() => HealthComponent;

    public MovementComponent GetMovementComponent() => MovementComponent;

    public PerceptionComponent GetPerceptionComponent() => PerceptionComponent;

}