using Unity.VisualScripting;
using UnityEngine;

public class Dyno : MonoBehaviour
{
    [SerializeField] 
    private bool _onGround = true;
    private Rigidbody2D rb;
    [SerializeField] 
    private float jumpForce = 12f;

    [SerializeField]
    private float jumpGravityScale = 5f;
    [SerializeField]
    private float fallGravityScale = 10f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && _onGround) 
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (rb.velocity.y > 0)
        {
            rb.gravityScale = jumpGravityScale;
        } else
        {
            rb.gravityScale = fallGravityScale;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.AddForce(Vector2.down * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            _onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            _onGround = false;
        }
    }

    public bool onGround
    {
        get { return _onGround; }
        set { _onGround = value; }
    }


}
