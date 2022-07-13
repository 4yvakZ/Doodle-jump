using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doodle : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float horizontalSpeed = 10f;
    [SerializeField] private float horizontalInput;
    private bool isLeftPressed = false;
    private bool isRightPresed = false;

    private Rigidbody2D doodleRB;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        doodleRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        OutOffScreenBorderCheck();

        HorizontalMovement();
    }

    private void OutOffScreenBorderCheck()
    {
        var screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x < 0)
        {
            var newX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        } 
        else if (screenPos.x > Screen.width)
        {
            var newX = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }

    private void HorizontalMovement()
    {
#if UNITY_EDITOR
        horizontalInput = Input.GetAxis("Horizontal");
#else
        if (isLeftPressed && !isRightPresed)
        {
            horizontalInput = -1;
        } 
        else if (!isLeftPressed && isRightPresed)
        {
            horizontalInput = 1;
        }
        else
        {
            horizontalInput = 0;
        }
#endif


        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = false;
        }
        transform.Translate(Vector3.right * horizontalInput * horizontalSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (doodleRB.velocity.y == 0)
        {
            //doodleRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            doodleRB.velocity = Vector2.up * jumpForce;
            if (collision.gameObject.CompareTag("Trap Platform"))
            {
                PlatformGenerator.Instance.AddPlatform();
                Destroy(collision.gameObject.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Game Over");
        Destroy(gameObject);
    }

    public void LeftPressed()
    {
        isLeftPressed = true;
    }

    public void LeftReleased()
    {
        isLeftPressed = false;
    }

    public void RightPressed()
    {
        isRightPresed = true;
    }

    public void RightReleased()
    {
        isRightPresed = false;
    }
}
