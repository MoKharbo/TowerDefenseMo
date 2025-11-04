using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    private float maxRange;
    private Vector2 spawnPosition;
    private Rigidbody2D rb;
    private GameObject target;

    public void SetTarget(GameObject newTarget, float range)
    {
        target = newTarget;
        maxRange = range;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnPosition = transform.position;

        if (target != null)
        {
            Vector2 moveDirection = ((Vector2)target.transform.position - (Vector2)transform.position).normalized * moveSpeed;
            rb.linearVelocity = moveDirection;
        }
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.x - spawnPosition.x) > maxRange ||
            Mathf.Abs(transform.position.y - spawnPosition.y) > maxRange)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
