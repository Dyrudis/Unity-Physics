using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private AudioClip shotSound;

    void Start()
    {
        // Start the coroutine
        StartCoroutine(ShootCoroutine());
    }

    private IEnumerator ShootCoroutine()
    {
        while (true)
        {
            // Wait for the input
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            // Shoot the bullet
            Shoot();

            // Wait for .5 second
            yield return new WaitForSeconds(.5f);
        }
    }

    private void Shoot()
    {
        // Play the shoot sound
        AudioSource.PlayClipAtPoint(shotSound, transform.position);
        
        // Create the bullet from the bullet prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation * Quaternion.Euler(0, 0, 90));

        // Add velocity to the bullet towards the center of the screen
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * bulletSpeed;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);

        // Play the shoot animation
        gunAnimator.Play("Gun Shot");
    }
}
