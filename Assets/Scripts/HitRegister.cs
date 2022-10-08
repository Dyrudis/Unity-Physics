using UnityEngine;

public class HitRegister : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is an enemy
        if (collision.gameObject.tag == "Enemy")
        {
            // Destroy the enemy
            Destroy(collision.gameObject);
        }
    }
}
