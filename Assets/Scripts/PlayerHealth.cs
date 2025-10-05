using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    void Start() { currentHealth = maxHealth; }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        Debug.Log("Player damaged! HP: " + currentHealth);
        if (currentHealth <= 0) Die();
    }

    void Die()
    {
        Debug.Log("Player died!");
        gameObject.SetActive(false);
    }
}
