using UnityEngine;

public class Fossil : Obstacle
{
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
