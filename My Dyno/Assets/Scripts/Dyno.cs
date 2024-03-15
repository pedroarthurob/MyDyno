using Unity.VisualScripting;
using UnityEngine;

public class Dyno : MonoBehaviour
{
    [SerializeField] 
    private bool onGround = true;
    private Rigidbody2D rb;
    [SerializeField] 
    private float jumpForce = 12f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && onGround) 
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = false;
        }
    }
    private void FixedUpdate()
    {
        
    }
}
