using UnityEngine;

public class Cloud : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);            
    }
}
