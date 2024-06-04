using System.Collections;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] clouds;
    [SerializeField]
    private float spawnInterval;
    [SerializeField]
    private float cloudSpeed;

    private void Start()
    {
        int randomIndex = GetRandomIndex();
        SpawnCloud(clouds[randomIndex]);
        StartCoroutine(SpawnCloudsRoutine());
    }


    private IEnumerator SpawnCloudsRoutine()
    {
        int randomIndex = GetRandomIndex();

        yield return new WaitForSeconds(spawnInterval);

        SpawnCloud(clouds[randomIndex]);

        StartCoroutine(SpawnCloudsRoutine());

    }

    private int GetRandomIndex()
    {
        return Random.Range(0, clouds.Length);
    }

    private void SpawnCloud(GameObject cloud)
    {   
        Vector3 spawnPosition = transform.position;

        spawnPosition.y = Random.Range(spawnPosition.y-1f, spawnPosition.y + 1f);

        GameObject newCloud = Instantiate(cloud, spawnPosition, Quaternion.identity);

        Rigidbody2D cloudRb = newCloud.GetComponent<Rigidbody2D>();

        cloudRb.AddForce(Vector2.left * cloudSpeed, ForceMode2D.Impulse);
    }


}
