using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    private bool isInvulnerable = false;
    public float invulnerabilityTime = 1.5f;
    private Vector3 startPosition;
    private Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();

        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

public void TakeDamage(int damage)
{
    if (isInvulnerable)
    {
        return;
    }

    currentHealth -= damage;

    if (currentHealth <= 0)
    {
        Respawn();
    }

    StartCoroutine(Invulnerability());
}

    IEnumerator Invulnerability()
    {
        isInvulnerable = true;

        float elapsedTime = 0f;

        while (elapsedTime < invulnerabilityTime)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;

            yield return new WaitForSeconds(0.1f);

            elapsedTime += 0.1f;
        }

        spriteRenderer.enabled = true;
        isInvulnerable = false;
    }

    void Respawn()
    {
        currentHealth = maxHealth;
        transform.position = startPosition;

        rb.velocity = Vector2.zero;
    }
}