using UnityEngine;

public class Tear : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<EnemyTest>();
            if (enemy != null) enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
