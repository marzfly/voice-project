using UnityEngine;

public class FlashProjectile : MonoBehaviour
{
    public float speed = 10f;
    public float direction;

    void Start()
    {
        Destroy(gameObject, 4f);
    }

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Boss"))
    {
        BossHealth bossHealth = other.GetComponent<BossHealth>();

        if(bossHealth != null){
            bossHealth.TakeDamage(1);
        }

        Destroy(gameObject);
    }
}

}