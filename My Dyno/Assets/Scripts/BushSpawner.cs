using System.Collections;
using UnityEngine;

public class BushSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] bushes;
    [SerializeField]
    private float spawnInterval = 1f;
    [SerializeField]
    private float bushSpeed = 10f;

    private void Start()
    {
        StartCoroutine(SpawnBushesRoutine());
    }

    private IEnumerator SpawnBushesRoutine()
    {
        int randomIndex = GetRandomIndex();

        yield return new WaitForSeconds(spawnInterval);

        SpawnBush(bushes[randomIndex]);

        StartCoroutine(SpawnBushesRoutine());
    
    }

    private int GetRandomIndex()
    {
        return Random.Range(0, bushes.Length);
    }

    private void SpawnBush(GameObject bush)
    {
        Vector3 spawnPosition = transform.position;

        GameObject newBush = Instantiate(bush, spawnPosition, Quaternion.identity);
    
        Rigidbody2D bushRb = newBush.GetComponent<Rigidbody2D>();

        bushRb.AddForce(Vector2.left * bushSpeed, ForceMode2D.Impulse);
    
    }
}
