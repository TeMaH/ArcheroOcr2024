using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float speed = 3.0f;
    [SerializeField] public float damage { get; private set; } = 1f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Launch<T>(T data)
    {
        Vector3 point = Vector3.zero;

        if (data is Transform transformData)
        {
            point = transformData.position;
        }
        else if (data is Vector3 vector3Data)
        {
            point = vector3Data;
        }
        else
        {
            Debug.LogError("Unknown type of data");
        }

        rb.linearVelocity = point * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}

