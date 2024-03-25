using UnityEngine;

public class GroundRepeater : MonoBehaviour
{
    [SerializeField]
    private Vector2 startPosition;

    [SerializeField] 
    private float repeatWidth;


    private void Start()
    {
        startPosition = transform.position;
        repeatWidth = GetComponent<SpriteRenderer>().bounds.size.x ;       
    }

    private void Update()
    {
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }
    }




}
