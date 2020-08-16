using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Left & Right movement
        transform.Translate(new Vector2(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, 0));
    }

    // FixedUpdate is used for Rigidbody2D interactions
    private void FixedUpdate()
    {
        // Jumping
        if (Input.GetKey("space") && Mathf.Abs(rb.velocity.y) < 0.1)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        // do not allow physics rotation
        rb.freezeRotation = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            transform.rotation = collision.gameObject.transform.rotation;
        }
    }
}
