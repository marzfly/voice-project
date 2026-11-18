
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    public float stoppingDistance = 0.5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player == null)
        {
            return;
        }

        float distance = Mathf.Abs(player.position.x - transform.position.x);

        if (distance <= stoppingDistance)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            return;
        }

        float direction = Mathf.Sign(player.position.x - transform.position.x);

        if (direction > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direction < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        rb.velocity = new Vector2(
            direction * speed,
            rb.velocity.y
        );
    }
}
