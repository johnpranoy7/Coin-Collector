using System.IO;
using Unity.Android.Types;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public bool isGrounded;
    private float move;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }

}
