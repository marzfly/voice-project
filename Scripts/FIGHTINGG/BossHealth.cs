using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHeath <= 0)
        {
            Destroy(gameObject);
        }
    }
}