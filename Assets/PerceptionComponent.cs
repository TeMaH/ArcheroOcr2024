using UnityEngine;
public class PerceptionComponent : MonoBehaviour
{
    public float detectRadius = 5f; 
    public float chaseRadius = 10f;
    private IDamageable currentTarget; 
    void Update()
    {
        if (currentTarget != null)
        {
          
            if (IsTargetInChaseRadius(currentTarget))
            {
                currentTarget.TakeDamage(1); 
            }
            else
            {
                currentTarget = null;
            }
        }
        if (currentTarget == null)
        {
            currentTarget = GetNearestTarget();
        }
    }
    private bool IsTargetInChaseRadius(IDamageable target)
    {
        // Получаем позицию цели через коллайдер
        if (target is Component targetComponent)
        {
            float distance = Vector3.Distance(transform.position, targetComponent.transform.position);
            return distance <= chaseRadius;
        }
        return false; 
    }
    public IDamageable GetNearestTarget()
    {
        // все коллайдеры в сфере радиусом detectRadius
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectRadius);
        IDamageable nearestTarget = null;
        float minDistance = float.MaxValue;
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < minDistance && distance <= detectRadius)
                {
                    nearestTarget = damageable; 
                    minDistance = distance; 
                }
            }
        }
        return nearestTarget;
    }
}
