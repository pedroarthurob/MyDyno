using System.Collections;
using UnityEngine;

public class FossilSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] fossils;
    [SerializeField]
    private float spawnInterval = 1f;
    [SerializeField]
    private float fossilSpeed = 10f;

    private void Start()
    {
        StartCoroutine(SpawnFossilsRoutine());
    }
    
    private IEnumerator SpawnFossilsRoutine()
    {
        int randomIndex = GetRandomIndex();

        yield return new WaitForSeconds(spawnInterval);

        SpawnFossil(fossils[randomIndex]);
           
        StartCoroutine(SpawnFossilsRoutine());

    }
    private int GetRandomIndex()
    {
        return Random.Range(0, fossils.Length);
    }

    private void SpawnFossil(GameObject fossil)
    {
        Vector3 spawnPosition = transform.position;

        GameObject newFossil = Instantiate(fossil, spawnPosition, Quaternion.identity);

        Rigidbody2D fossilRb = newFossil.GetComponent<Rigidbody2D>();

        fossilRb.AddForce(Vector2.left * fossilSpeed, ForceMode2D.Impulse);
    }
}
