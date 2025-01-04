using UnityEngine;
using System.Collections;

public class DamageComponent : MonoBehaviour
{
    public float damage = 10f; 
    public float damageInterval = 1f; 
    public bool isPeriod = false; 
    public bool destroyAfterDamage = true; 
    public LayerMask targetLayer;
    private Coroutine damageCoroutine;
    private void OnTriggerEnter(Collider other)
    {
        if (IsTargetValid(other.gameObject))
        {
            if (isPeriod)
            {
                damageCoroutine = StartCoroutine(ApplyPeriodicDamage(other.gameObject));
            }
            else
            {
                ApplyDamage(other.gameObject);
                if (destroyAfterDamage)
                {
                    Destroy(gameObject); 
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (damageCoroutine != null && IsTargetValid(other.gameObject))
        {
            StopCoroutine(damageCoroutine); 
        }
    }

    private bool IsTargetValid(GameObject target)
    {
        return ((1 << target.layer) & targetLayer) != 0;
    }

    private void ApplyDamage(GameObject target)
    {
        IDamageable damageable = target.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
            Debug.Log($"{gameObject.name} нанес {damage} урона объекту {target.name} через IDamageable");
        }
        else
        {
            Debug.LogWarning($"{target.name} не поддерживает обработку урона через IDamageable!");
        }
    }
    private IEnumerator ApplyPeriodicDamage(GameObject target)
    {
        while (true)
        {
            ApplyDamage(target);
            yield return new WaitForSeconds(damageInterval);
        }
    }
}
