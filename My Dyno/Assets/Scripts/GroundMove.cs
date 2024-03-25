using UnityEngine;

public class GroundMove : MonoBehaviour
{
    [SerializeField]
    private float groundSpeed = 5f;

    private void Update()
    {
        transform.Translate(Vector2.left * Time.fixedDeltaTime * groundSpeed);  
    }
}
