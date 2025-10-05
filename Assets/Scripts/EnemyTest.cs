using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    public int hp = 2;

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        Debug.Log($"{gameObject.name} HP: {hp}");
        if (hp <= 0) Destroy(gameObject);
    }
}
