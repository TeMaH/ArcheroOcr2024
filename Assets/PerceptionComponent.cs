using UnityEngine;

public class PerceptionComponent : MonoBehaviour
{
    public float detectRadius = 5f;
    public float chaseRadius = 10f;
    public LayerMask targetLayer; // Фильтр по слоям (определяет, кого искать)
    public IDamageable currentTarget;
    void Update()
    {
        if (currentTarget != null)
        {
            // Проверяем, находится ли текущая цель в радиусе преследования
            if (!IsTargetInChaseRadius(currentTarget))
            {
                currentTarget = null;
            }
        }

        if (currentTarget == null)
        {
            // Если цели нет, ищем ближайшую в радиусе обнаружения
            currentTarget = GetNearestTarget();
        }

        if (currentTarget != null)
        {
            // Допустим, здесь моб атакует цель (пример)
            currentTarget.TakeDamage(1);
        }
    }
    private bool IsTargetInChaseRadius(IDamageable target)
    {
        if (target is Component targetComponent)
        {
            float distance = Vector3.Distance(transform.position, targetComponent.transform.position);
            return distance <= chaseRadius;
        }
        return false;
    }
    protected IDamageable GetNearestTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectRadius, targetLayer);
        IDamageable nearestTarget = null;
        float minDistance = float.MaxValue;

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < minDistance)
                {
                    nearestTarget = damageable;
                    minDistance = distance;
                }
            }
        }
        return nearestTarget;
    }
}

