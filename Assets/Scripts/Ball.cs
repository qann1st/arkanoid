using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 initialDirection;
    private bool gameStarted = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!gameStarted && Input.GetMouseButtonDown(0))
        {
            gameStarted = true;
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f;
            Vector2 direction = (Camera.main.ScreenToWorldPoint(mousePos) - transform.position).normalized;
            initialDirection = direction;
            rb.velocity = initialDirection * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            initialDirection = Vector2.Reflect(initialDirection, other.contacts[0].normal).normalized;
            rb.velocity = initialDirection * speed;
        }
        else if (other.gameObject.CompareTag("Brick"))
        {
            initialDirection = Vector2.Reflect(initialDirection, other.contacts[0].normal).normalized;
            rb.velocity = initialDirection * speed;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("BottomWall"))
        {
            Destroy(gameObject);
        }
    }
}
