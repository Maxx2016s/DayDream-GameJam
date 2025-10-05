using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector2 dir = Vector2.right;
    private Rigidbody2D rb;

    public GameObject humanPrefab; // optional

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + dir * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Reverse on walls
        if (collision.gameObject.CompareTag("Wall"))
            dir *= -1;

        // Damage player
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth ph = collision.gameObject.GetComponent<PlayerHealth>();
            if (ph != null)
                ph.TakeDamage(1);
        }
    }

    public void Die()
    {
        Debug.Log("Enemy died: " + gameObject.name);

        if (humanPrefab != null)
            Instantiate(humanPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
