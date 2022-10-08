using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    void Start()
    {
        // Start the coroutine
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies() {
        while (true) {
            // Get a random position in the map
            Vector3 randomPosition = new Vector3(Random.Range(-20, 20), 2, Random.Range(-20, 20));

            // Check if the position is empty
            if (Physics.CheckSphere(randomPosition, 1f)) {
                yield return new WaitForSeconds(.1f);
            }
            
            // Get a random rotation
            Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

            // Create the enemy at the random position
            var enemy = Instantiate(
                enemyPrefab,
                randomPosition,
                randomRotation);

            yield return new WaitForSeconds(.1f);
        }
    }
}
