using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    private Vector3 targetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;

            targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            targetPosition.y = transform.position.y;

            rb.MovePosition(new Vector2(targetPosition.x, transform.position.y));
        }
    }
}
