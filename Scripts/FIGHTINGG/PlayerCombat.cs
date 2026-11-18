using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject flashPrefab;
    public Transform firePoint;

    void Shoot()
    {
        GameObject flash = Instantiate(
            flashPrefab,
            firePoint.position,
            firePoint.rotation
        );
        float direction = transform.localScale.x;
        flash.GetComponent<FlashProjectile>().direction = direction;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }
}