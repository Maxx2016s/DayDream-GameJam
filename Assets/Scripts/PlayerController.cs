using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject tearPrefab;
    public Transform firePoint;
    public float tearSpeed = 10f;
    public float fireRate = 0.3f;

    Vector2 movement;
    Vector2 lastAimDir = Vector2.down;
    float fireCooldown = 0f;

    void Update()
    {
        // WASD movement input
        movement.x = Input.GetKey(KeyCode.D) ? 1f : Input.GetKey(KeyCode.A) ? -1f : 0f;
        movement.y = Input.GetKey(KeyCode.W) ? 1f : Input.GetKey(KeyCode.S) ? -1f : 0f;
        if (movement.magnitude > 1f) movement.Normalize();

        // Arrow keys shooting input
        Vector2 aim = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow)) aim.y = 1f;
        if (Input.GetKey(KeyCode.DownArrow)) aim.y = -1f;
        if (Input.GetKey(KeyCode.LeftArrow)) aim.x = -1f;
        if (Input.GetKey(KeyCode.RightArrow)) aim.x = 1f;

        if (aim != Vector2.zero)
        {
            lastAimDir = aim.normalized;
            if (fireCooldown <= 0f)
            {
                Shoot(lastAimDir);
                fireCooldown = fireRate;
            }
        }

        if (fireCooldown > 0f) fireCooldown -= Time.deltaTime;

        // Animation (can skip if no Animator)
        if (animator != null) UpdateAnimation();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Shoot(Vector2 dir)
    {
        if (tearPrefab == null || firePoint == null) return;
        GameObject tear = Instantiate(tearPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D trb = tear.GetComponent<Rigidbody2D>();
        if (trb != null) trb.linearVelocity = dir * tearSpeed;
        Destroy(tear, 4f);
    }

    void UpdateAnimation()
    {
        string clip = "IdleDown";
        if (movement.magnitude > 0.01f)
            clip = lastAimDir.y > 0 ? "MoveDown" : lastAimDir.y < 0 ? "MoveDown" : lastAimDir.x > 0 ? "MoveRight" : "MoveLeft";
        animator.Play(clip);
    }
}
