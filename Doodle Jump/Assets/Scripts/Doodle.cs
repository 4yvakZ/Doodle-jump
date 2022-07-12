using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doodle : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float horizontalSpeed = 10f;
    [SerializeField] private float horizontalInput;

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
#if UNITY_EDITOR
        horizontalInput = Input.GetAxis("Horizontal");
#else
        horizontalInput = Input.acceleration.x;
#endif

        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        transform.Translate(Vector3.right * horizontalInput * horizontalSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (doodleRB.velocity.y <= 0)
        {
            doodleRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
