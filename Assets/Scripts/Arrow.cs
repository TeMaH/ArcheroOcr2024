using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] PlayerInput movePlayerInput;
    [SerializeField] float speed = 3.0f;
    [SerializeField] float radius = 5f;
    [SerializeField] public float damage { get; private set; } = 1f;
    Vector3 currentposition;
    Vector3 enemyPosition = Vector3.zero;
    LayerMask enemyMask;

    void Start()
    {
        enemyMask = LayerMask.NameToLayer("Enemy");
    }

    void Update()
    {
        if (movePlayerInput.MoveInput == Vector2.zero)
        {
            currentposition = transform.position;

            Collider[] enemyAround = Physics.OverlapSphere(transform.position, radius, enemyMask);

            float closestDistance = Mathf.Infinity;

            foreach (Collider enemy in enemyAround)
            {
                float distance = Vector3.Distance(currentposition, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    enemyPosition = enemy.transform.position;
                }
            }
            Launch(speed, enemyPosition);
        }
    }

    public void Launch(float speed, Vector3 enemyPoint)
    {
        transform.LookAt(enemyPoint);
        transform.Translate(Vector3.forward * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == enemyMask)
        {
            Destroy(gameObject);
        }
    }
}

