using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstacles;
    [SerializeField]
    private float spawnInterval;
    [SerializeField]
    private float obstacleSpeed = 7f;

    private void Start()
    {
        StartCoroutine(SpawnObstaclesRoutine());
    }

    private IEnumerator SpawnObstaclesRoutine()
    {
        GetRandomSpawnInterval();
        yield return new WaitForSeconds(spawnInterval);
        int index = GetRandomIndex();
        SpawnObstacle(obstacles[index]);
        StartCoroutine(SpawnObstaclesRoutine());
    }

    private int GetRandomIndex()
    {
        return Random.Range(0, obstacles.Length);
    }

    private void GetRandomSpawnInterval()
    {
        spawnInterval = Random.Range(1, 3);
    }

    private void SpawnObstacle(GameObject obstacle)
    {
        Vector3 spawnPosition = transform.position;
        GameObject newObstacle = Instantiate(obstacle, spawnPosition, Quaternion.identity);
        Rigidbody2D obstacleRb = newObstacle.GetComponent<Rigidbody2D>();
        obstacleRb.AddForce(Vector2.left * obstacleSpeed, ForceMode2D.Impulse);
    }
}
