using UnityEngine;

public class Tear : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 dir)
    {
        rb.linearVelocity = dir * speed; // set tear movement
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Tear hit: " + collision.name);

        if (collision.CompareTag("Enemy"))
        {
            EnemyTest enemy = collision.GetComponent<EnemyTest>();
            if (enemy != null)
            {
                enemy.Die(); // kills enemy
            }

            Destroy(gameObject); // destroy tear
        }
    }
}
