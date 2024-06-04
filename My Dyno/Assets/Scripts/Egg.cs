using UnityEngine;

public class Egg : Obstacle
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
