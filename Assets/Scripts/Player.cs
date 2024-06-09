using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float forwardSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public bool _isGrounded;

    [Header("Points")]
    public GameObject topPoint;
    public GameObject bottomPoint;

    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private float swipeThreshold = 50f;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Move the player forward constantly
        _rigidbody.velocity = new Vector2(forwardSpeed, _rigidbody.velocity.y);

        // Check if the player is grounded
        _isGrounded = Physics2D.OverlapCircle(transform.position + new Vector3(0f, -0.3f, 0f), 0.2f, groundLayer);

        HandleKeyboardInput();

        // Handle touch input
        HandleTouchInput();
    }

    private void HandleKeyboardInput()
    {
        // Jump when space bar or single tap is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Move to topPoint when up arrow is pressed
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveToTopPoint();
        }

        // Move to bottomPoint when down arrow is pressed
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveToBottomPoint();
        }
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    break;

                case TouchPhase.Ended:
                    touchEndPos = touch.position;
                    DetectSwipe();
                    break;
            }
        }
    }

    private void DetectSwipe()
    {
        float swipeDistanceX = Mathf.Abs(touchEndPos.x - touchStartPos.x);
        float swipeDistanceY = Mathf.Abs(touchEndPos.y - touchStartPos.y);

        if (swipeDistanceX > swipeThreshold || swipeDistanceY > swipeThreshold)
        {
            if (swipeDistanceX > swipeDistanceY)
            {
                // Horizontal swipe detected (if needed in future implementations)
            }
            else
            {
                // Vertical swipe detected
                if (touchEndPos.y > touchStartPos.y)
                {
                    // Swipe up
                    MoveToTopPoint();
                }
                else if (touchEndPos.y < touchStartPos.y)
                {
                    // Swipe down
                    MoveToBottomPoint();
                }
            }
        }
        else
        {
            // Single tap detected
            Jump();
        }
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
    }

    private void MoveToTopPoint()
    {
        if (topPoint != null)
        {
            GameManager.Instance.GetTopGroundCollider();
            transform.position = new Vector2(transform.position.x, topPoint.transform.position.y);
        }
    }

    private void MoveToBottomPoint()
    {
        if (bottomPoint != null)
        {
            GameManager.Instance.GetBottomGroundCollider();
            transform.position = new Vector2(transform.position.x, bottomPoint.transform.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.ShowLosePanel();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + new Vector3(0f, -0.3f, 0f), 0.2f);
    }
}
