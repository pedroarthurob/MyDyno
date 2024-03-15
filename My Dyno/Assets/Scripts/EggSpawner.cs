using System.Collections;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] eggs;
    [SerializeField]
    private float spawnInterval = 1f;
    [SerializeField]
    private float eggSpeed = 10f;

    private void Start()
    {
        StartCoroutine(SpawnEggRoutine());
    }

    private IEnumerator SpawnEggRoutine()
    {
        int randomIndex = GetRandomIndex();

        yield return new WaitForSeconds(spawnInterval);

        SpawnEgg(eggs[randomIndex]);

        StartCoroutine(SpawnEggRoutine());
    }

    private int GetRandomIndex()
    {
        return Random.Range(0, eggs.Length);
    }

    private void SpawnEgg(GameObject egg)
    {
        Vector3 spawnPosition = transform.position;

        GameObject newEgg = Instantiate(egg, spawnPosition, Quaternion.identity);
        
        Rigidbody2D eggRb = newEgg.GetComponent<Rigidbody2D>();

        eggRb.AddForce(Vector2.left * eggSpeed, ForceMode2D.Impulse);
    }
}
