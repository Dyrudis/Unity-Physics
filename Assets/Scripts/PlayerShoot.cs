using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private float bulletSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        // When the player use LMB, the bullet will be shoot
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot() {
        // Create the bullet from the bullet prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation * Quaternion.Euler(0, 0, 90));

        // Add velocity to the bullet towards the center of the screen
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * bulletSpeed;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
}
