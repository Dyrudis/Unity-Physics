using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    private List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
        // Start the coroutine
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Get a random position in the map
            Vector3 randomPosition = new Vector3(Random.Range(-23, 23), 20, Random.Range(-23, 23));

            // Get the height at that position with a raycast
            RaycastHit hit;
            Physics.Raycast(randomPosition, Vector3.down, out hit);
            randomPosition.y = hit.point.y + 1.3f;
            

            // Get a random rotation
            Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

            // Create the enemy at the random position
            var enemy = Instantiate(
                enemyPrefab,
                randomPosition,
                randomRotation);

            //yield return new WaitForSeconds(0f);
            
            // Continue if there are less than 10 enemies
            yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("Enemy").Length < 10);
        }
    }
}
